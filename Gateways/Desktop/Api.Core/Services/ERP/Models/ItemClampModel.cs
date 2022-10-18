namespace ProlecGE.ControlPisoMX.ERP.Models
{
    public class ItemClampModel
    {
        #region Properties

        public string ItemId { get; set; } = null!;

        public string DesignId { get; set; } = null!;

        public string Place { get; set; } = null!;

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

        public int Revision { set; get; }

        #endregion
    }
}