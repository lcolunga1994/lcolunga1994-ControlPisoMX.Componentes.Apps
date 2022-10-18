﻿namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateAndMachineParameterModel
    {
        #region Properties

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(6)]
        public string Machine { get; set; } = null!;

        #endregion
    }
}