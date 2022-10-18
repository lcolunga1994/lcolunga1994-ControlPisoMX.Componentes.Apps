namespace ProlecGE.ControlPisoMX.Cores.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ProlecGE.ControlPisoMX.Cores.Models;

    public class ReworkResidentialCoreCommand
    {
        #region Constructor

        public ReworkResidentialCoreCommand(
            string itemId,
            string designId,
            int productLine,
            int phases,
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
            ProductLine = productLine;
            Phases = phases;
            CoreSize = coreSize;
            KVA = kva;
            PrimaryVoltage = primaryVoltage;
            SecondaryVoltage = secondaryVoltage;
            TestVoltage = testVoltage;
            Limits = limits;
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
        [StringLength(47)]
        public string DesignId { get; private set; }

        [Required]
        public int CoreSize { get; }

        [Required]
        public int ProductLine { get; set; }

        [Required]
        public int Phases { get; set; }

        public double? KVA { get; private set; }

        public double PrimaryVoltage { get; private set; }

        public double? SecondaryVoltage { get; private set; }

        public double? TestVoltage { get; private set; }

        public IEnumerable<ItemVoltageLimitModel> Limits { get; private set; }

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