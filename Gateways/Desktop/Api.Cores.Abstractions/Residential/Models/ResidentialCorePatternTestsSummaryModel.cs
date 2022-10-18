namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System.Collections.Generic;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class ResidentialCorePatternTestsSummaryModel
    {
        #region Constructor

        public ResidentialCorePatternTestsSummaryModel(
            string itemId,
            string batch,
            int serie,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            int totalTests,
            IEnumerable<ResidentialCorePatternVoltageLimitModel> limits)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            TotalTests = totalTests;

            Limits = limits ?? Array.Empty<ResidentialCorePatternVoltageLimitModel>();
        }

        #endregion

        #region Properties

        public string ItemId { get; private set; }

        public string Batch { get; private set; }

        public int Serie { get; private set; }

        public double? KVA { get; private set; }

        public double PrimaryVoltage { get; private set; }

        public double? SecondaryVoltage { get; private set; }

        public double? TestVoltage { get; private set; }

        public int TotalTests { get; set; }

        public IEnumerable<ResidentialCorePatternVoltageLimitModel> Limits { get; private set; }

        #endregion
    }

    public class ResidentialCorePatternVoltageLimitModel
    {
        #region Constructor

        public ResidentialCorePatternVoltageLimitModel(CoreLimitColor color)
        {
            Color = color;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public ResidentialCorePatternVoltageLimitModel(
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