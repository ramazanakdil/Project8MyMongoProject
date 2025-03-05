namespace MyMongoProject.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string DepartmentCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string SellingCollectionName { get; set; }

    }
}
