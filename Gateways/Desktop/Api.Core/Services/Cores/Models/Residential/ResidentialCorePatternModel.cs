namespace ProlecGE.ControlPisoMX.Cores.Models
{
    using System.Collections.Generic;

    public class ResidentialCorePatternModel
    {
        #region Constructor

        public ResidentialCorePatternModel(
            string itemId,
            string batch,
            int serie,
            double kva,
            double primaryVoltage,
            double secondaryVoltage,
            double testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            Limits = limits ?? System.Array.Empty<ItemVoltageLimitModel>();
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public double KVA { get; set; }

        public double PrimaryVoltage { get; set; }

        public double SecondaryVoltage { get; set; }

        public double TestVoltage { get; set; }

        public IEnumerable<ItemVoltageLimitModel> Limits { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}