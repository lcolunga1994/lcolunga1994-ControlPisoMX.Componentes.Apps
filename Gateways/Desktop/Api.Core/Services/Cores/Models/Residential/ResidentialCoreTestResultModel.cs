namespace ProlecGE.ControlPisoMX.Cores.Models
{
    using System;
    using System.Collections.Generic;

    public class ResidentialCoreTestResultModel
    {
        #region Fields

        private readonly HashSet<int> warnings;

        #endregion

        #region Constructor

        public ResidentialCoreTestResultModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            int productLine,
            string testCode,
            int status,
            double correctedWatts,
            double newWatts,
            double currentPercentage,
            int color,
            IReadOnlyCollection<int>? warnings,
            int totalCores,
            int testedCores,
            int totalTests)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

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

        public string TestCode { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public int ProductLine { get; set; }

        public int Status { get; }

        public double CorrectedWatts { get; set; }

        public double NewWatts { get; set; }

        public double CurrentPercentage { get; set; }

        public int Color { get; set; }

        public IReadOnlyCollection<int> Warnings => warnings;

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}