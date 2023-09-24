namespace IMS.Api.Service.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Search(object parameters, string query);
        IEnumerable<Model> Search<Model>(object parameters, string query);

        public List<Model> Search<Model>(object parameters, string sql, string connectionString);
        IEnumerable<Model> ExecuteQuery<Model>(object parameters, string query);
        Task<IEnumerable<Model>> ExecuteQueryAsync<Model>(object parameters, string query);
        Model CreateSP<Model>(object model, string storedProcName);
        void CreateSP(object model, string storedProcName);
        void InsertInBulk<Model>(List<Model> listModel, string tableName, int? commandTimeout);
        bool Delete(object model, string storedProcName);

    }
}
