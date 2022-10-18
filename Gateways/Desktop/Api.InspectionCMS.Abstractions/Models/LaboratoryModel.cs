namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models
{
    public class LaboratoryModel
    {
        #region Constructor

        public LaboratoryModel(string description, double? value)
        {
            Description = description;
            Value = value;
        }

        #endregion

        #region Properties

        public string Description { get; set; } = "";

        public double? Value { get; set; }

        #endregion
    }
}
