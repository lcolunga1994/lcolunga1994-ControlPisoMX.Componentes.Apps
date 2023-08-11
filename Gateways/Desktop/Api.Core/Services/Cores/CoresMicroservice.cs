namespace ProlecGE.ControlPisoMX.Cores.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX;
    using ProlecGE.ControlPisoMX.Cores.Models;
    using ProlecGE.ControlPisoMX.Cores.Models.Industrial;
    using ProlecGE.ControlPisoMX.Cores.Models.InspectionCMS;
    using ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders;
    using ProlecGE.ControlPisoMX.Cores.Models.Residential;

    public class CoresMicroservice : Http.WebApiClient, IMicroservice
    {
        #region Fields

        private readonly ILogger<CoresMicroservice> logger;

        #endregion

        #region Constructor

        public CoresMicroservice(
            HttpClient httpClient,
            ILogger<CoresMicroservice> logger)
            : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion

        #region Residential

        #region Pattern

        public async Task<ResidentialCorePatternModel?> GetResidentialCorePatternAsync()
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando pruebas realizadas al núcleo patrón residencial.");

                return await GetAsync<ResidentialCorePatternModel?>($"residential/testpattern", CancellationToken.None)
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
                    $"No se pueden consultar las pruebas realizadas al núcleo con al núcleo patrón residencial.",
                    "ResidentialCoreTestsSummary");
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
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.TestResidentialCorePatternCommand>(
                    "residential/testpattern",
                    new Models.TestResidentialCorePatternCommand(
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
                    "CoresTest");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCorePatternAsync_sqlctp(
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
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.TestResidentialCorePatternCommand>(
                    "residential/testpattern_sqlctp",
                    new Models.TestResidentialCorePatternCommand(
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
                    "CoresTest");
            }
        }

        #endregion

        #region Plan

        public async Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync()
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

                IEnumerable<DateRangeAvailableModel>? result = await GetAsync<IEnumerable<DateRangeAvailableModel>?>("residential/manufacturing/daterange", CancellationToken.None)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return System.Linq.Enumerable.Empty<DateRangeAvailableModel>();
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
                logger.LogInformation("{message}", $"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

                IEnumerable<DateRangeAvailableModel>? result = await GetAsync<IEnumerable<DateRangeAvailableModel>?>("residential/manufacturing/daterange_discpiso", CancellationToken.None)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return System.Linq.Enumerable.Empty<DateRangeAvailableModel>();
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

        public async Task<QueryResult<string>> GetItemsPlannedToBeTestedAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{text}", $"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<QueryResult<string>>($"residential/manufacturing/itemsplanned?page={page}&pageSize={pageSize}", cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las etiquetas de los núcleos fabricados en este momento.",
                    "CoresTestingPlan");
            }
        }

        public async Task<QueryResult<string>> GetItemsPlannedToBeTestedAsync_discpiso(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{text}", $"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<QueryResult<string>>($"residential/manufacturing/itemsplanned_discpiso?page={page}&pageSize={pageSize}", cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las etiquetas de los núcleos fabricados en este momento.",
                    "CoresTestingPlan");
            }
        }

        public async Task<QueryResult<string>> GetItemsPlannedToBeTestedAsync_discpiso_AMO(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{text}", $"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.
                return await GetAsync<QueryResult<string>>($"residential/manufacturing/itemsplanned_discpiso_AMO?page={page}&pageSize={pageSize}", cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar las etiquetas de los núcleos fabricados en este momento.",
                    "CoresTestingPlan");
            }
        }

        public async Task<IEnumerable<CoreManufacturingPlanItemModel>> GetPendingManufacturingPlanAsync(int productLine, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación de la línea de producto '{productLine}'.");

                IEnumerable<CoreManufacturingPlanItemModel>? result = await GetAsync<IEnumerable<CoreManufacturingPlanItemModel>?>($"residential/plan/{(int)productLine}", cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return System.Linq.Enumerable.Empty<CoreManufacturingPlanItemModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el plan de fabricación de la línea de producto '{productLine}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar el plan de fabricación de núcleos en este momento.",
                    "PendingManufacturingPlan");
            }
        }

        public async Task<CoreManufacturingPlanItemModel?> GetNextItemSequenceInPlanAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación del artículo '{itemId}'.");

                return await GetAsync<CoreManufacturingPlanItemModel?>($"residential/manufacturing/nextsequence/{itemId}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el plan de fabricación del artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación del artículo '{itemId}' en este momento.",
                    "CoresTestingPlanItem");
            }
        }

        public async Task<CoreManufacturingPlanItemModel?> GetNextItemSequenceInPlanAsync_discpiso(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación del artículo '{itemId}'.");

                return await GetAsync<CoreManufacturingPlanItemModel?>($"residential/manufacturing/nextsequence_discpiso/{itemId}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el plan de fabricación del artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación del artículo '{itemId}' en este momento.",
                    "CoresTestingPlanItem");
            }
        }
        public async Task<CoreManufacturingPlanItemModel?> GetNextItemSequenceInPlanAsync_discpiso_AMO(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación del artículo '{itemId}'.");

                return await GetAsync<CoreManufacturingPlanItemModel?>($"residential/manufacturing/nextsequence_discpiso_AMO/{itemId}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el plan de fabricación del artículo '{itemId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar el plan de fabricación del artículo '{itemId}' en este momento.",
                    "CoresTestingPlanItem");
            }
        }

        #endregion

        #region Tests

        public async Task<ResidentialCoreTestSummaryModel?> GetResidentialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");

                return await GetAsync<ResidentialCoreTestSummaryModel?>($"residential/summary/{itemId}/{batch}/{serie}/{sequence}", cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence} en este momento.",
                    "ResidentialCoresTestSummary");
            }
        }

        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await GetAsync<ResidentialCoreTestModel?>($"residential/test/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

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
                logger.LogInformation("{message}", $"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await GetAsync<ResidentialCoreTestModel?>($"residential/test_discpiso/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial en este momento.",
                    "ResidentialCoreTestResult");
            }
        }

        public async Task<ResidentialCoreSuggestedCodeModel?> GetResidentialCoreSuggestedCode(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de datos sugeridos para residencial:{testCode}.");

                return await GetAsync<ResidentialCoreSuggestedCodeModel?>($"residential/suggestedcode/{testCode}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultando los datos sugeridos para residencial:{testCode}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar los datos sugeridos para residencial:{testCode}. en este momento.",
                    "ResidentialCoreSuggestedCode");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.TestResidentialCoreCommand>(
                    "residential/test",
                    new Models.TestResidentialCoreCommand(
                        tag,
                        itemId,
                        designId,
                        coreSize,
                        kva,
                        primaryVoltage,
                        secondaryVoltage,
                        testVoltage,
                        limits,
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
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con la etiqueta '{tag}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo en este momento.",
                    "CoresTest");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync_discpiso(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.TestResidentialCoreCommand>(
                    "residential/test_discpiso",
                    new Models.TestResidentialCoreCommand(
                        tag,
                        itemId,
                        designId,
                        coreSize,
                        kva,
                        primaryVoltage,
                        secondaryVoltage,
                        testVoltage,
                        limits,
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
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con la etiqueta '{tag}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo en este momento.",
                    "CoresTest");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync_sqlctp(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.TestResidentialCoreCommand>(
                    "residential/test_sqlctp",
                    new Models.TestResidentialCoreCommand(
                        tag,
                        itemId,
                        designId,
                        coreSize,
                        kva,
                        primaryVoltage,
                        secondaryVoltage,
                        testVoltage,
                        limits,
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
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con la etiqueta '{tag}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo en este momento.",
                    "CoresTest");
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync_sqlctp_AMO(
            string? tag,
            string itemId,
            string designId,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.TestResidentialCoreCommand>(
                    "residential/test_sqlctp_AMO",
                    new Models.TestResidentialCoreCommand(
                        tag,
                        itemId,
                        designId,
                        coreSize,
                        kva,
                        primaryVoltage,
                        secondaryVoltage,
                        testVoltage,
                        limits,
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
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con la etiqueta '{tag}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo en este momento.",
                    "CoresTest");
            }
        }

        public async Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync(
            string itemId,
            string designId,
            int productLine,
            int phases,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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
                stringBuilder.AppendLine($"designId: {designId}");
                stringBuilder.AppendLine($"productLine: {productLine}");
                stringBuilder.AppendLine($"phases: {phases}");
                stringBuilder.AppendLine($"coreSize: {coreSize}");
                stringBuilder.AppendLine($"Dona: {coreSize}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.ReworkResidentialCoreCommand>(
                    "residential/rework",
                    new Models.ReworkResidentialCoreCommand(
                        itemId,
                        designId,
                        productLine,
                        phases,
                        coreSize,
                        kva,
                        primaryVoltage,
                        secondaryVoltage,
                        testVoltage,
                        limits,
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
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo '{itemId}' (retrabajo).");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo en este momento.",
                    "CoresRework");
            }
        }
        public async Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync_sqlctp(
            string itemId,
            string designId,
            int productLine,
            int phases,
            int coreSize,
            double? kva,
            double primaryVoltage,
            double? secondaryVoltage,
            double? testVoltage,
            IEnumerable<ItemVoltageLimitModel> limits,
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
                stringBuilder.AppendLine($"designId: {designId}");
                stringBuilder.AppendLine($"productLine: {productLine}");
                stringBuilder.AppendLine($"phases: {phases}");
                stringBuilder.AppendLine($"coreSize: {coreSize}");
                stringBuilder.AppendLine($"Dona: {coreSize}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<ResidentialCoreTestResultModel, Models.ReworkResidentialCoreCommand>(
                    "residential/rework_sqlctp",
                    new Models.ReworkResidentialCoreCommand(
                        itemId,
                        designId,
                        productLine,
                        phases,
                        coreSize,
                        kva,
                        primaryVoltage,
                        secondaryVoltage,
                        testVoltage,
                        limits,
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
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo '{itemId}' (retrabajo).");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo en este momento.",
                    "CoresRework");
            }
        }

        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestByOrder(string itemId, string batch, int serie, int sequence)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de datos de prueba del articulo:{itemId}, lote:{batch}, serie:{serie}, sequencia:{sequence}.");

                return await GetAsync<ResidentialCoreTestModel?>($"residential/ResidentialCoreTestByOrder/{itemId}/{batch}/{serie}/{sequence}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultando los datos de prueba del articulo:{itemId}, lote:{batch}, serie:{serie}, sequencia:{sequence}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar los datos de prueba del articulo:{itemId}, lote:{batch}, serie:{serie}, sequencia:{sequence}. en este momento.",
                    "GetResidentialCoreTestByOrder");
            }
        }

        #endregion

        #region Defects

        public async Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectsAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el listado de defectos registrados: página:{page} tamaño:{pageSize}.");

#pragma warning disable CS8603 // Possible null reference return.                
                return await GetAsync<IEnumerable<CoreTestDefectConceptModel>>(
                    $"residential/defects?page={page}&pageSize={pageSize}",
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el listado de defectos registrados: página:{page} tamaño:{pageSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede obtener el listado de defectos registrados en este momento.",
                    "DefectConceptListAsync");
            }
        }

        public async Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
            string testCode,
            string defect,
            CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Registrando defecto del núcleo '{testCode}':");
                stringBuilder.AppendLine($"Defecto: {defect}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.

                return await PostAsync<ResidentialCoreTestResultModel, Models.RegisterDefectCommand>(
                    "residential/defect",
                    new Models.RegisterDefectCommand(
                        testCode,
                        defect),
                    cancellationToken)
                    .ConfigureAwait(false);

#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al registrar el defecto del núcleo con la nucleo '{testCode}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede registrar el defecto del núcleo en este momento.",
                    "RegisterDefectAsync");
            }
        }
        public async Task<ResidentialCoreTestResultModel> RegisterDefectAsync_sqlctp(
            string testCode,
            string defect,
            CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Registrando defecto del núcleo '{testCode}':");
                stringBuilder.AppendLine($"Defecto: {defect}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.

                return await PostAsync<ResidentialCoreTestResultModel, Models.RegisterDefectCommand>(
                    "residential/defect_sqlctp",
                    new Models.RegisterDefectCommand(
                        testCode,
                        defect),
                    cancellationToken)
                    .ConfigureAwait(false);

#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al registrar el defecto del núcleo con la nucleo '{testCode}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede registrar el defecto del núcleo en este momento.",
                    "RegisterDefectAsync");
            }
        }

        #endregion

        #region Store

        public async Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force)
        {
            try
            {
                logger.LogInformation("{message}", $"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                if (string.IsNullOrWhiteSpace(location))
                {
                    throw new UserException("La ubicación es requerida.");
                }

                if (!string.IsNullOrWhiteSpace(associatedCode))
                {
                    logger.LogInformation("{message}", $"{(force ? "Forzando asociación" : "Asociando")} con núcleo con código de prueba '{associatedCode}'.");
                }

                await PostAsync($"residential/store", new Models.StoreCoreModel(coreTestId, location, associatedCode, force), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede acomodar el núcleo en este momento.",
                    "AccommodateResidentialCore");
            }
        }
        public async Task StoreResidentialCoreAsync_sqlctp(Guid coreTestId, string location, string? associatedCode, bool force)
        {
            try
            {
                logger.LogInformation("{message}", $"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                if (string.IsNullOrWhiteSpace(location))
                {
                    throw new UserException("La ubicación es requerida.");
                }

                if (!string.IsNullOrWhiteSpace(associatedCode))
                {
                    logger.LogInformation("{message}", $"{(force ? "Forzando asociación" : "Asociando")} con núcleo con código de prueba '{associatedCode}'.");
                }

                await PostAsync($"residential/store_sqlctp", new Models.StoreCoreModel(coreTestId, location, associatedCode, force), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede acomodar el núcleo en este momento.",
                    "AccommodateResidentialCore");
            }
        }

        #endregion

        #region Supply

        public async Task<IEnumerable<MOSupplyItemStatusModel>> GetSuppliesByBatchAsync(string itemId, string batch)
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemStatusModel>, Models.ManufacturingOrderParameterModel>(
                        "supply/bybatch",
                        new Models.ManufacturingOrderParameterModel(itemId, batch),
                        CancellationToken.None)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemStatusModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes suministradas para el pedido {itemId}-{batch}.", itemId, batch);
                throw CreateServiceException(
                    $"No se pueden consultar las ordenes suministradas para el pedido {itemId}-{batch} en este momento.",
                    "SuppliedOrders");
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetSuppliesByScheduleAsync(DateTime scheduledDate, string machine)
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemModel>, Models.DateAndMachineParameterModel>(
                        "supply/byschedule",
                        new Models.DateAndMachineParameterModel() { Date = scheduledDate, Machine = machine },
                        CancellationToken.None)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar los suministros de ordenes programadas para la maquina {machine} en la fecha {scheduledDate}", machine, scheduledDate.ToString("G"));

                throw CreateServiceException(
                    $"No se pueden consultar los suministros de ordenes programadas en este momento.",
                    "SuppliesBySchedule");
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetPendingSuppliesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemModel>>($"supply/pending", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes disponibles para suministrar núcleos.");
                throw CreateServiceException("No se pueden consultar las ordenes disponibles para suministrar núcleos en este momento.", "PendingSupplies");
            }
        }

        public async Task<MOPrintableModel?> GetSupplyTagAsync(Guid manufacturingOrderId)
        {
            try
            {
                return (await GetAsync<MOPrintableModel>($"supply/tag/{manufacturingOrderId}", CancellationToken.None)
                    .ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError("Ocurrió un error al consultar información para imprimir el suministro de orden con Id {id}", manufacturingOrderId);
                throw CreateServiceException("No se puede consultar la información para imprimir el suministro de orden en este momento.", "SupplyTag");
            }
        }

        public async Task AddOrdersToSupplyListAsync(List<MOSupplyParameterModel> orders, CancellationToken cancellation)
        {
            try
            {
                await PostAsync($"residential/supplylist", orders, CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.");
                throw CreateServiceException("No se pueden registrar las ordenes como disponibles para suministrar núcleos en este momento.", "AddOrdersToSupplyList");
            }
        }
        public async Task AddOrdersToSupplyListAsync_sqlctp(List<MOSupplyParameterModel> orders, CancellationToken cancellation)
        {
            try
            {
                await PostAsync($"residential/supplylist_sqlctp", orders, CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.");
                throw CreateServiceException("No se pueden registrar las ordenes como disponibles para suministrar núcleos en este momento.", "AddOrdersToSupplyList");
            }
        }

        public async Task ConfirmSupplyAsync(string itemId, string batch, int serie)
        {
            try
            {
                await PostAsync($"supply/confirm/{itemId}/{batch}/{serie}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al confirmar el suministro de la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede confirmar el suministro de la orden en este momento.", "ConfirmSupply");
            }
        }
        public async Task ConfirmSupplyAsync_sqlctp(string itemId, string batch, int serie)
        {
            try
            {
                await PostAsync($"supply/confirm_sqlctp/{itemId}/{batch}/{serie}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al confirmar el suministro de la orden '{itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede confirmar el suministro de la orden en este momento.", "ConfirmSupply");
            }
        }

        public async Task AuthorizeReprintAsync(string itemId, string batch, int serie)
        {
            try
            {
                await PostAsync($"supply/authorizereprint/{itemId}/{batch}/{serie}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al autorizar la reimpresión de la orden {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede autorizar la reimpresión de la orden en este momento.", "AuthorizeReprint");
            }
        }

        public async Task AuthorizeReprintAsync_sqlctp(string itemId, string batch, int serie)
        {
            try
            {
                await PostAsync($"supply/authorizereprint_sqlctp/{itemId}/{batch}/{serie}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al autorizar la reimpresión de la orden {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException("No se puede autorizar la reimpresión de la orden en este momento.", "AuthorizeReprint");
            }
        }

        public async Task<IEnumerable<MOSupplyItemModel>> GetSuppliesToReprintAsync()
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemModel>>($"supply/reprint", CancellationToken.None)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes autorizadas para reimprimir.");

                throw CreateServiceException("No se pueden consultar las ordenes autorizadas para reimprimir en este momento.", "SuppliesToReprint");
            }
        }

        public async Task<IEnumerable<ResidentialSuppliedCoreTestModel>> GetResidentialCoreSupplyByOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando pruebas de núcleos de orden -{itemId}-{batch}-{serie}-.");

                IEnumerable<ResidentialSuppliedCoreTestModel>? result =
                    await GetAsync<IEnumerable<ResidentialSuppliedCoreTestModel>>($"residential/coresupplybyorder/{itemId}/{batch}/{serie}", cancellationToken)
                    .ConfigureAwait(false);

                if (result == null)
                {
                    return System.Linq.Enumerable.Empty<ResidentialSuppliedCoreTestModel>();
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar las pruebas de núcleos de orden -{itemId}-{batch}-{serie}-.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las pruebas de núcleos de orden -{itemId}-{batch}-{serie}-.",
                    "coretestsbyorderid");
            }
        }

        public async Task AddSupplyCoreAsync(AddSupplyCoreModel supply, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Registrando suministro de núcleo.");

                await PostAsync($"residential/addsupplycore/", supply, CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al registrar el suministro de núcleo.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden registrar el suministro de núcleos en este momento.",
                    "AddSupplyCore");
            }
        }
        public async Task AddSupplyCoreAsync_sqlctp(AddSupplyCoreModel supply, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Registrando suministro de núcleo.");

                await PostAsync($"residential/addsupplycore_sqlctp/", supply, CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al registrar el suministro de núcleo.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden registrar el suministro de núcleos en este momento.",
                    "AddSupplyCore");
            }
        }

        public async Task RemoveSupplyCoreAsync(Guid id, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Removiendo suministro de núcleo.");

                await PostAsync($"residential/removesupplycore/", new RemoveSupplyCoreModel(id), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al remover el suministro núcleo.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden remover el suministro de núcleo en este momento.",
                    "RemoveSupplyCore");
            }
        }
        public async Task RemoveSupplyCoreAsync_sqlctp(Guid id, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Removiendo suministro de núcleo.");

                await PostAsync($"residential/removesupplycore_sqlctp/", new RemoveSupplyCoreModel(id), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al remover el suministro núcleo.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden remover el suministro de núcleo en este momento.",
                    "RemoveSupplyCore");
            }
        }

        public async Task<SupplyCoreResultModel?> SupplyCoresAsync(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                return await PostAsync<SupplyCoreResultModel?>($"supply/SupplyCores/{itemId}/{batch}/{serie}/{force}/{user}", CancellationToken.None)
                     .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al suministrar los núcleos {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException(
                    "No se puede suministrar los núcleos en este momento.",
                    "SupplyCores");
            }
        }
        public async Task<SupplyCoreResultModel?> SupplyCoresAsync_discpiso(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                return await PostAsync<SupplyCoreResultModel?>($"supply/SupplyCores_discpiso/{itemId}/{batch}/{serie}/{force}/{user}", CancellationToken.None)
                     .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al suministrar los núcleos {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException(
                    "No se puede suministrar los núcleos en este momento.",
                    "SupplyCores");
            }
        }
        public async Task<SupplyCoreResultModel?> SupplyCoresAsync_sqlctp(string itemId, string batch, int serie, bool force, string user)
        {
            try
            {
                return await PostAsync<SupplyCoreResultModel?>($"supply/SupplyCores_sqlctp/{itemId}/{batch}/{serie}/{force}/{user}", CancellationToken.None)
                     .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al suministrar los núcleos {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException(
                    "No se puede suministrar los núcleos en este momento.",
                    "SupplyCores");
            }
        }

        public async Task ReprintAsync(Guid manufacturingOrderId, string user)
        {
            try
            {
                await PostAsync($"supply/reprint/{manufacturingOrderId}/{user}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al registrar la reimpresión de la orden con id {id}'.", manufacturingOrderId);

                throw CreateServiceException("No se puede registar la reimpresión de la orden en este momento.", "AuthorizeReprint");
            }
        }

        public async Task ReprintAsync_sqlctp(Guid manufacturingOrderId, string user)
        {
            try
            {
                await PostAsync($"supply/reprint_sqlctp/{manufacturingOrderId}/{user}")
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al registrar la reimpresión de la orden con id {id}'.", manufacturingOrderId);

                throw CreateServiceException("No se puede registar la reimpresión de la orden en este momento.", "AuthorizeReprint");
            }
        }

        public async Task RefreshPrintableAttributesAsync(string itemId, string batch, int serie, List<MOPrintableAttributeModel> attributes)
        {
            try
            {
                await PostAsync<MOPrintableAttributeParameterModel, RefreshPrintableAttributesParameterModel>("supply/refreshprintattributes",
                    new RefreshPrintableAttributesParameterModel()
                    {
                        ItemId = itemId,
                        Batch = batch,
                        Serie = serie,
                        PrintableAttributes = attributes
                            .Select(i => new MOPrintableAttributeParameterModel() { Attribute = i.Attribute, Value = i.Value })
                            .ToList()
                    }, CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al actualizar los valores para la impresión de la orden {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException($"No se puede actualizar los valores para la impresión de la orden {itemId}-{batch}-{serie} en este momento.", "RefreshPrintableAttributes");
            }
        }
        public async Task RefreshPrintableAttributesAsync_sqlctp(string itemId, string batch, int serie, List<MOPrintableAttributeModel> attributes)
        {
            try
            {
                await PostAsync<MOPrintableAttributeParameterModel, RefreshPrintableAttributesParameterModel>("supply/refreshprintattributes_sqlctp",
                    new RefreshPrintableAttributesParameterModel()
                    {
                        ItemId = itemId,
                        Batch = batch,
                        Serie = serie,
                        PrintableAttributes = attributes
                            .Select(i => new MOPrintableAttributeParameterModel() { Attribute = i.Attribute, Value = i.Value })
                            .ToList()
                    }, CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al actualizar los valores para la impresión de la orden {itemId}-{batch}-{serie}'.", itemId, batch, serie);

                throw CreateServiceException($"No se puede actualizar los valores para la impresión de la orden {itemId}-{batch}-{serie} en este momento.", "RefreshPrintableAttributes");
            }
        }

        #endregion

        #endregion

        #region Industrial

        #region Pattern

        public async Task<IndustrialCorePatternModel?> GetIndustrialCorePatternAsync()
        {
            try
            {
                logger.LogInformation($"Consultando pruebas realizadas al núcleo patrón industrial.");

                return await GetAsync<IndustrialCorePatternModel?>($"industrial/testpattern", CancellationToken.None)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar las pruebas realizadas al núcleo patrón industrial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar las pruebas realizadas al núcleo con al núcleo patrón industrial.",
                    "IndustrialCoreTestsSummary");
            }
        }        

        public async Task<IndustrialCoreTestResultModel> TestIndustrialCorePatternAsync(
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
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo patrón industrial:");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<IndustrialCoreTestResultModel, Models.TestIndustrialCorePatternParameterModel>(
                    "industrial/testpattern",
                    new Models.TestIndustrialCorePatternParameterModel(
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
                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón industrial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo patrón industrial en este momento.",
                    "CoresTest");
            }
        }
        public async Task<IndustrialCoreTestResultModel> TestIndustrialCorePatternAsync_sqlctp(
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
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo patrón industrial:");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<IndustrialCoreTestResultModel, Models.TestIndustrialCorePatternParameterModel>(
                    "industrial/testpattern_sqlctp",
                    new Models.TestIndustrialCorePatternParameterModel(
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
                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón industrial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo patrón industrial en este momento.",
                    "CoresTest");
            }
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<double>?> GetCoreFoilWidthsAsync(string itemId, int coreSize)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los anchos de lamina para el artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<IEnumerable<double>?>($"industrial/foilwidths/{itemId}/{(int)coreSize}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los anchos de lamina para el:{itemId} tamaño:{coreSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los anchos de lamina para el:{itemId} en este momento.",
                    "CoreFoilWidths");
            }
        }
        public async Task<IEnumerable<double>?> GetCoreFoilWidthsAsync_sqlctp(string itemId, int coreSize)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los anchos de lamina para el artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<IEnumerable<double>?>($"industrial/foilwidths_sqlctp/{itemId}/{(int)coreSize}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los anchos de lamina para el:{itemId} tamaño:{coreSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar los anchos de lamina para el:{itemId} en este momento.",
                    "CoreFoilWidths");
            }
        }

        public async Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync(string itemId, int coreSize, double foilWidth)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de diseño del artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<IndustrialItemVoltageDesignModel?>($"industrial/corevoltagedesign/{itemId}/{coreSize}/{foilWidth}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar la información de diseño del artículo:{itemId} tamaño:{coreSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la información de diseño del artículo:{itemId} en este momento.",
                    "IndustrialCoreVoltageDesign");
            }
        }
        public async Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync_sqlctp(string itemId, int coreSize, double foilWidth)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de diseño del artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<IndustrialItemVoltageDesignModel?>($"industrial/corevoltagedesign_sqlctp/{itemId}/{coreSize}/{foilWidth}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar la información de diseño del artículo:{itemId} tamaño:{coreSize}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la información de diseño del artículo:{itemId} en este momento.",
                    "IndustrialCoreVoltageDesign");
            }
        }

        public async Task<IndustrialCoreSuggestedCodeModel?> GetIndustrialCoreSuggestedCode(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de datos sugeridos para industrial:{testCode}.");

                return await GetAsync<IndustrialCoreSuggestedCodeModel?>($"industrial/suggestedcode/{testCode}", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultando los datos sugeridos para industrial:{testCode}.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se puede consultar los datos sugeridos para industrial:{testCode}. en este momento.",
                    "IndustrialCoreSuggestedCode");
            }
        }

        #endregion

        #region Tests

        public async Task<IndustrialCoreTestSummaryModel?> GetIndustrialCoreTestSummaryAsync(string itemId, string batch, int serie)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información sobre pruebas del núcleo industrial con la orden '{itemId}-{batch}-{serie}'");

                return await GetAsync<IndustrialCoreTestSummaryModel?>($"industrial/summary/{itemId}/{batch}/{serie}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar información sobre pruebas del núcleo industrial con la orden '{itemId}-{batch}-{serie}'");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la información sobre pruebas del núcleo industrial con la orden '{itemId}-{batch}-{serie}' en este momento.",
                    "IndustrialCoreTestSummary");
            }
        }

        public async Task<IndustrialCoreTestResultModel?> GetIndustrialCoreTestResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await GetAsync<IndustrialCoreTestResultModel?>($"industrial/test/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo industrial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo industrial en este momento.",
                    "IndustrialCoreTestResult");
            }
        }

        public async Task<IndustrialCoreTestModel?> GetIndustrialCoreTestAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await GetAsync<IndustrialCoreTestModel?>($"industrial/testcore/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo industrial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo industrial en este momento.",
                    "IndustrialCoreTestResult");
            }
        }

        public async Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId,
            string? idSub,
            CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo industrial'{itemId}-{batch}-{serie}':");
                stringBuilder.AppendLine($"Tamaño: {coreSize}");
                stringBuilder.AppendLine($"Ancho: {foilWidth}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<IndustrialCoreTestResultModel, Models.TestIndustrialCoreParameterModel>("industrial/test",
                    new Models.TestIndustrialCoreParameterModel(
                        itemId,
                        batch,
                        serie,
                        coreSize,
                        foilWidth,
                        testCode,
                        averageVoltage,
                        rmsVoltage,
                        current,
                        temperature,
                        watts,
                        coreTemperature,
                        stationId,
                        idSub),
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo industrial con la orden '{itemId}-{batch}-{serie}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo industrial en este momento.",
                    "TestIndustrialCore");
            }
        }
        public async Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync_sqlctp(
            string itemId,
            string batch,
            int serie,
            int coreSize,
            double foilWidth,
            string testCode,
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts,
            double coreTemperature,
            string? stationId,
            string? idSub,
            CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo industrial'{itemId}-{batch}-{serie}':");
                stringBuilder.AppendLine($"Tamaño: {coreSize}");
                stringBuilder.AppendLine($"Ancho: {foilWidth}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<IndustrialCoreTestResultModel, Models.TestIndustrialCoreParameterModel>("industrial/test_sqlctp",
                    new Models.TestIndustrialCoreParameterModel(
                        itemId,
                        batch,
                        serie,
                        coreSize,
                        foilWidth,
                        testCode,
                        averageVoltage,
                        rmsVoltage,
                        current,
                        temperature,
                        watts,
                        coreTemperature,
                        stationId,
                        idSub),
                    cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo industrial con la orden '{itemId}-{batch}-{serie}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo industrial en este momento.",
                    "TestIndustrialCore");
            }
        }

        #endregion

        #region Store

        public async Task StoreIndustrialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force)
        {
            try
            {
                logger.LogInformation("{message}", $"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                if (string.IsNullOrWhiteSpace(location))
                {
                    throw new UserException("La ubicación es requerida.");
                }

                if (!string.IsNullOrWhiteSpace(associatedCode))
                {
                    logger.LogInformation("{message}", $"{(force ? "Forzando asociación" : "Asociando")} con núcleo con código de prueba '{associatedCode}'.");
                }

                await PostAsync($"industrial/store", new Models.StoreCoreModel(coreTestId, location, associatedCode, force), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede acomodar el núcleo en este momento.",
                    "AccommodateResidentialCore");
            }
        }

        #endregion

        #endregion

        #region Clamps

        public async Task<IEnumerable<MOSupplyItemModel>> GetOrdersToPlaceClampsAsync(CancellationToken cancellationToken)
        {
            try
            {
                return (await GetAsync<IEnumerable<MOSupplyItemModel>>($"supply/orders", cancellationToken)
                    .ConfigureAwait(false)) ?? Enumerable.Empty<MOSupplyItemModel>();
            }
            catch (Exception ex)
            {
                if (ex is UserException)
                {
                    throw;
                }

                logger.LogError(ex, "Ocurrió un error al consultar las ordenes disponibles para suministrar núcleos.");
                throw CreateServiceException("No se pueden consultar las ordenes disponibles para suministrar núcleos en este momento.", "PendingSupplies");
            }
        }

        public async Task RemoveClampOrderAsync(string itemId, string batch, int serie, int sequence, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Removiendo herraje.");

                await PostAsync($"supply/removeclamp/", new OrderModel(itemId, batch, serie, sequence), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al remover el herraje.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden remover el herraje.",
                    "RemoveClamp");
            }
        }

        public async Task RemoveClampOrderAsync_sqlctp(string itemId, string batch, int serie, int sequence, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Removiendo herraje.");

                await PostAsync($"supply/removeclamp_sqlctp/", new OrderModel(itemId, batch, serie, sequence), CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al remover el herraje.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden remover el herraje.",
                    "RemoveClamp");
            }
        }

        #endregion

        #region InspectionCMS

        public async Task RejectInspectionAsync(string itemId, string batch, int serie, string machine, string user, string card, string code, CancellationToken cancellation)
        {
            try
            {
                logger.LogInformation("Rechazando inspección.");

                await PostAsync($"inspectioncms/rejected/", new RejectInspectionParameter(itemId, batch, serie, machine, user, card, code), cancellation).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al rechazar la inspección.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden rechazar la inspección.",
                    "InspectionCMS");
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