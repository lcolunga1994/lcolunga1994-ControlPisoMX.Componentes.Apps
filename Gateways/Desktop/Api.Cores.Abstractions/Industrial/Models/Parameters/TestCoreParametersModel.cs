namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TestCoreParametersModel
    {
        #region Constructor

        public TestCoreParametersModel(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId,
            string? idSub)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            CoreSize = coreSize;
            FoilWidth = foilWidth;
            TestCode = testCode;
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
            CoreTemperature = coreTemperature;
            StationId = stationId;
            IdSub = idSub;
        }

        #endregion

        #region Properties

        [Required]
        public string ItemId { get; set; }

        [Required]
        public string Batch { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required]
        public int CoreSize { get; set; }

        [Required]
        public double FoilWidth { get; set; }

        [Required]
        public string TestCode { get; set; }

        [Required]
        public double AverageVoltage { get; set; }

        [Required]
        public double RMSVoltage { get; set; }

        [Required]
        public double Current { get; set; }

        [Required]
        public double Temperature { get; set; }

        [Required]
        public double Watts { get; set; }

        [Required]
        public double CoreTemperature { get; set; }

        public string? StationId { get; set; }

        public string? IdSub { get; set; }

        #endregion
    }
}