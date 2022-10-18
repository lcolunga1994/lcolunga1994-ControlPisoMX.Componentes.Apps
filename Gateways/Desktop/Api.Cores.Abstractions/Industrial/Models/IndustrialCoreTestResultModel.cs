namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models
{
    using System.Collections.Generic;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class IndustrialCoreTestResultModel
    {
        #region Fields

        private readonly HashSet<CoreTestWarning> warnings;

        #endregion

        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public IndustrialCoreTestResultModel(
            string? itemId,
            string? batch,
            int? serie,
            string? testCode,
            CoreTestResult result,
            double correctedWatts,
            double currentPercentage,
            IReadOnlyCollection<CoreTestWarning> warnings,
            int totalCores,
            int testedCores,
            int totalTests,
            CoreSizes? coreSizes)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            TestCode = testCode;
            Result = result;
            CorrectedWatts = correctedWatts;
            CurrentPercentage = currentPercentage;

            this.warnings = new HashSet<CoreTestWarning>();

            if (warnings != null)
            {
                foreach (CoreTestWarning item in warnings)
                {
                    this.warnings.Add(item);
                }
            }

            TotalCores = totalCores;
            TestedCores = testedCores;
            TotalTests = totalTests;
            CoreSizes = coreSizes;
        }

        #endregion

        #region Properties

        public string? ItemId { get; set; }

        public string? Batch { get; set; }

        public int? Serie { get; set; }

        public string? TestCode { get; set; }

        public CoreTestResult Result { get; }

        public double CorrectedWatts { get; set; }

        public double CurrentPercentage { get; set; }

        public IReadOnlyCollection<CoreTestWarning> Warnings => warnings;

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        public CoreSizes? CoreSizes { get; set; }

        #endregion
    }
}