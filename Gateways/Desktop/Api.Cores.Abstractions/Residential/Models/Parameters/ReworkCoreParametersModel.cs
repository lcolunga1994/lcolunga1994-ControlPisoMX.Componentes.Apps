namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReworkCoreParametersModel
    {
        #region Constructor

        public ReworkCoreParametersModel(
            string itemId,
            int coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId)
        {
            ItemId = itemId.Trim();
            CoreSize = coreSize;
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
            CoreTemperature = coreTemperature;
            TestCode = testCode.Trim();
            StationId = stationId;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(47)]
        public string ItemId { get; }

        [Required]
        public int CoreSize { get; }

        public double AverageVoltage { get; }

        public double RMSVoltage { get; }

        public double Current { get; }

        public double Temperature { get; }

        public double Watts { get; }

        public double CoreTemperature { get; }

        [Required]
        [StringLength(8)]
        public string TestCode { get; }

        public string? StationId { get; }

        #endregion
    }
}