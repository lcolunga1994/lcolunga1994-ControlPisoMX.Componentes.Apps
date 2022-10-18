namespace ProlecGE.ControlPisoMX.Cores.Models.InspectionCMS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LastRejectedModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public LastRejectedModel(
            DateTime rejectDate,
            string description)
        {
            RejectDate = rejectDate;
            Description = description;
        }

        #endregion

        #region Properties

        public DateTime RejectDate { get; set; }

        public string Description { get; set; }

        #endregion
    }
}
