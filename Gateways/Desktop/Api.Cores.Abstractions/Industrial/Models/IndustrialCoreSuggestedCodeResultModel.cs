namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models
{
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class IndustrialCoreSuggestedCodeResultModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public IndustrialCoreSuggestedCodeResultModel(
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