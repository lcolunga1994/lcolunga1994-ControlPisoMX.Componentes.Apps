namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TestIndustrialCorePatternParameterModel
    {
        #region Constructor

        public TestIndustrialCorePatternParameterModel() { }

        public TestIndustrialCorePatternParameterModel(
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId)
        {
            TestCode = testCode;
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
            CoreTemperature = coreTemperature;
            StationId = stationId;
        }

        #endregion

        #region Properties

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

        #endregion
    }
}