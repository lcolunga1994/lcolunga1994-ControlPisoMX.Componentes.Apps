namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores
{
    public enum CoreTestResult
    {
        Failed = 0,
        Passed = 1
    }

    public enum ProductLine
    {
        Desconocida = 0,
        Poste = 1,
        Pedestal = 2
    }

    public enum CoreSizes
    {
        Small = 0,
        Big = 1
    }

    public enum CoreTestError
    {
        NoError = 0,
        HighTemperature = 1,
        NoAverageVoltage = 2,
        NoCurrent = 3,
        NoKVA = 4,
        NoSecondaryVoltage = 5
    }

    public enum CoreTestWarning
    {
        NoCoreTemp = 0,
        HighCoreTemperature = 1,
        Repeat = 2,
        NoCurrentPercentageCalculated
    }

    public enum CoreLimitColor
    {
        None = 0,
        Blue = 1,
        Green = 2,
        Yellow = 3,
        Red = 4
    }

    public enum SystemErrorCode
    {
        InternalServerError = 500,
        GeneralError = 401,

        //Core
        DesignNotFound = 1201,
        HighTemperature = 1202,
        NoAverageVoltage = 1203,
        NoCurrent = 1204,
        NoKVA = 1205,
        NoSecondaryVoltage = 1206,
        PartialDesignNotFound = 1207,
        ManufacturingPlanNotFound = 1210,
        SupplyCoreCombination=1212
    }

    public enum OrderSupplyErrorCode
    {
        NotSupplied = 0,
        NotFound = 1
    }

    public enum InsulationsState
    {
        Pending = 0,
        InProgress = 1,
        Cancelled = 2,
        Finished = 3
    }
}