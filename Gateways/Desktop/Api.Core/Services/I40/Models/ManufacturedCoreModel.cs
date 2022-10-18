namespace ProlecGE.ControlPisoMX.I40.Models
{
    using System;

    public class ManufacturedCoreModel
    {
        #region Constructor

        public ManufacturedCoreModel(
            string tag,
            string itemId,
            string batch,
            int sequence,
            int size,
            DateTime scheduledUtcDate)
        {
            Tag = tag;
            ItemId = itemId;
            Batch = batch;
            Sequence = sequence;
            Size = size;
            ScheduledUtcDate = scheduledUtcDate;
        }

        #endregion

        #region Properties

        public string Tag { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Sequence { get; set; }

        public int Size { get; set; }

        public DateTime ScheduledUtcDate { get; set; }

        #endregion
    }
}