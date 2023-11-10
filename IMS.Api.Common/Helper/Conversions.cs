using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Api.Common.Helper
{
    public static class Conversions
    {
        public static DataTable ConvertModelToDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get the properties of the model type
            PropertyInfo[] modelProperties = typeof(T).GetProperties();

            // Create the columns in the DataTable based on the model properties
            foreach (PropertyInfo property in modelProperties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Populate the DataTable with data from the model instances
            foreach (T model in models)
            {
                DataRow row = dataTable.NewRow();

                foreach (PropertyInfo property in modelProperties)
                {
                    row[property.Name] = property.GetValue(model, null) ?? DBNull.Value;
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

    }
}
