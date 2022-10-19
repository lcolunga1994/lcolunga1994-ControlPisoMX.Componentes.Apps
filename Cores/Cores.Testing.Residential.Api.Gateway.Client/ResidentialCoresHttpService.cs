namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Cores.Models;
    using Cores.Residential.Models;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ResidentialCoresHttpService : Http.WebApiClient, IResidentialCoresService
    {
        #region Fields

        private readonly ILogger<ResidentialCoresHttpService> logger;

        #endregion

        #region Constructor

        public ResidentialCoresHttpService(
           HttpClient httpClient,
           ILogger<ResidentialCoresHttpService> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Item design

        public async Task<ItemModel?> GetItemAsync(string itemId)
        {
            try
            {
                logger.LogInformation("Consultando información del artículo '{itemId}'.", itemId);

                return await GetAsync<ItemModel?>(string.Concat($"items/{itemId}"), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información del artículo '{itemId}' en este momento.", "ComponentsGetItem");
            }
        }

        public async Task<CoreVoltageDesignModel?> GetResidentialCoreVoltageDesignAsync(
           string itemId,
           int coreSize,
           CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando la información de diseño: artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<CoreVoltageDesignModel?>(
                    string.Concat($"cores/residential/design/voltage/{itemId}/{coreSize}"),
                    cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar la información de diseño: artículo:{itemId} tamaño:{coreSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información de diseño en este momento.",
                    "ResidentialCoreVoltageDesign");
            }
        }

        #endregion

        #region Plan

        public async Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync()
        {
            try
            {
                logger.LogInformation($"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

                IEnumerable<DateRangeAvailableModel>? result = await GetAsync<IEnumerable<DateRangeAvailableModel>?>("cores/residential/manufacturing/daterange", CancellationToken.None)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<DateRangeAvailableModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el rango de fechas disponibles para probar en el plan de fabricación.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el rango de fechas disponibles para probar en este momento.",
                    "DateRangeAvailableForTest");
            }
        }
        public async Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync_discpiso()
        {
            try
            {
                logger.LogInformation($"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

                IEnumerable<DateRangeAvailableModel>? result = await GetAsync<IEnumerable<DateRangeAvailableModel>?>("cores/residential/manufacturing/daterange_discpiso", CancellationToken.None)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return Enumerable.Empty<DateRangeAvailableModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el rango de fechas disponibles para probar en el plan de fabricación.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el rango de fechas disponibles para probar en este momento.",
                    "DateRangeAvailableForTest");
            }
        }

        public async Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync(
           int page,
           int pageSize,
           CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                Cores.QueryResult<string>? result = await GetAsync<Cores.QueryResult<string>>($"cores/residential/manufacturing/itemsplanned?page={page}&pageSize={pageSize}", cancellationToken)
                .ConfigureAwait(false);

                if (result == null)
                {
                    return new Cores.QueryResult<string>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar los artículos planeados para la fabricación de núcleos en este momento.",
                    "ComponentsCoresTestingPlan");
            }
        }

        public async Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync_discpiso(
           int page,
           int pageSize,
           CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                Cores.QueryResult<string>? result = await GetAsync<Cores.QueryResult<string>>($"cores/residential/manufacturing/itemsplanned_discpiso?page={page}&pageSize={pageSize}", cancellationToken)
                .ConfigureAwait(false);

                if (result == null)
                {
                    return new Cores.QueryResult<string>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar los artículos planeados para la fabricación de núcleos en este momento.",
                    "ComponentsCoresTestingPlan");
            }
        }

        public async Task<CoreManufacturingPlanModel?> GetNextCoreToBeManufacturedAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el plan de fabricación del artículo '{itemId}'.");

                return await GetAsync<CoreManufacturingPlanModel?>($"cores/residential/manufacturing/nextcore/{itemId}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el plan de fabricación del artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación del artículo '{itemId}' en este momento.",
                    "ComponentsCoresTestingPlanItem");
            }
        }

        #endregion

        #region Pattern

        public async Task<ResidentialCorePatternTestsSummaryModel?> GetResidentialCorePatternTestSummaryAsync()
        {
            try
            {
                logger.LogInformation($"Consultando pruebas realizadas al núcleo patrón residencial.");

                return await GetAsync<ResidentialCorePatternTestsSummaryModel?>("cores/residential/testing/patternsummary", CancellationToken.None)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar las pruebas realizadas al núcleo patrón residencial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las pruebas realizadas al núcleo patrón residencial en este momento.",
                    "ComponentsResidentialCorePatternTestSummary");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCorePatternAsync(
           string testCode,
           double averageVoltage,
           double rmsVoltage,
           double current,
           double temperature,
           double watts,
           double coreTemperature,
           string? stationId,
           CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo patrón residencial:");
                stringBuilder.AppendLine($"testCode: {testCode}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");
                stringBuilder.AppendLine($"StationId: {stationId}");

                logger.LogInformation(stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, TestCorePatternParametersModel>(
                    $"cores/residential/testing/testpattern",
                    new TestCorePatternParametersModel(
                        testCode,
                        averageVoltage,
                        rmsVoltage,
                        current,
                        temperature,
                        watts,
                        coreTemperature,
                        stationId),
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón residencial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo patrón residencial en este momento.",
                    "ComponentsTestResidentialCorePattern");
            }
        }

        #endregion        

        #region Tests

        public async Task<Cores.QueryResult<ManufacturedResidentialCoreModel>> GetManufacturedCoresAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las etiquetas de los núcleos fabricados: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<Cores.QueryResult<ManufacturedResidentialCoreModel>>(
                    $"cores/residential/testing/manufactured?page={page}&pageSize={pageSize}",
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar las etiquetas de los núcleos fabricados: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las etiquetas de los núcleos fabricados en este momento.",
                    "ComponentsManufacturedCores");
            }
        }

        public async Task<ResidentialCoreTestSummaryModel?> GetResidentialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");

                return await GetAsync<ResidentialCoreTestSummaryModel?>($"cores/residential/testing/summary/{itemId}/{batch}/{serie}/{sequence}", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence} en este momento.",
                    "ComponentsCoresTestSummary");
            }
        }

        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode)
        {
            try
            {
                logger.LogInformation($"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await GetAsync<ResidentialCoreTestModel?>($"cores/residential/testing/test/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial en este momento.",
                    "ResidentialCoreTestResult");
            }
        }

        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync_discpiso(string testCode)
        {
            try
            {
                logger.LogInformation($"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await GetAsync<ResidentialCoreTestModel?>($"cores/residential/testing/test_discpiso/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial en este momento.",
                    "ResidentialCoreTestResult");
            }
        }

        public async Task<ResidentialCoreSuggestedCodeResultModel?> GetResidentialCoreSuggestedCodeResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation($"Consultando el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await GetAsync<ResidentialCoreSuggestedCodeResultModel?>($"cores/residential/testing/suggestedcode/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial en este momento.",
                    "ResidentialCoreSuggestedCodeResult");
            }
        }

        public async Task<ResidentialCoreLocationResultModel?> GetResidentialCoreLocationResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation($"Consultando la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await GetAsync<ResidentialCoreLocationResultModel?>($"cores/residential/testing/location/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial en este momento.",
                    "ResidentialCoreLocationResult");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync(
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
            CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo con la etiqueta '{tag}':");
                stringBuilder.AppendLine($"Artículo: {itemId}");
                stringBuilder.AppendLine($"Código: {testCode}");
                stringBuilder.AppendLine($"Dona: {coreSize}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");
                stringBuilder.AppendLine($"Estación: {stationId}");

                logger.LogInformation(stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, TestCoreParametersModel>($"cores/residential/testing/test",
                    new TestCoreParametersModel(
                        tag,
                        itemId,
                        coreSize,
                        averageVoltage,
                        rmsVoltage,
                        current,
                        temperature,
                        watts,
                        coreTemperature,
                        testCode,
                        stationId),
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al probar el núcleo con la etiqueta '{tag}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException("No se puede probar el núcleo en este momento.", "ComponentsCoresTest");
            }
        }

        public async Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync(
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
            CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Retrabajo:");
                stringBuilder.AppendLine($"Artículo: {itemId}");
                stringBuilder.AppendLine($"Dona: {coreSize}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");
                stringBuilder.AppendLine($"Código: {testCode}");
                stringBuilder.AppendLine($"Estación: {stationId}");

                logger.LogInformation(stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, ReworkCoreParametersModel>($"cores/residential/testing/rework",
                    new ReworkCoreParametersModel(
                        itemId,
                        coreSize,
                        averageVoltage,
                        rmsVoltage,
                        current,
                        temperature,
                        watts,
                        coreTemperature,
                        testCode,
                        stationId),
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al realizar el retrabajo.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException("No se puede probar el núcleo en este momento.", "ComponentsReworkResidentialCore");
            }
        }

        #endregion

        #region Defects

        public async Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
            string testCode,
            string defect,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Registrando defecto para el núcleo con el codigo '{testCode}' ({defect}).");

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, RegisterDefectParametersModel>($"cores/residential/testing/defect", new RegisterDefectParametersModel(testCode, defect),
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al registrar un defecto para el núcleo con el codigo '{testCode}' ({defect}).");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede registrar el defecto en este momento.",
                    "ComponentsRegisterDefect");
            }
        }

        public async Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectConceptListAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el listado de defectos registrados: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<IEnumerable<CoreTestDefectConceptModel>>(
                    $"cores/residential/testing/defectconcept?page={page}&pageSize={pageSize}",
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el listado de defectos registrados: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede obtener el listado de defectos registrados en este momento.",
                    "ComponentsDefectConceptListAsync");
            }
        }

        #endregion

        #region Store

        public async Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                await PostAsync($"cores/residential/testing/store", new StoreCoreParametersModel(coreTestId, location, associatedCode, force), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede acomodar el núcleo en este momento.",
                    "StoreResidentialCore");
            }
        }

        #endregion

        #region Supply

        public async Task<IEnumerable<InsulationMachineModel>> GetWindingMachinesAsync(CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando las maquinas CMS.");

                return (await GetAsync<IEnumerable<InsulationMachineModel>>($"cores/residential/windingmachines", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<InsulationMachineModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede consultar la información de las maquinas de aislamiento.", "InsulationMachines");
            }
        }

        public async Task<IEnumerable<ResidentialSuppliedCoreTestModel>> GetResidentialCoreSupplyByOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando pruebas de núcleos relacionadas a la orden -{itemId}-{batch}-{serie}-.");

                return (await GetAsync<IEnumerable<ResidentialSuppliedCoreTestModel>>($"cores/residential/coresupplybyorder/{itemId}/{batch}/{serie}", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<ResidentialSuppliedCoreTestModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar las pruebas de núcleos relacionadas a la orden {itemId}-{batch}-{serie}.");
                throw CreateServiceException(
                    $"No se puede consultar las pruebas de núcleos relacionadas a la orden {itemId}-{batch}-{serie}.",
                    "coretestsbyorderid");
            }
        }

        public async Task AddSupplyCoreAsync(AddSupplyCoreModel supply, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Registrando suministro de núcleo.");

                await PostAsync($"cores/residential/addsupplycore", supply, CancellationToken.None)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede registrar el suministro de núcleo", "AddSupplyCore");
            }
        }

        public async Task RemoveSupplyCoreAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Eliminando suministro de núcleo.");

                await PostAsync($"cores/residential/removesupplycore", new RemoveSupplyCoreModel(id), CancellationToken.None)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException($"No se puede eliminar el suministro de núcleo", "RemoveSupplyCore");
            }
        }

        #endregion        

        #region Functionality

        private static UserException CreateServiceException(string message, string errorCode)
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(message);
            throw new UserException(stringBuilder.ToString(), errorCode, true);
        }

        #endregion
    }
}