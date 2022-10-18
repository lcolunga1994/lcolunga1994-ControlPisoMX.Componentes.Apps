namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CoreTestDefectConceptModel
    {
        #region Constructor

        public CoreTestDefectConceptModel(
            string id,
            string concept
            )
        {
            Id = id;
            Concept = concept;
        }

        #endregion

        #region Properties

        [Required]
        public string Id { get; set; }

        [Required]
        public string Concept { get; set; }

        #endregion
    }
}