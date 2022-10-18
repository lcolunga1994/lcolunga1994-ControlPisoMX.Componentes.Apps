namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Models;

    public static class Utils
    {
        public static string GetProductLineName(ProductLine productLine) => productLine switch
        {
            ProductLine.Poste => "POSTE",
            ProductLine.Pedestal => "PEDESTAL",
            _ => "Desconocida",
        };
    }
}