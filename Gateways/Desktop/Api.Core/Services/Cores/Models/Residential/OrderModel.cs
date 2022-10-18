namespace ProlecGE.ControlPisoMX.Cores.Models.Residential
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public OrderModel(
            string itemId,
            string batch,
            int serie,
            int sequence)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

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
