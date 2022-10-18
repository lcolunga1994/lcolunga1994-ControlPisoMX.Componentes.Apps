namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MachineAndUtcDateParameterModel
    {
        #region Properties

        [Required]
        [StringLength(6)]
        public string Machine { get; set; } = null!;

        [Required]
        public DateTime UtcDate { get; set; }

        #endregion
    }
}