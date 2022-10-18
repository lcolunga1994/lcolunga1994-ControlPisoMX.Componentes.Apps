namespace ProlecGE.ControlPisoMX.Insulations.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderToRepairModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public OrderToRepairModel() { }

        public OrderToRepairModel(string itemId, string batch, int quantity, int priority)
        {
            ItemId = itemId;
            Batch = batch;
            Quantity = quantity;
            Priority = priority;
        }

        #endregion

        #region Properties

        [StringLength(47)]
        [Required]
        public string ItemId { get; set; } = null!;

        [StringLength(3)]
        [Required]
        public string Batch { get; set; } = null!;

        [Required]
        public int Serie { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 999)]
        public int Priority { set; get; }

        #endregion
    }
}
