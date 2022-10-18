namespace ProlecGE.ControlPisoMX.Insulations.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderModel
    {
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
        public int Sequence { get; set; }

        #endregion
    }
}