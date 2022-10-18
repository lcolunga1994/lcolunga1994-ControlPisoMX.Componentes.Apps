namespace ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders
{
    using System;
    using System.Collections.Generic;

    public class MOPrintableModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public MOPrintableModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            DateTime scheduledDate,
            string machine,
            int productline,
            int line)
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
            ScheduledDate = scheduledDate;
            Machine = machine;
            ProductLine = productline;
            Line = line;
            Attributes = new();
        }

        #endregion

        #region Properties

        public string ItemId { get; private set; }

        public string Batch { get; private set; }

        public int Serie { get; private set; }

        public int Sequence { get; private set; }

        public DateTime ScheduledDate { get; set; }

        public string Machine { get; private set; }

        public int ProductLine { get; private set; }

        public int Line { get; private set; }

        public List<MOPrintableAttributeModel> Attributes { get; set; }

        #endregion
    }

    public class MOPrintableAttributeModel
    {
        #region Properties

        public string Attribute { get; set; } = null!;

        public string? Value { get; set; }

        #endregion
    }
}