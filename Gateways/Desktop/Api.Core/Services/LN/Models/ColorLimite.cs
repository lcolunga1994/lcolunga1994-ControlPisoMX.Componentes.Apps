using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models
{
    public class ColorLimite
    {
        public ColorLimite(CoreLimitColor color)
        {
            Color = color;
        }
        public ColorLimite(
            CoreLimitColor color,
            double min,
            double max) : this(color)
        {
            Min = min;
            Max = max;
        }


        public CoreLimitColor Color { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }
    }
}
