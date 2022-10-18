namespace ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MOSupplyParameterModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public MOSupplyParameterModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            DateTime scheduledDate,
            string machine,
            List<MOPrintableAttributeModel> printableAttributes)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            ScheduledDate = scheduledDate;
            Machine = machine;
            PrintableAttributes = printableAttributes;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(47)]
        public string ItemId { get; set; }

        [Required]
        [StringLength(3)]
        public string Batch { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required]
        public int Sequence { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [StringLength(6)]
        public string Machine { get; set; }

        [Required]
        public int ProductLine { get; set; }

        [Required]
        public int Phases { get; set; }

        public int Line { get; set; }

        public List<MOPrintableAttributeModel> PrintableAttributes { get; set; }

        #endregion
    }
}