namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    public class ManufacturingOrderModel
    {
        #region Constructor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ManufacturingOrderModel()
        { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public ManufacturingOrderModel(string itemId, string batch, int quantity, string machine, DateTime startDateUtc)
        {
            ItemId = itemId;
            Batch = batch;
            Quantity = quantity;
            Machine = machine;
            StartUtcDate = startDateUtc;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public string Machine { get; set; }

        public int Quantity { get; set; }

        public DateTime StartUtcDate { get; set; }

        #endregion
    }
}