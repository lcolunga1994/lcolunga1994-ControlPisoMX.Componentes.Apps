namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models
{
    public class CoreVoltageLimitModel
    {
        #region Constructor

        public CoreVoltageLimitModel(CoreLimitColor color)
        {
            Color = color;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public CoreVoltageLimitModel(
            CoreLimitColor color,
            double min,
            double max) : this(color)
        {
            Min = min;
            Max = max;
        }

        #endregion

        #region Properties

        public CoreLimitColor Color { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }

        #endregion
    }
}