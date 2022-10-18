namespace ProlecGE.ControlPisoMX.Cores.Models
{

    public class IndustrialCorePatternModel
    {
        #region Constructor

        public IndustrialCorePatternModel(
            string itemId,
            string batch,
            int serie,
            double kva,
            double primaryVoltage,
            double secondaryVoltage,
            double testVoltage,
            double minLimit,
            double maxLimit)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            MinLimit = minLimit;
            MaxLimit = maxLimit;
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

        public double MinLimit { get; set; }

        public double MaxLimit { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}