
namespace ProlecGE.ControlPisoMX.Cores.Models.Residential
{
    using System;

    public class ResidentialSuppliedCoreTestModel
    {
        #region Constructor

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

        public int CoreIndex { set; get; }

        #endregion
    }
}