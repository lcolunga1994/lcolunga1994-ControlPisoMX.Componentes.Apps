namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    public class ManufacturingOrderAddedModel
    {
        #region Constructor

        public ManufacturingOrderAddedModel(
            Guid id,
            string itemId,
            string batch,
            int serie,
            string machine,
            int quantity,
            int priority,
            DateTime requestUtcDate,
            int status)
        {
            Id = id;
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Machine = machine;
            Quantity = quantity;
            Priority = priority;
            RequestUtcDate = requestUtcDate;
            Status = status;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public string Machine { get; set; }

        public int Quantity { get; set; }

        public int Priority { get; set; }

        public DateTime RequestUtcDate { get; set; }

        public int Status { get; set; }

        #endregion
    }
}