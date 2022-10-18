namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Domain.Entities
{
    public class Setting
    {
        #region Keys

        public static string ResidentialInternalErrorContact => nameof(ResidentialInternalErrorContact);

        public static string ResidentialMissingItemDesignContact => nameof(ResidentialMissingItemDesignContact);

        public static string ResidentialMissingCoreManufacturingPlanContact => nameof(ResidentialMissingCoreManufacturingPlanContact);

        public static string IndustrialInternalErrorContact => nameof(IndustrialInternalErrorContact);

        public static string IndustrialMissingItemDesignContact => nameof(IndustrialMissingItemDesignContact);

        public static string IndustrialMissingCoreManufacturingPlanContact => nameof(IndustrialMissingCoreManufacturingPlanContact);

        #endregion

        #region Constructor

        protected Setting()
        {
            Name = "NoName";
            Value = "NoValue";
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        /// <param name="storeId">Store identifier</param>
        public Setting(string name, string value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>Result</returns>
        public override string ToString() => Name;

        #endregion
    }
}