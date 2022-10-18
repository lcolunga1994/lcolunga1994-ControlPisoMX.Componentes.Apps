namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterDefectParametersModel
    {
        #region Constructor

        public RegisterDefectParametersModel(string testCode, string defect)
        {            
            TestCode = testCode.Trim();
            Defect = defect.Trim();
        }

        #endregion

        #region Properties

        [Required]
        public string TestCode { get; }

        [Required]
        [StringLength(30)]
        public string Defect { get; }

        #endregion
    }
}