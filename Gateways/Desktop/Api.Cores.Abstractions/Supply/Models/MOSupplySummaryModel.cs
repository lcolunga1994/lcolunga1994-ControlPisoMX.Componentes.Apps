namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MOSupplySummaryModel
    {
        #region Properties

        public MOSupplySummaryModel()
        {
            Orders = new List<MOSupplyItemStatusModel>();
        }

        #endregion

        #region Properties

        public string ItemId { get; set; } = null!;

        public string Batch { get; set; } = null!;

        public int Quantity { get; set; }

        public int SuppliedQuantity => Orders.Count();

        public int PendingQuantity => Quantity - SuppliedQuantity;

        public IEnumerable<MOSupplyItemStatusModel> Orders { get; set; }

        #endregion
    }

    public class MOSupplyItemStatusModel
    {
        #region Properties

        public string ItemId { get; set; } = null!;

        public string Batch { get; set; } = null!;

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public DateTime? SuppliedUtcDate { get; set; }

        public bool Confirmed { get; set; }

        #endregion
    }
}