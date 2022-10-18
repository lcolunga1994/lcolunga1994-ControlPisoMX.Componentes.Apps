namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System;

    internal class RegisterDefectCommand
    {
        #region Constructor

        public RegisterDefectCommand(
            string testCode,
            string defect)
        {
            if (string.IsNullOrWhiteSpace(testCode))
            {
                throw new UserException("El identificador de la prueba no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(defect))
            {
                throw new UserException("El defecto no puede ser vacío o espacios en blanco.");
            }

            TestCode = testCode.Trim();
            Defect = defect.Trim();
        }

        #endregion

        #region Properties

        public string TestCode { get; }

        public string Defect { get; }

        #endregion
    }
}
