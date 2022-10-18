namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ProlecGE.ControlPisoMX.Cores.Models;

    public class TestResidentialCoreCommand
    {
        #region Constructor
       
        public TestResidentialCoreCommand(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(designId))
            {
                throw new UserException("El identificador del diseño del artículo no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(testCode))
            {
                throw new UserException("El identificador de la prueba no puede ser vacío o espacios en blanco.");
            }

            ItemId = itemId.Trim();
            DesignId = designId.Trim();
            CoreSize = coreSize;
            KVA =kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            Limits = limits;
            Tag = tag;
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

        [StringLength(8)]
        public string? Tag { get; private set; }

        [Required]
        [StringLength(47)]
        public string ItemId { get; private set; }

        [Required]
        [StringLength(47)]
        public string DesignId { get; private set; }

        [Required]
        public int CoreSize { get; private set; }

        public double? KVA { get; private set; }

        public double PrimaryVoltage { get; private set; }

        public double? SecondaryVoltage { get; private set; }

        public double? TestVoltage { get; private set; }

        public IEnumerable<ItemVoltageLimitModel> Limits { get; private set; }

        public double AverageVoltage { get; private set; }

        public double RMSVoltage { get; private set; }

        public double Current { get; private set; }

        public double Temperature { get; private set; }

        public double Watts { get; private set; }

        public double CoreTemperature { get; private set; }

        [Required]
        [StringLength(8)]
        public string TestCode { get; private set; }

        public string? StationId { get; private set; }

        #endregion
    }
}