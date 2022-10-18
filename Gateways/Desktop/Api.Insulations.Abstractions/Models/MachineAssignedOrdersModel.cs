namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    public class MachineAssignedOrdersModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public MachineAssignedOrdersModel(string number, int summary, bool available)
        {
            Number = number;
            Summary = summary;
            Available = available;
        }

        #endregion

        #region Properties

        public string Number { get; set; }

        public int Summary { get; set; }

        public bool Available { get; set; }

        #endregion
    }
}