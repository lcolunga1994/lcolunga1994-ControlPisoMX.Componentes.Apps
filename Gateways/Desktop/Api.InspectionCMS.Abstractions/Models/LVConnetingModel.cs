namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models
{
    public class LVConnetingModel
    {
        public string Polarity { get; set; } = null!;

        public List<PositionModel> Position { get; set; } = new List<PositionModel>();
    }

    public class PositionModel
    {
        public string PositionName { get; set; } = null!;

        public double Voltage { get; set; } 

        public double Nominal { get; set; } 

        public double Max { get; set; }

        public double Min { get; set; }
    }
}
