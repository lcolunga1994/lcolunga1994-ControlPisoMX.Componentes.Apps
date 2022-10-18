namespace ProlecGE.ControlPisoMX.Cores.Models
{
    public class IndustrialItemVoltageDesignModel
    {
        #region Constructor

        public IndustrialItemVoltageDesignModel(
            string itemId,
            int coreSize,
            double foilWidth,
            int phases,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            double minWattsLimit,
            double maxWattsLimit)
        {
            ItemId = itemId;
            CoreSize = coreSize;
            FoilWidth = foilWidth;
            Phases = phases;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            MinWattsLimit = minWattsLimit;
            MaxWattsLimit = maxWattsLimit;
        }

        #endregion

        #region Properties

        [System.Text.Json.Serialization.JsonInclude]
        public string ItemId { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public int CoreSize { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double FoilWidth { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public int Phases { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double? KVA { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double PrimaryVoltage { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double? SecondaryVoltage { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double? TestVoltage { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double MinWattsLimit { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double MaxWattsLimit { get; private set; }

        public bool HasLimits => MinWattsLimit >= 0d && MaxWattsLimit > 0d;

        #endregion
    }
}