namespace ProlecGE.ControlPisoMX.Cores.Models.Residential
{
    using System;

    public class ResidentialCoreTestModel
    {
        #region Constructor

        public ResidentialCoreTestModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            string tag,
            string testCode,
            int status,
            double correctedWatts,
            double newWatts,
            double current,
            double currentPercentage,
            int color,
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
            Sequence = sequence;
            Tag = tag;
            TestCode = testCode;
            Status = status;
            CorrectedWatts = correctedWatts;
            NewWatts = newWatts;
            Current = current;
            CurrentPercentage = currentPercentage;
            Color = color;
            TotalCores = totalCores;
            TestedCores = testedCores;
            TotalTests = totalTests;
            CoreSizes = coreSizes;
            Location = location;
            AssociatedCore = associatedCore;
            Id = id;
            TestUtcDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; private set; }

        public string Tag { get; set; }

        public string TestCode { get; set; }

        public int Status { get; }

        public double CorrectedWatts { get; set; }

        public double NewWatts { get; set; }

        public double Current { get; set; }

        public double CurrentPercentage { get; set; }

        public int Color { get; set; }

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        public int? CoreSizes { get; set; }

        public string? Location { get; private set; }

        public string? AssociatedCore { get; private set; }

        public Guid Id { get; private set; }

        public DateTime? TestUtcDate { set; get;}

        #endregion
    }
}