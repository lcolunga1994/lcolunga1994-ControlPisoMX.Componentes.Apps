namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MachineAssignedOrdersModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public MachineAssignedOrdersModel(string number, int summary)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new System.UserException("El número de la maquina no puede ser nulo o vacío");
            }
            else
            {
                Number = number.Trim();
            }

            Summary = summary;
        }

        #endregion

        #region Properties

        public string Number { get; set; }

        public int Summary { get; set; }

        #endregion

    }
}
