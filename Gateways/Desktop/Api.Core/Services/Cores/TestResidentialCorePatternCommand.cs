namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TestResidentialCorePatternCommand
    {
        #region Constructor

        public TestResidentialCorePatternCommand(
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
        public string TestCode { get; }

        [Required]
        public double AverageVoltage { get; }

        [Required]
        public double RMSVoltage { get; }

        [Required]
        public double Current { get; }

        [Required]
        public double Temperature { get; }

        [Required]
        public double Watts { get; }

        [Required]
        public double CoreTemperature { get; }

        [StringLength(5)]
        public string? StationId { get; }

        #endregion
    }
}