namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    public class MOSupplyItemTagModel
    {
        #region Attributes

        public static string Diameter = nameof(Diameter);
        public static string Strip = nameof(Strip);
        public static string Laps = nameof(Laps);
        public static string ScheduledEndDate = nameof(ScheduledEndDate);
        public static string Market = nameof(Market);

        #endregion

        #region Constructor

        public MOSupplyItemTagModel()
        {
            Attributes = new List<MOSupplyItemPrintableAttributeModel>();
        }

        #endregion

        #region Properties

        public string ItemId { set; get; } = null!;

        public string Batch { set; get; } = null!;

        public int Serie { set; get; }

        public int Sequence { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string Machine { get; set; } = null!;

        public int ProductLine { get; set; }

        public int Line { get; set; }

        public List<MOSupplyItemPrintableAttributeModel> Attributes { get; set; }

        #endregion
    }

    public class MOSupplyItemPrintableAttributeModel
    {
        #region Properties

        public string Attribute { get; set; } = null!;

        public string? Value { get; set; }

        #endregion
    }
}