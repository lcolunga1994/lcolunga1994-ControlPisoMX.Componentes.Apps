namespace ProlecGE.ControlPisoMX.Cores.Models
{
    public class ItemVoltageLimitModel
    {
        #region Constructor

        public ItemVoltageLimitModel(
            int color,
            double min,
            double max)
        {
            Color = color;
            Min = min;
            Max = max;
        }

        #endregion

        #region Properties

        public int Color { get; }

        public double Min { get; }

        public double Max { get; }

        #endregion
    }
}