namespace ProlecGE.ControlPisoMX.Gateways.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddOrderToManufacturingModel
    {
        #region Constructor

        public AddOrderToManufacturingModel(string itemid, string batch, string serie, string sequence)
        {
            ItemId = itemid;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public string Serie { get; set; }

        public string Sequence { get; set; }

        #endregion
    }
}
