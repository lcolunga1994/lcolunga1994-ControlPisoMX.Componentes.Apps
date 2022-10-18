namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp
{
    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ComponentsGatewayDummy : IResidentialCoresService
    {
        #region Item design

        public Task<ItemModel?> GetItemAsync(string itemId) => throw new NotImplementedException();

        public Task<CoreVoltageDesignModel?> GetResidentialCoreVoltageDesignAsync(
            string itemId,
            int coreSize,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

        #region Plan

        public Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync() => throw new NotImplementedException();

        public Task<QueryResult<string>> GetItemsPlannedToBeManufacturedAsync(int page, int pageSize, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<QueryResult<ManufacturedResidentialCoreModel>> GetManufacturedCoresAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<CoreManufacturingPlanModel?> GetNextCoreToBeManufacturedAsync(string itemId, CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

        #region Pattern

        public Task<ResidentialCorePatternTestsSummaryModel?> GetResidentialCorePatternTestSummaryAsync() => throw new NotImplementedException();

        public Task<ResidentialCoreTestResultModel> TestResidentialCorePatternAsync(
           string testCode,
           double averageVoltage,
           double rmsVoltage,
           double current,
           double temperature,
           double watts,
           double coreTemperature,
           string? stationId,
           CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

        #region Tests

        public Task<ResidentialCoreTestSummaryModel?> GetResidentialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode) => throw new NotImplementedException();

        public Task<ResidentialCoreSuggestedCodeResultModel?> GetResidentialCoreSuggestedCodeResultAsync(string testCode) => throw new NotImplementedException();

        public Task<ResidentialCoreLocationResultModel?> GetResidentialCoreLocationResultAsync(string testCode) => throw new NotImplementedException();

        public Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync(
            string? tag,
            string itemId,
            int coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync(
            string itemId,
            int coreSize,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string testCode,
            string? stationId,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

        #region Defects

        public Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectConceptListAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
            string testCode,
            string defect,
            CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

        #region Store

        public Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

        #region Supply

        public Task<MOSupplySummaryModel?> GetOrderSupplySummary(string itemId, string batch) => throw new NotImplementedException();

        public async Task<IEnumerable<InsulationMachineModel>> GetWindingMachinesAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<InsulationMachineModel>()
            {
                new InsulationMachineModel("1509",true),
                new InsulationMachineModel("1510",false)
            });
        }

        //public static async Task<IEnumerable<MOManufacturingStatusModel>> GetManufacturingSummaryAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
        //{
        //    return await Task.FromResult(new List<MOManufacturingStatusModel>()
        //    {
        //        new MOManufacturingStatusModel("AN471", "252", 1, 1){ InsulationStatus = -1, CoreTestColor = CoreLimitColor.None },
        //        new MOManufacturingStatusModel("AN472", "252", 2, 2){ InsulationStatus = 0, CoreTestColor = CoreLimitColor.Blue, CoreTestResult = CoreTestResult.Passed, CoreLocation = "BANDA" },
        //        new MOManufacturingStatusModel("AN473", "252", 2, 2){ InsulationStatus = 1, CoreTestColor = CoreLimitColor.Green, CoreTestResult = CoreTestResult.Passed, CoreLocation = "BANDA" },
        //        new MOManufacturingStatusModel("AN474", "252", 2, 2){ InsulationStatus = 3, CoreTestColor = CoreLimitColor.Yellow, CoreTestResult = CoreTestResult.Passed, CoreLocation = "BANDA" },
        //        new MOManufacturingStatusModel("AN474", "252", 2, 2){ InsulationStatus = 3, CoreTestColor = CoreLimitColor.Red, CoreTestResult = CoreTestResult.Passed, CoreLocation = "BANDA" },
        //        new MOManufacturingStatusModel("AN475", "252", 1, 1){ InsulationStatus = -1, CoreTestColor = CoreLimitColor.None, CoreTestResult = CoreTestResult.Failed}
        //    });
        //}

        //public async Task<IEnumerable<MOSupplyItemModel>> GetPendingSuppliesAsync(CancellationToken cancellationToken)
        //{
        //    return await Task.FromResult(new List<MOSupplyItemModel>()
        //    {
        //        new MOSupplyItemModel("AN471", "252", 1, "1", DateTime.UtcNow){ Line = 1 },
        //        new MOSupplyItemModel("AN472", "252", 1, "2", DateTime.UtcNow){ Line = 2 },
        //        new MOSupplyItemModel("AN472", "252", 2, "2", DateTime.UtcNow){ Line = 3 },
        //        new MOSupplyItemModel("AN526", "252", 1, "3", DateTime.UtcNow){ Line = 2 },
        //        new MOSupplyItemModel("AN526", "252", 2, "3", DateTime.UtcNow){ Line = 2 },
        //        new MOSupplyItemModel("AN526", "252", 3, "3", DateTime.UtcNow){ Line = 2 }
        //    });
        //}

        //public static async Task AddResidentialOrdersToSupplyListAsync(List<OrderParameterModel> orders, CancellationToken cancellation) => await Task.Delay(2000, cancellation);

        //public async Task<IEnumerable<MOSupplyPrintableAttributeModel>> GetSupplyCoresAsync(List<ResidentialOrderAvailableToSupplyModel> order, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        #region Dummy data
        //        return await Task.FromResult(new List<MOSupplyPrintableAttributeModel>()
        //        {
        //            //ANL471
        //        new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Line",
        //            Value="1"
        //        },
        //         new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Fecha",
        //            Value=DateTime.UtcNow.ToString("s")//se debe transformar a local en el frente
        //        },
        //          new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Color",
        //            Value="Amarillo"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Strip",
        //            Value="A=10.45"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Dimensiones",
        //            Value="18"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Sec",
        //            Value="187"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Market",
        //            Value="Exp"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Pilot",
        //            Value="TST"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Devanadora",
        //            Value="1537"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Type",
        //            Value="POSTE"
        //        }
        //           ,
        //           //ANH339
        //         new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Line",
        //            Value="1"
        //        },
        //         new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Fecha",
        //            Value=DateTime.UtcNow.ToString("s")//se debe transformar a local en el frente
        //        },
        //          new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Color",
        //            Value="Amarillo"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Strip",
        //            Value="A=55.4"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Dimensiones",
        //            Value="18"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Sec",
        //            Value="187"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Market",
        //            Value="Exp"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Pilot",
        //            Value=" "
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANH339",
        //            Batch="160",
        //            Serie=51,
        //            Attibute="Devanadora",
        //            Value="1537"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Type",
        //            Value="POSTE"
        //        }
        //           ,
        //           //ANH339
        //         new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Line",
        //            Value="1"
        //        },
        //         new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Fecha",
        //            Value=DateTime.UtcNow.ToString("s")//se debe transformar a local en el frente
        //        },
        //          new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Color",
        //            Value="Amarillo"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Strip",
        //            Value="A=12.7"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Dimensiones",
        //            Value="18"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Sec",
        //            Value="187"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Market",
        //            Value="Exp"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Pilot",
        //            Value=" "
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="PCL753",
        //            Batch="333",
        //            Serie=18,
        //            Attibute="Devanadora",
        //            Value="1537"
        //        },
        //           new MOSupplyPrintableAttributeModel()
        //        {
        //            ItemId="ANL471",
        //            Batch="251",
        //            Serie=1,
        //            Attibute="Type",
        //            Value="POSTE"
        //        }
        //        });
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is not UserException)
        //        {
        //            //logger.LogError(ex, "Ocurrió un error al suministrar los núcleos.");
        //        }
        //        throw;
        //    }
        //}

        public Task ConfirmSupplyAsync(string itemId, string batch, int serie) => throw new NotImplementedException();

        public Task AuthorizeReprintAsync(string itemId, string batch, int serie) => throw new NotImplementedException();

        public Task<IEnumerable<ResidentialSuppliedCoreTestModel>> GetResidentialCoreSupplyByOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task AddSupplyCoreAsync(AddSupplyCoreModel supply, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task RemoveSupplyCoreAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<SupplyCoreResultModel?> SupplyCoresAsync(string itemId, string batch, int serie, bool force) => throw new NotImplementedException();

        #endregion
    }
}