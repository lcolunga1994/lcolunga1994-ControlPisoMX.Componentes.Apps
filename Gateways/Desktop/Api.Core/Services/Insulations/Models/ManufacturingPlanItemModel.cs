namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    using System;
    public class ManufacturingPlanItemModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public ManufacturingPlanItemModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            string machine,
            DateTime scheduledDate,
            int phases,
            string market)
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
            Machine = machine.Trim();
            ScheduledDate = scheduledDate;
            Phases = phases;
            Market = market;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public string Machine { set; get; }

        public DateTime ScheduledDate { get; }

        public int ProductLine { get; set; }

        public int Phases { get; }
        
        public string Market { get; set; }

        #endregion
    }
}