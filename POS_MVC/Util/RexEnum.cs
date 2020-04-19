namespace RexERP_MVC.Util
{
    public enum TransactionType
    {
        OpeningQty = 1,
        ReceiveQty = 2,
        ProductionIn = 3,
        ProductionOut = 4,
        ReturnQty = 5,
        Faulty = 6,
        SalesQty = 7
    }
    public enum DeliveryStatus
    {
        Delivered = 1,
        Pending = 0
    }
}