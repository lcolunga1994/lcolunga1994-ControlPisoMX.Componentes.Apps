namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System;

    public class MOManufacturingStatusModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public MOManufacturingStatusModel(string itemId, string batch, int serie, int sequence)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Machine = "";
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public string Machine { get; set; }

        public DateTime ScheduledDate { get; set; }

        public int? InsulationStatus { get; set; }

        public CoreTestResult? CoreTestResult { get; set; }

        public CoreLimitColor? CoreTestColor { get; set; }

        public string? CoreLocation { get; set; }

        #endregion
    }
}