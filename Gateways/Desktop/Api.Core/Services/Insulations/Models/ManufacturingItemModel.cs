namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    using System;

    public class ManufacturingItemModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public ManufacturingItemModel(
            Guid id,
            string itemId,
            string batch,
            int quantity,
            int serie,
            int sequence,
            string machine,
            DateTime requestUtcDate,
            int priority,
            int status,
            string? dimensions)
        {
            Id = id;
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Quantity = quantity;
            Machine = machine;
            RequestUtcDate = requestUtcDate;
            Priority = priority;
            Status = status;
            Dimensions = dimensions;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public int Quantity { get; set; }

        public DateTime RequestUtcDate { get; set; }

        public string Machine { get; set; }

        public int Priority { get; set; }

        public int Status { get; set; }

        public string? Dimensions { get; set; }

        #endregion
    }
}
