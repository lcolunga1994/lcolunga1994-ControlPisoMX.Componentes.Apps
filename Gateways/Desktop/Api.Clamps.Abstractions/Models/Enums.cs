namespace ProlecGE.ControlPisoMX.BFWeb.Components.Models
{
    using System;

    public enum ProductLine
    {
        Desconocida = 0,
        Poste = 1,
        Pedestal = 2
    }

    public static class EnumExtensions
    {
        public static ProductLine ToProductLineValue(this int productLine)
            => (ProductLine)productLine;
    }
}