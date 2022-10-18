namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models
{
    public class ItemModel
    {
        #region Fields

        private string itemId;
        private string designId;
        private string? ctyp;
        private string? citg;
        private string? polarity;

        #endregion

        #region Constructor

        public ItemModel(string itemId, string designId, int phases, ProductLine productLine)
        {
            this.itemId = itemId;
            this.designId = designId;
            Phases = phases;
            ProductLine = productLine;
        }

        #endregion

        #region Properties

        public string ItemId
        {
            get => itemId.Trim();
            set => itemId = value;
        }

        public string DesignId
        {
            get => designId.Trim();
            set => designId = value;
        }

        public string? CTyp
        {
            get => ctyp?.Trim();
            set => ctyp = value;
        }

        public string? Citg
        {
            get => citg?.Trim();
            set => citg = value;
        }

        public string? Polarity
        {
            get => polarity?.Trim();
            set => polarity = value;
        }

        public int Phases { get; set; }

        public ProductLine ProductLine { get; set; }

        #endregion
    }
}