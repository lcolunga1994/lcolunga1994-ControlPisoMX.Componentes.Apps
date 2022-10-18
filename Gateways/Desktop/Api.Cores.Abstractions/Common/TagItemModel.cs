namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models
{
    public class TagItemModel
    {

        public TagItemModel(string itemId, string batch, int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        public string ItemId { set; get; }

        public string Batch { set; get; }

        public int Serie { set; get; }
    }
}
