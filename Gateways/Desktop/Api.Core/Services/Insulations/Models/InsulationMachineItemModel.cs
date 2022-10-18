namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    public class InsulationMachineModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public InsulationMachineModel(string number,bool available)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new System.UserException("El número de la maquina no puede ser nulo o vacío");
            }
            else
            {
                Number = number.Trim();
            }

            Available = available;
        }

        #endregion

        #region Properties

        public string Number { get; set; }

        public bool Available { get; set; }

        #endregion

    }
}
