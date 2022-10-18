namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models
{
    public class IndustrialCorePatternModel
    {
        #region Constructor

        public IndustrialCorePatternModel(
            string itemId,
            string batch,
            int serie,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            double min,
            double max)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            Min = min;
            Max = max;
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

        public double Min { get; set; }

        public double Max { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}