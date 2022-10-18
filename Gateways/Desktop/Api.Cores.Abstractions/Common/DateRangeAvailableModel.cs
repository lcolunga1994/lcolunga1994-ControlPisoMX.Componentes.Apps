namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models
{
    using System;

    public class DateRangeAvailableModel
    {
        #region Constructor

        public DateRangeAvailableModel(int productLine, DateTime startUtcDate, DateTime endUtcDate)
        {
            ProductLine = productLine;
            StartUtcDate = startUtcDate;
            EndUtcDate = endUtcDate;
        }

        #endregion

        #region Properties

        public int ProductLine { get; set; }

        public DateTime StartUtcDate { get; set; }

        public DateTime EndUtcDate { get; set; }

        #endregion
    }
}