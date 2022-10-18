namespace ProlecGE.ControlPisoMX.Cores.Models
{
    using System;

    public class CoreManufacturingPlanItemModel
    {
        #region Constructor

        public CoreManufacturingPlanItemModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            DateTime scheduledUtcDate,
            int phases)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
            Sequence = sequence;
            ScheduledUtcDate = scheduledUtcDate;
            Phases = phases;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        public string Batch { get; }

        public int Serie { get; }

        public int Sequence { get; }

        public DateTime ScheduledUtcDate { get; }

        public int ProductLine { get; set; }

        public int Size { get; set; }

        public int Phases { get; }

        public int TotalCores => Phases switch
        {
            1 => 2,
            3 => 4,
            _ => 0
        };

        #endregion
    }
}