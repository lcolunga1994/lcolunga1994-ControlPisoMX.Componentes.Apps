namespace ProlecGE.ControlPisoMX.Cores.Models.Residential
{
    using System.ComponentModel.DataAnnotations;

    public class ResidentialCoreSuggestedCodeModel
    {

        #region Constructor

        public ResidentialCoreSuggestedCodeModel(
            string? suggestedCode,
            string? location,
            int? color)
        {
            SuggestedCode = suggestedCode;
            Location = location;
            Color = color;
        }

        #endregion

        #region Properties
        [Required]
        public string? SuggestedCode { get; set; }
        
        [Required]
        public string? Location { get; set; }

        public int? Color { get; set; }

        #endregion  
    }
}