namespace ProlecGE.ControlPisoMX.BFWeb.Components.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderModel
    {
        #region Constructor

        public OrderModel(
            string itemId,
            string batch,
            int serie,
            int sequence)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
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

        #endregion
    }
}
