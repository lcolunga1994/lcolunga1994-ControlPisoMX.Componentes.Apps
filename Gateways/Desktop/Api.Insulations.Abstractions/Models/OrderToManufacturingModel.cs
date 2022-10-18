namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    public class OrderToManufacturingModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public OrderToManufacturingModel(string itemId, string batch, int serie, int sequence)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public CoreTestColor CoreTestColor { get; set; }

        #endregion
    }
}