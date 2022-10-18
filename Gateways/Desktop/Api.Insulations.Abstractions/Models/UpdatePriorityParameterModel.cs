namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdatePriorityParameterModel
    {
        #region Constructor

        public UpdatePriorityParameterModel(Guid id, int priority)
        {
            Id = id;
            Priority = priority;
        }

        #endregion

        #region Properties

        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 999)]
        public int Priority { get; set; }

        #endregion
    }
}