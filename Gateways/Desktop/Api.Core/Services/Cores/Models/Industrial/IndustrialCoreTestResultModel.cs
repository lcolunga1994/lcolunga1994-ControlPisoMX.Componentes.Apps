namespace ProlecGE.ControlPisoMX.Cores.Models
{
    using System.Collections.Generic;

    public class IndustrialCoreTestResultModel
    {
        #region Fields

        private readonly HashSet<int> warnings;

        #endregion

        #region Constructor

        public IndustrialCoreTestResultModel(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            int result,
            double correctedWatts,
            double currentPercentage,
            IReadOnlyCollection<int>? warnings,
            int totalCores,
            int testedCores,
            int totalTests)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            CoreSize = coreSize;
            FoilWidth = foilWidth;
            TestCode = testCode;
            Result = result;
            CorrectedWatts = correctedWatts;
            CurrentPercentage = currentPercentage;

            this.warnings = new HashSet<int>();

            if (warnings != null)
            {
                foreach (int item in warnings)
                {
                    this.warnings.Add(item);
                }
            }

            TotalCores = totalCores;
            TestedCores = testedCores;
            TotalTests = totalTests;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int CoreSize { get; set; }

        public double FoilWidth { get; set; }

        public string TestCode { get; set; }

        public int Result { get; init; }

        public double CorrectedWatts { get; init; }

        public double CurrentPercentage { get; init; }
        
        public IReadOnlyCollection<int> Warnings => warnings;

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}