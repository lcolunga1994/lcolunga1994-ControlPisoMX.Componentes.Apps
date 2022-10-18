namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class CoreManufacturingPlanModel
    {
        #region Constructor

        public CoreManufacturingPlanModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            DateTime scheduledUtcDate)
        {
             ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
            Sequence = sequence;
            ScheduledUtcDate = scheduledUtcDate;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public DateTime ScheduledUtcDate { get; set; }

        public ProductLine ProductLine { get; set; }

        public string? Tag { get; set; }

        #endregion
    }
}