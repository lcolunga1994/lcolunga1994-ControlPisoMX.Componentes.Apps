namespace ProlecGE.ControlPisoMX.BFWeb.Components.Models
{
    public class OrderWithClampsModel
    {
        #region Properties

        public string ItemId { get; set; } = null!;

        public string Batch { get; set; } = null!;

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public ItemClampModel? Top { get; set; } = null!;

        public ItemClampModel? Bottom { get; set; } = null!;

        public string Machine { get; set; } = null!;

        public string? Notes { get; set; }

        public ProductLine ProductLine { get; set; }

        public string Market { set; get; } = null!;

        #endregion
    }

    public class ItemClampModel
    {
        #region Properties

        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public double D { get; set; }

        public double? E { get; set; }

        public double F { get; set; }

        public double G { get; set; }

        public double H { get; set; }

        public double J { get; set; }

        public double K { get; set; }

        public double L { get; set; }

        public double T { get; set; }

        public double X { get; set; }

        public string DrawId { get; set; } = null!;

        #endregion
    }
}
