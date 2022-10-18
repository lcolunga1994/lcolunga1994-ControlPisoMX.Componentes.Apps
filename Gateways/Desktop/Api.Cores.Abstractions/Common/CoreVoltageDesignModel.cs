namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CoreVoltageDesignModel
    {
        #region Properties

        public string DesignId { get; set; }

        public double? KVA { get; set; }

        public double? PrimaryVoltage { get; set; }

        public double? SecondaryVoltage { get; set; }

        public double? TestVoltage { get; set; }

        public IEnumerable<CoreVoltageLimitModel> Limits { get; set; }

        #endregion

        #region Constructor

        public CoreVoltageDesignModel(string designId)
        {
            DesignId = designId;
            Limits = Array.Empty<CoreVoltageLimitModel>();
        }

        #endregion

        #region Methods

        public void SetLimits(IEnumerable<CoreVoltageLimitModel>? limits)
        {
            if (limits != null)
            {
                Limits = limits.ToArray();
            }
        }

        #endregion
    }
}