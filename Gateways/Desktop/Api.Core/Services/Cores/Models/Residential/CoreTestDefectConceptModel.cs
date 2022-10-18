namespace ProlecGE.ControlPisoMX.Cores.Models
{
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

        public string Id { get; set; }

        public string Concept {  get; set; }

        #endregion
    }
}
