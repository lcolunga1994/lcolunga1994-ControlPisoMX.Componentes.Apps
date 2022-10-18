namespace ProlecGE.ControlPisoMX.Cores.Models.Industrial
{
    public class IndustrialCoreLocationResultModel
    {
        #region Constructor

        public IndustrialCoreLocationResultModel(
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
