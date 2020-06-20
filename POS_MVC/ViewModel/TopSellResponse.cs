namespace RexERP_MVC.ViewModel
{
    public class TopSellResponse
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string APIName { get; set; }
        public string SizeName { get; set; }
        public string BrandName { get; set; }
        public decimal TotalAmount { get; set; }
        //added by al ameen
        public decimal Qty { get; set; }
        //public decimal Rate { get; set; }

    }
}