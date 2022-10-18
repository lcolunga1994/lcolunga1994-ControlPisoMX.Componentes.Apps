namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models
{
    using System;

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
