namespace ProlecGE.ControlPisoMX.Cores.Models.Industrial
{
    public class IndustrialCoreSuggestedCodeModel
    {
        #region Constructor

        public IndustrialCoreSuggestedCodeModel(
            string? suggestedCode,
            string? location)
        {
            SuggestedCode = suggestedCode;
            Location = location;
        }

        #endregion

        #region Properties

        public string? SuggestedCode { get; set; }

        public string? Location { get; set; }

        #endregion
    }
}
