namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RemoveSupplyCoreModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public RemoveSupplyCoreModel(
            Guid id)
        {
            Id = id;
        }

        #endregion

        #region Properties

        [Required]
        public Guid Id { set; get; }

        #endregion
    }
}
