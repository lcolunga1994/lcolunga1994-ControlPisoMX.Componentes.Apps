namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class ManufacturedResidentialCoreModel
    {
        #region Constructor

        public ManufacturedResidentialCoreModel(
            string tag,
            string itemId,
            string batch,
            int sequence,
            CoreSizes size,
            DateTime scheduledDate)
        {
            Tag = tag;
            ItemId = itemId;
            Batch = batch;
            Sequence = sequence;
            Size = size;
            ScheduledDate = scheduledDate;
        }

        #endregion

        #region Properties

        public string Tag { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Sequence { get; set; }

        public CoreSizes Size { get; set; }

        public DateTime ScheduledDate { get; set; }

        #endregion
    }
}