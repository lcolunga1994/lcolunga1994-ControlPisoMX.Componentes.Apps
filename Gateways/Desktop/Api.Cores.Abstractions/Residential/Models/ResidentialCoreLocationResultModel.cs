namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    public class ResidentialCoreLocationResultModel
    {
        #region Constructor

        public ResidentialCoreLocationResultModel(
            string? associatedCode,
            string? location,
            string? cmsMachine
            )
        {
            AssociatedCode = associatedCode;
            Location = location;
            CmsMachine = cmsMachine;
        }

        #endregion

        #region Properties

        public string? AssociatedCode { get; set; }

        public string? Location { get; set; }

        public string? CmsMachine { get; set; }

        #endregion
    }
}