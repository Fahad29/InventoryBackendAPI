namespace IMS.Api.Common.Model.CommonModel
{
    public class GridData
    {
        private static readonly object lockObject = new object();
        private static GridData instance = null;

        public static GridData Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new GridData();
                        }
                    }
                }
                return instance;
            }
        }

        public IEnumerable<object> DataList { get; set; } = new List<object>();
        public int TotalCount { get; set; } = 0;

        // Private constructor to prevent instantiation outside the class
        private GridData()
        {
        }
    }

}
