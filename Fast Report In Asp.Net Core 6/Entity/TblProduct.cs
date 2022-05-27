namespace FastReportIntegrateWithStoreProcedureInAspNetCore6.Entity
{
    public class TblProduct
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int TblCategoryID { get; set; }
        public virtual TblCategory TblCategory { get; set; }
    }
}
