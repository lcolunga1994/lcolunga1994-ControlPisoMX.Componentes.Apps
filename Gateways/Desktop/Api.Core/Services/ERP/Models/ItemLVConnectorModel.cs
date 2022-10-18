namespace ProlecGE.ControlPisoMX.ERP.Models
{
    public class ItemLVConnectorModel
    {
        #region Properties

        public string ItemId { get; set; }

        public string Description { get; set; }

        #endregion

        #region Constructor

        public ItemLVConnectorModel(string itemId, string description)
        {
            ItemId = itemId;
            Description = description;
        }

        #endregion
    }
}
