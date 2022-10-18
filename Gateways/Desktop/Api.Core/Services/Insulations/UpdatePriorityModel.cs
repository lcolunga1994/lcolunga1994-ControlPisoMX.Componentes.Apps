namespace ProlecGE.ControlPisoMX.Insulations.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UpdatePriorityModel
    {
        #region Constructor

        public UpdatePriorityModel(Guid id, int priority)
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
