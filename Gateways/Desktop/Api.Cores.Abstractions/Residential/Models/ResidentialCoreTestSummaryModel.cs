﻿namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;

    public class ResidentialCoreTestSummaryModel
    {
        #region Constructor

        public ResidentialCoreTestSummaryModel(
            string itemId,
            string batch,
            int serie,
            int sequence)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Serie = serie;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        #endregion
    }
}