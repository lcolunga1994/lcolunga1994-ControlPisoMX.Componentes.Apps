namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models
{
    using System;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class IndustrialCoreTestModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public IndustrialCoreTestModel(
            string? itemId,
            string? batch,
            int? serie,
            string? testCode,
            CoreTestResult result,
            double correctedWatts,
            double currentPercentage,
            int totalCores,
            int testedCores,
            int totalTests,
            CoreSizes? coreSizes,
            string? location,
            string? associatedCore,
            Guid id)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            TestCode = testCode;
            Result = result;
            CorrectedWatts = correctedWatts;
            CurrentPercentage = currentPercentage;
            TotalCores = totalCores;
            TestedCores = testedCores;
            TotalTests = totalTests;
            CoreSizes = coreSizes;
            Location = location;
            AssociatedCore = associatedCore;
            Id = id;
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

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        public CoreSizes? CoreSizes { get; set; }

        public string? Location { get; private set; }

        public string? AssociatedCore { get; private set; }

        public Guid Id { get; private set; }

        #endregion
    }
}