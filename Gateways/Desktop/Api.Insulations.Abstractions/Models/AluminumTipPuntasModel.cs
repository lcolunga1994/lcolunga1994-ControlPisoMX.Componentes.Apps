namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations.Models
{
    using System.Collections.Generic;

    public class AluminumTipPuntasModel
    {
        #region Constructor

        public AluminumTipPuntasModel()
        {
            PuntasIni = new AluminumTipModel();
            PuntasFin = new AluminumTipModel();
            Materials = new List<AluminumShearModel>();
        }

        #endregion

        #region Properties

        public AluminumTipModel PuntasIni { get; set; }

        public AluminumTipModel PuntasFin { get; set; }

        public IEnumerable<AluminumShearModel> Materials { set; get; }

        #endregion
    }

    public class AluminumTipModel
    {
        #region Constructor

        public AluminumTipModel()
        {
            BTI = new List<string>();
            BTE = new List<string>();
        }

        #endregion

        #region Properties

        public IEnumerable<string> BTI { get; set; }

        public IEnumerable<string> BTE { get; set; }

        #endregion
    }

    public class AluminumShearModel
    {
        #region Constructor

        public AluminumShearModel()
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

        public double? T { get; set; }

        public string? Dimensions { get; set; }

        #endregion
    }
}
