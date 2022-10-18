namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class ResidentialCoreSuggestedCodeResultModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public ResidentialCoreSuggestedCodeResultModel(
            string? suggestedCode,
            string? location,
            CoreLimitColor? color)
        {
            SuggestedCode = suggestedCode;
            Location = location;
            Color = color;
        }

        #endregion

        #region Properties

        public string? SuggestedCode { get; set; }

        public string? Location { get; set; }

        public CoreLimitColor? Color { get; set; }

        #endregion  
    }
}