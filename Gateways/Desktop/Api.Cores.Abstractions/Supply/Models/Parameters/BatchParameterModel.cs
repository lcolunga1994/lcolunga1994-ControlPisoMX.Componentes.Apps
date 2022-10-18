namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BatchParameterModel
    {
        #region Constructor

        public BatchParameterModel() { }

        public BatchParameterModel(
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
        public string? Batch { get; set; }

        #endregion
    }
}