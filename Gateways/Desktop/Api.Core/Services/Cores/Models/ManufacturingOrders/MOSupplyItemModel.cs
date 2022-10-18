namespace ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders
{
    using System;

    public class MOSupplyItemModel
    {
        #region Constructor

        public MOSupplyItemModel(
            Guid id,
            string itemId,
            string batch,
            int serie,
            int sequence,
            DateTime scheduleDate,
            string machine)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

            Id = id;
            ItemId = itemId.Trim();
            Batch = batch.Trim();
            Serie = serie;
            Sequence = sequence;
            Machine = machine;
            ScheduleDate = scheduleDate;
        }

        #endregion

        #region Properties

        public Guid Id { get; private set; }

        public string ItemId { get; private set; }

        public string Batch { get; private set; }

        public int Serie { get; private set; }

        public int Sequence { get; set; }

        public DateTime ScheduleDate { get; private set; }

        public string Machine { get; private set; }

        public int ProductLine { get; set; }
        
        public int Phases { get; set; }

        public int Line { get; set; }

        public DateTime RegisterUtcDate { get; set; }

        #endregion
    }
}