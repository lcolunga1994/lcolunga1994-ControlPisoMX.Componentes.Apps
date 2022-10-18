namespace ProlecGE.ControlPisoMX.Insulations.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MachineManufacturingPlanModel
    {
        #region Properties

        [Required]
        [StringLength(6)]
        public string Machine { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        #endregion
    }
}