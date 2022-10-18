namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System;

    public class MOSupplyItemModel
    {
        #region Properties

        public Guid Id { get; set; }

        public string ItemId { get; set; } = null!;

        public string Batch { get; set; } = null!;

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public DateTime ScheduleDate { get; set; }

        public string Machine { get; set; } = null!;

        public int ProductLine { get; set; }

        public int Phases { get; set; }

        public int Line { get; set; }

        public DateTime RegisterUtcDate { get; set; }

        #endregion
    }
}