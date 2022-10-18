namespace ProlecGE.ControlPisoMX.BFWeb.Components.Insulations
{
    public enum CoreTestColor
    {
        None = 0,
        Blue = 1,
        Green = 2,
        Yellow = 3,
        Red = 4
    }

    public static class EnumExtensions
    {
        public static CoreTestColor ToLimitColorValue(this int coreLimitColor)
        {
            return (CoreTestColor)coreLimitColor;
        }
    }

    public enum InsulationsState
    {
        Pending = 0,
        InProgress = 1,
        Cancelled = 2,
        Finished = 3
    }
}