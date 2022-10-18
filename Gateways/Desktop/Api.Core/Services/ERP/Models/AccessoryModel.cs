namespace ProlecGE.ControlPisoMX.ERP.Models
{
    public class AccessoryModel
    {
        #region Properties

        public string Component { get; set; }

        public string ItemId { get; set; }

        public string Item { get; set; }

        public double Quantity { get; set; }

        #endregion

        #region Constructor

        //public AccessoryModel() { }

        public AccessoryModel(string component, string itemId, string item, double quantity)
        {
            if (string.IsNullOrEmpty(component))
            {
                throw new System.ArgumentException($"'{nameof(component)}' cannot be null or empty.", nameof(component));
            }

            if (string.IsNullOrEmpty(itemId))
            {
                throw new System.ArgumentException($"'{nameof(itemId)}' cannot be null or empty.", nameof(itemId));
            }

            if (string.IsNullOrEmpty(item))
            {
                throw new System.ArgumentException($"'{nameof(item)}' cannot be null or empty.", nameof(item));
            }

            Component = component.Trim();
            ItemId = itemId.Trim();
            Item = item.Trim();
            Quantity = quantity;
        }

        #endregion
    }
}