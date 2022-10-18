namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddOrderToRepairParameterModel
    {
        #region Constructor

        public AddOrderToRepairParameterModel(string itemId, string batch, int quantity, int priority)
        {
            ItemId = itemId;
            Batch = batch;
            Quantity = quantity;
            Priority = priority;
        }

        #endregion

        #region Propierties

        [Required]
        [StringLength(47)]
        public string ItemId { set; get; }

        [Required]
        [StringLength(3)]
        public string Batch { set; get; }

        [Required]
        [Range(1, 2)]
        public int Quantity { set; get; }

        [Required]
        [Range(0, 999)]
        public int Priority { set; get; }

        #endregion
    }
}