namespace ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders
{
    using System;

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