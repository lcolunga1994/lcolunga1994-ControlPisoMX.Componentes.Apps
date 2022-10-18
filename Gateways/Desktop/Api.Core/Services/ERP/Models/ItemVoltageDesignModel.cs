namespace ProlecGE.ControlPisoMX.ERP.Models
{
    using System.Collections.Generic;

    public class ItemVoltageDesignModel
    {
        #region Constructor

        public ItemVoltageDesignModel(
            string designId,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits)
        {
            DesignId = designId;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;

            Limits = limits ?? System.Array.Empty<ItemVoltageLimitModel>();
        }

        #endregion

        #region Properties

        [System.Text.Json.Serialization.JsonInclude]
        public string DesignId { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double? KVA { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double PrimaryVoltage { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double? SecondaryVoltage { get; private set; }

        [System.Text.Json.Serialization.JsonInclude]
        public double? TestVoltage { get; private set; }

        public IEnumerable<ItemVoltageLimitModel> Limits { get; private set; }

        #endregion
    }

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