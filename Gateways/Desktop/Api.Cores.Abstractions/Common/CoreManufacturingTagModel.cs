namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models
{
    using System;

    public class CoreManufacturingTagModel
    {
        #region Constructor

        public CoreManufacturingTagModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            DateTime scheduledDate,
            string machine,
            ProductLine productLine,
            int line,
            string? strip,
            string? dimensions,
            string? market,
            string? laps,
            string? scheduledEndDate)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            ScheduledDate = scheduledDate;
            Machine = machine;
            ProductLine = productLine;
            Line = line;
            Strip = strip;
            Dimensions = dimensions;
            Market = market ?? "";
            Pilot = laps;

            if (!string.IsNullOrWhiteSpace(scheduledEndDate))
            {
                if (DateTime.TryParseExact(scheduledEndDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AssumeUniversal, out DateTime scheduledEndDateTime))
                {
                    ScheduledEndDate = scheduledEndDateTime;
                }
            }

            DayOfWeek day = ScheduledDate.DayOfWeek;

            if (ProductLine == ProductLine.Poste)
            {
                day = (day == DayOfWeek.Sunday) ? DayOfWeek.Tuesday : ScheduledDate.AddDays(1).DayOfWeek;
            }
            else
            {
                day = (day == DayOfWeek.Sunday) ? DayOfWeek.Wednesday : ScheduledDate.AddDays(2).DayOfWeek;
            }

            DayColor = day switch
            {
                DayOfWeek.Monday => " ",
                DayOfWeek.Tuesday => "violeta",
                DayOfWeek.Wednesday => "naranja",
                DayOfWeek.Thursday => "amarillo",
                DayOfWeek.Friday => "verde",
                DayOfWeek.Saturday => "blanco",
                DayOfWeek.Sunday => "azul",
                _ => " "
            };            

            PrintDate = DateTime.Now;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string Machine { get; set; }

        public ProductLine ProductLine { set; get; }

        public int Line { set; get; }

        public string? Strip { set; get; }

        public string? Dimensions { get; set; }

        public string Market { get; set; }

        public string? Pilot { get; set; }

        public DateTime? ScheduledEndDate { get; set; }

        public string DayColor { get; }

        public DateTime PrintDate { get; }

        #endregion
    }
}