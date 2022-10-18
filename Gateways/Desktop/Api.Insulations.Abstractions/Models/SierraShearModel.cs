namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    public class SierraShearModel
    {
        #region Constructor

        public SierraShearModel()
        {
            DesignId = "NoDesignId";
            Description = "NoDescription";
        }

        #endregion

        #region Properties

        public string DesignId { get; set; }

        public string? Item { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double? L { get; set; }

        public double? A { get; set; }

        public double? B { get; set; }

        public double? Y { get; set; }

        public double? T { get; set; }

        public string? Dimensions { get; set; }

        public string? Fold { get; set; }

        #endregion
    }
}