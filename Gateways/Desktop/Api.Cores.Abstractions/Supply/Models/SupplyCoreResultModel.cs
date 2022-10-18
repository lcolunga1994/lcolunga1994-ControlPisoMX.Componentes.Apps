namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models
{
    using System;
    using System.Collections.Generic;

    public class SupplyCoreResultModel
    {

        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public SupplyCoreResultModel(
            string itemId,
            string batch,
            int serie,
            SupplyCoresValidationModel? supplyValidationResult,
            MOSupplyItemTagModel? printable
            )
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;

            SupplyValidationResult = supplyValidationResult;

            Printable = printable;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public SupplyCoresValidationModel? SupplyValidationResult { get; set; }

        public MOSupplyItemTagModel? Printable { set; get; }

        #endregion
    }

    public class SupplyCoresValidationModel
    {

        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public SupplyCoresValidationModel(int phases, int coreNumber, List<CoreValidationModel> validation, bool isPhasesRuleValid,
            bool isCoreColorRuleValid, bool accomplished, string message)
        {
            Phases = phases;
            CoreNumber = coreNumber;
            Validation = validation;
            IsPhasesRuleValid = isPhasesRuleValid;
            IsCoreColorRuleValid = isCoreColorRuleValid;
            Accomplished = accomplished;
            Message = message;
        }

        #endregion

        #region Properties

        public int Phases { get; }

        public int CoreNumber { get; }

        public bool IsCoreColorRuleValid { set; get; }

        public bool MonophaseValid { set; get; }

        public bool TriphasicValidation { set; get; }

        public bool IsPhasesRuleValid { set; get; }

        public bool IsAssignationCoreValid { set; get; }

        public bool Accomplished { set; get; }

        public List<CoreValidationModel> Validation { get; }

        public string Message { set; get; }

        #endregion
    }

    public class CoreValidationModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public CoreValidationModel(int coreIndex, string testCode, int color, List<int> colorSugetions)
        {
            CoreIndex = coreIndex;
            TestCode = testCode;
            Color = color;
            ColorSugetions = colorSugetions;
        }

        #endregion

        #region Properties

        public int CoreIndex { get; }

        public string TestCode { get; }

        public int Color { get; }

        public List<int> ColorSugetions { get; }

        #endregion
    }
}
