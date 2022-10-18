namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ManufacturingOrderParameterModel
    {
        #region Constructor

        public ManufacturingOrderParameterModel() { }

        public ManufacturingOrderParameterModel(
            string itemId,
            string batch)
        {
            ItemId = itemId;
            Batch = batch;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(47)]
        public string? ItemId { get; set; }

        [Required]
        [StringLength(3)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "No se admiten caracteres especiales")]
        public string? Batch { get; set; }

        #endregion
    }
}