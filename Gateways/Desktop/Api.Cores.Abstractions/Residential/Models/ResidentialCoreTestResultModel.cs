namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;
    using System.Collections.Generic;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    public class ResidentialCoreTestResultModel
    {
        #region Fields

        private readonly HashSet<CoreTestWarning> warnings;

        #endregion

        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public ResidentialCoreTestResultModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            ProductLine productLine,
            string testCode,
            CoreTestResult status,
            double correctedWatts,
            double newWatts,
            double currentPercentage,
            CoreLimitColor color,
            IReadOnlyCollection<CoreTestWarning> warnings,
            int totalCores,
            int testedCores,
            int totalTests)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            ProductLine = productLine;
            TestCode = testCode;
            Status = status;
            CorrectedWatts = correctedWatts;
            NewWatts = newWatts;
            CurrentPercentage = currentPercentage;
            Color = color;

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
        }

        #endregion

        #region Properties

        public string TestCode { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public ProductLine ProductLine { get; set; }

        public CoreTestResult Status { get; }

        public double CorrectedWatts { get; set; }

        public double NewWatts { get; set; }

        public double CurrentPercentage { get; set; }

        public CoreLimitColor Color { get; set; }

        public IReadOnlyCollection<CoreTestWarning> Warnings => warnings;

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}