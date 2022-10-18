namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderToManufactureModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public OrderToManufactureModel() { }

        public OrderToManufactureModel(string itemId, string batch, int serie, int sequence, string? dimensions)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Dimensions = dimensions;
        }

        #endregion

        #region Properties

        [StringLength(47)]
        [Required]
        public string ItemId { get; set; } = null!;

        [StringLength(47)]
        [Required]
        public string Batch { get; set; } = null!;

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public string? Dimensions { get; set; }

        #endregion
    }
}