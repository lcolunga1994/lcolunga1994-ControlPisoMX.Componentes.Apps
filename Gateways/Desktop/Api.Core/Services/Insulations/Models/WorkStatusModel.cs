namespace ProlecGE.ControlPisoMX.Insulations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WorkStatusModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public WorkStatusModel(bool status)
        {
            Status = status;
        }

        #endregion

        #region Properties
        public bool Status { get; set; }

        #endregion

    }
}
