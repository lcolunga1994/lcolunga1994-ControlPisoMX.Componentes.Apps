namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddSupplyCoreModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public AddSupplyCoreModel(
            string itemId,
            string batch,
            int serie,
            string testCode,
            string user)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            TestCode = testCode;
            User = user;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(47)]
        public string ItemId { get; set; }

        [Required]
        [StringLength(3)]
        public string Batch { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required]
        [StringLength(16)]
        public string TestCode { get; set; }

        [Required]
        [StringLength(256)]
        public string User { get; set; }

        #endregion
    }
}
