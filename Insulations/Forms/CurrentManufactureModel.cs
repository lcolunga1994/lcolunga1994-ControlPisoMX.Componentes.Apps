namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    internal class CurrentManufactureModel
    {
        #region Constructor

        public CurrentManufactureModel()
        {
            ItemId = "itemId";
            Batch = "batch";
            Machine = "machine";
            StartUtcDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Quantity { get; set; }

        public string Machine { get; set; }

        public DateTime StartUtcDate { get; set; }

        #endregion
    }
}