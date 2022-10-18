namespace ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RefreshPrintableAttributesParameterModel
    {
        #region Constructor

        public RefreshPrintableAttributesParameterModel()
        {
            PrintableAttributes = new();
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(47)]
        public string ItemId { get; set; } = null!;

        [Required]
        [StringLength(3)]
        public string Batch { get; set; } = null!;

        [Required]
        public int Serie { get; set; }

        [Required]
        public List<MOPrintableAttributeParameterModel> PrintableAttributes { get; set; }

        #endregion
    }

    public class MOPrintableAttributeParameterModel
    {
        #region Properties

        [Required]
        public string Attribute { get; set; } = null!;

        public string? Value { get; set; }

        #endregion
    }
}