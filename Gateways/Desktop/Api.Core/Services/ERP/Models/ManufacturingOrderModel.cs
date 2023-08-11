namespace ProlecGE.ControlPisoMX.ERP.Models
{
    public class ManufacturingOrderModel
    {
        #region Properties

        public int OrderId { get; set; }

        public string ItemId { get; set; } = null!;

        public string Batch { get; set; } = null!;

        public int Quantity { get; set; }

        public string SaleId { get; set; } = null!;

        public int SaleDetailId { get; set; }

        public int Status { get; set; }

        #endregion
    }
}