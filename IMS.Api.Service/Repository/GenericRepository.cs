using Dapper;
using IMS.Api.Common.Constant;
using IMS.Api.Common.Extensions;
using IMS.Api.Common.Helper;
using IMS.Api.Common.Model.CommonModel;
using IMS.Api.Common.Model.RequestModel;
using IMS.Api.Common.Model.ResponseModel;
using IMS.Api.Service.IRepository;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using static Dapper.SqlMapper;

namespace IMS.Api.Service.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IConnection _connection;
        readonly string _connectionString;
        public GenericRepository(IConnection connection)
        {
            _connection = connection;
            _connectionString = _connection.ConnectionString.ToString();
        }

        public IEnumerable<TEntity> Search(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<TEntity>(query, param: parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<Model> Search<Model>(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Model>(query, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: 5000).ToList();
            }
        }

        public async Task<(IEnumerable<Model>, int)> SearchMuiltiple<Model>(object parameters, string storedProcedureName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (GridReader multiObject = await conn.QueryMultipleAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure))
                    {
                        IEnumerable<Model> listOfObj = await multiObject.ReadAsync<Model>();
                        int totalCount = await multiObject.ReadFirstAsync<int>();
                        return (listOfObj, totalCount);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<Model> ExecuteQuery<Model>(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Model>(query, param: parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public async Task<IEnumerable<Model>> ExecuteQueryAsync<Model>(object parameters, string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Model>(query, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: 340);
            }
        }


        public Model CreateSP<Model>(object model, string storedProcName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Model>(storedProcName, model, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void CreateSP(object model, string storedProcName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Query(storedProcName, model, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void InsertInBulk<Model>(List<Model> listModel, string tableName, int? commandTimeout)
        {
            DataTable table = CreateTable(listModel, null);
            if (table.Rows.Count == 0) return;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlBulkCopy = new SqlBulkCopy(conn);

                if (commandTimeout.HasValue)
                    sqlBulkCopy.BulkCopyTimeout = commandTimeout.Value;

                sqlBulkCopy.DestinationTableName = EncodeSqlObjectName(tableName);
                foreach (DataColumn column in table.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(column.ColumnName, EncodeSqlObjectName(column.ColumnName));
                }

                bool wasClosed = conn.State == ConnectionState.Closed;
                try
                {
                    if (wasClosed) conn.Open();
                    sqlBulkCopy.WriteToServer(table);
                }
                catch (SqlException ex)
                {
                    APIConfig.Log.Debug("Exception : " + ex.Message + " Stack Track : " + ex.StackTrace);

                }
                finally
                {
                    if (wasClosed) conn.Close();
                }
            }
        }

        #region Function for bulk Insert
        public static DataTable CreateTable<T>(IEnumerable<T> data, string columnName)
        {
            var table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            if (columnName != null)
                BuildOneColumnTable(table, data, columnName);
            else
                BuildCustomTable(table, data);

            return table;
        }

        private static void BuildOneColumnTable<T>(DataTable table, IEnumerable<T> data, string columnName)
        {
            table.Columns.Add(new DataColumn(columnName, typeof(T)));
            table.Rows.AddRange(data);
        }

        private static void BuildCustomTable<T>(DataTable table, IEnumerable<T> data)
        {
            var columnMap = ReflectionHelper.GetColumnMap(typeof(T));
            var columns = columnMap.Select(ToDataColumn).ToArray();
            table.Columns.AddRange(columns);
            table.Rows.AddRange(data, ConvertToRow);
        }

        private static object[] ConvertToRow<T>(T entity)
        {
            var props = ReflectionHelper.GetColumnMap(typeof(T)).Select(t => t.Item1).ToArray();
            var result = new object[props.Length];
            for (int i = 0; i < props.Length; i++)
            {
                result[i] = props[i].GetValue(entity);
            }

            return result;
        }

        private static DataColumn ToDataColumn(Tuple<MemberInfo, string> tuple)
        {
            var memberType = tuple.Item1.GetMemberType();
            var nullableType = Nullable.GetUnderlyingType(memberType);

            return new DataColumn(tuple.Item2, nullableType ?? memberType);
        }

        public static string EncodeSqlObjectName(string name)
        {
            var split = name.Split('.');
            var enсoded = split.Select(p => p.Trim('[', ']', ' ')).Select(x => $"[{x}]");
            return string.Join(".", enсoded);
        }
        #endregion


        public bool Delete(object model, string procName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    conn.Query(procName, model, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<Model> GetById<Model>(object parameters, string storedProcedureName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return await conn.QuerySingleAsync<Model>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(TFirst, IEnumerable<TSecond>)> GetByIdMultiple<TFirst, TSecond>(object parameters, string storedProcedureName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (GridReader multiObject = await conn.QueryMultipleAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure))
                    {
                        TFirst FirstModel = await multiObject.ReadFirstAsync<TFirst>();
                        IEnumerable<TSecond> SecondModel = await multiObject.ReadAsync<TSecond>();
                        return (FirstModel, SecondModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PurchaseOrderDTO> PurchaseTransactionsCreate(PurchaseRequestModel purchaseRequest)
        {
            try
            {
                PurchaseOrderDTO purchaseObj = new PurchaseOrderDTO();
                using (var conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (var transaction = await conn.BeginTransactionAsync())
                    {
                        try
                        {
                            var purchaseOrder = new
                            {
                                VendorId = purchaseRequest.VendorId,
                                DeliveryDate = purchaseRequest.DeliveryDate,
                                TotalAmount = purchaseRequest.TotalAmount,
                                PaymentType = purchaseRequest.PaymentType,
                                PaymentStatus = purchaseRequest.PaymentStatus,
                                PaidAmount = purchaseRequest.PaidAmount,
                                Note = purchaseRequest.Note,
                                UserId = purchaseRequest.UserId,
                                CompanyId = purchaseRequest.CompanyId
                            };

                            purchaseObj = await conn.QuerySingleAsync<PurchaseOrderDTO>(Constant.SpCreatePurchaseOrder, purchaseOrder, transaction, null, CommandType.StoredProcedure);

                            foreach (var purchaseItem in purchaseRequest.PurchaseItemRequests)
                            {
                                CalculateAmount calculation = new CalculateAmount(purchaseItem.ItemPrice, purchaseRequest.TaxValue);

                                purchaseItem.PurchaseOrderId = purchaseObj.PurchaseOrderID;
                                purchaseItem.TotalWithOutVAT = calculation.PriceWithoutVat;
                                purchaseItem.VATAmount = calculation.VatAmount;
                                await conn.ExecuteAsync(Constant.SpCreatePurchaseItem, purchaseItem, transaction, null, CommandType.StoredProcedure);
                            }

                            // Commit the transaction to save the changes
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions and roll back the transaction
                            transaction.Rollback();
                            throw;
                        }
                    }
                    return purchaseObj;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
