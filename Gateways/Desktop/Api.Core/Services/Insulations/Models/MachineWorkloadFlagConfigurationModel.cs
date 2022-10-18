namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    public class MachineWorkloadFlagConfigurationModel
    {
        #region Constructor

        public MachineWorkloadFlagConfigurationModel(string normalColor, string warningColor, string criticalColor, string lockedColor, int highLevel, int lowLevel)
        {
            NormalColor = normalColor;
            WarningColor = warningColor;
            CriticalColor = criticalColor;
            LockedColor = lockedColor;

            HighLevel = highLevel;
            LowLevel = lowLevel;
        }

        #endregion

        #region Properties

        public string NormalColor { get; set; }
        public string WarningColor { get; set; }

        public string CriticalColor { get; set; }
        public string LockedColor { get; set; }

        public int HighLevel { get; set; }

        public int LowLevel { get; set; }

        #endregion
    }
}
