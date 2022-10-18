namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResidentialSuppliedCoreTestModel
    {
        #region Constructor


        [System.Text.Json.Serialization.JsonConstructor]
        public ResidentialSuppliedCoreTestModel(
            string itemId,
            string batch,
            int serie,
            int sequence,
            string identifier,
            double wattscorr,
            int color,
            DateTime supplyUtcDate,
            Guid id,
            string tag)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Identifier = identifier;
            WattsCorr = wattscorr;
            //Color = (CoreLimitColor)color;
            Color = color;
            SupplyUtcDate = supplyUtcDate;
            Id = id;
            Tag = tag;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; private set; }

        public string Identifier { set; get; }

        public double WattsCorr { set; get; }

        public int Color { get; set; }

        public DateTime SupplyUtcDate { get; set; }

        public Guid Id { get; private set; }

        public string Tag { get; set; }

        #endregion
    }
}
