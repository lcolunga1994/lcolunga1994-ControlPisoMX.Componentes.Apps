namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    public class InsulationMachineModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public InsulationMachineModel(string number, bool available)
        {
            Number = number;
            Available = available;
        }

        #endregion

        #region Properties

        public string Number { get; set; }

        public bool Available { get; set; }

        #endregion
    }
}