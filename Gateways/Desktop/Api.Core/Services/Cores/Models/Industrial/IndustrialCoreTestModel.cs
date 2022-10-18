namespace ProlecGE.ControlPisoMX.Cores.Models
{
    using System;

    public class IndustrialCoreTestModel
    {
        #region Constructor

        public IndustrialCoreTestModel(
            string itemId,
            string batch,
            int serie,
            string testCode,
            int result,
            double correctedWatts,
            double currentPercentage,
            int totalCores,
            int testedCores,
            int totalTests,
            int? coreSizes,
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

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public string TestCode { get; set; }

        public int Result { get; init; }

        public double CorrectedWatts { get; init; }

        public double CurrentPercentage { get; init; }

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        public int? CoreSizes { get; set; }

        public string? Location { get; private set; }

        public string? AssociatedCore { get; private set; }

        public Guid Id { get; private set; }

        #endregion
    }
}