namespace ProlecGE.ControlPisoMX.Cores.Testing.Industrial.Forms
{
    using System;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Models;

    internal class CoreModel
    {
        #region Properties

        public string? ItemId { get; set; }

        public string? Batch { get; set; }
        
        public int Serie { get; set; }

        public CoreSizes? Size { get; set; }

        public double FoilWidth { get; set; }

        public IndustrialItemVoltageDesignModel? VoltageDesign { get; set; }

        #endregion
    }

    internal class IndustrialItemTestSummaryModel
    {
        #region Constructor

        public IndustrialItemTestSummaryModel(string itemId, string batch, int serie)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
        }

        public IndustrialItemTestSummaryModel(
            string itemId,
            string batch,
            int serie,
            CoreSizes coreSize)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            CoreSize = coreSize;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public CoreSizes CoreSize { get; set; }

        public double FoilWidth { get; set; }

        public DateTime? ScheduledDate { get; set; }

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        public int TotalTests { get; set; }

        #endregion
    }
}