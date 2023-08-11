namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TestIndustrialCoreParameterModel
    {
        #region Constructor

        public TestIndustrialCoreParameterModel() { }

        public TestIndustrialCoreParameterModel(
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
        [StringLength(47)]
        public string? ItemId { get; set; }

        [Required]
        [StringLength(3)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "No se admiten caracteres especiales")]
        public string? Batch { get; set; }

        [Required]
        public int Serie { get; set; }

        [Required]
        public int CoreSize { get; set; }

        [Required]
        public double FoilWidth { get; set; }

        [Required]
        [StringLength(8)]
        public string? TestCode { get; set; }

        public double AverageVoltage { get; set; }

        public double RMSVoltage { get; set; }

        public double Current { get; set; }

        public double Temperature { get; set; }

        public double Watts { get; set; }

        public double CoreTemperature { get; set; }

        [StringLength(5)]
        public string? StationId { get; set; }

        public string? IdSub { get; set; }

        #endregion
    }
}