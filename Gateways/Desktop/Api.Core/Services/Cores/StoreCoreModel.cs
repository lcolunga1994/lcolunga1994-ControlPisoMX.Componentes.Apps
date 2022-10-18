namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class StoreCoreModel
    {
        #region Constructor

        public StoreCoreModel() { }

        public StoreCoreModel(Guid coreTestId, string location, string? associatedCode, bool force)
        {
            CoreTestId = coreTestId;
            Location = location;
            AssociatedCode = associatedCode;
            Force = force;
        }

        #endregion

        #region Properties

        [Required]
        public Guid CoreTestId { get; set; }

        [Required]
        [StringLength(7)]
        public string? Location { get; set; }

        [StringLength(8)]
        public string? AssociatedCode { get; set; }

        public bool Force { get; set; }

        #endregion
    }
}