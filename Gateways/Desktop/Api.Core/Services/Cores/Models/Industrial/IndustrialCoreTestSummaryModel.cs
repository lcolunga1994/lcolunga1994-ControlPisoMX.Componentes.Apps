namespace ProlecGE.ControlPisoMX.Cores.Models
{
    public class IndustrialCoreTestSummaryModel
    {
        #region Constructor

        public IndustrialCoreTestSummaryModel(
            string itemId,
            string batch,
            int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        #endregion

        #region Properties

        public string? TestCode { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        #endregion
    }
}