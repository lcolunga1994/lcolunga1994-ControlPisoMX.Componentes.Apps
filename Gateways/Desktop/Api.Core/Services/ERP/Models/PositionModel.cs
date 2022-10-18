namespace ProlecGE.ControlPisoMX.ERP.Models
{
    public class PositionModel
    {
        #region Properties

        public string Position { get; set; }

        public double Voltage { get; set; }

        public double Nominal { get; set; }

        public double Max { get; set; }

        public double Min { get; set; }

        #endregion

        #region Constructor

        public PositionModel(string position, double voltage, double nominal, double max, double min)
        {
            Position = position;
            Voltage = voltage;
            Nominal = nominal;
            Max = max;
            Min = min;
        }

        #endregion
    }
}