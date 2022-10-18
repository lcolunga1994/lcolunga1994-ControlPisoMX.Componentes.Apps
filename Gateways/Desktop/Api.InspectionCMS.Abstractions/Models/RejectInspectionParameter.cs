namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models
{
    public class RejectInspectionParameter
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public RejectInspectionParameter(string itemId, string batch, int serie, string machine, string user, string card, string code)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Machine = machine;
            User = user;
            Card = card;
            Code = code;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { set; get; }

        public string Machine { set; get; }

        public string User { set; get; }

        public string Card { set; get; }

        public string Code { set; get; }

        #endregion
    }
}
