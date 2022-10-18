namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cores.Industrial.Models;
    using Cores.Models;

    using Microsoft.Extensions.Logging;

    public class IndustrialCoresHttpService : Http.WebApiClient, IIndustrialCoresService
    {
        #region Fields

        private readonly ILogger<IndustrialCoresHttpService> logger;

        #endregion

        #region Constructor

        public IndustrialCoresHttpService(
           HttpClient httpClient,
           ILogger<IndustrialCoresHttpService> logger)
           : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/v1";
        }

        #endregion        

        #region Pattern

        public async Task<IndustrialCorePatternModel?> GetIndustrialCorePatternDesignAsync()
        {
            try
            {
                logger.LogInformation($"Consultando información del núcleo patrón industrial.");

                return await GetAsync<IndustrialCorePatternModel?>("cores/testing/industrial/pattern", CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar información del núcleo patrón industrial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se pueden consultar la información del núcleo patrón industrial en este momento.",
                    "ComponentsIndustrialCorePatternDesign");
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
                stringBuilder.AppendLine($"testCode: {testCode}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");
                stringBuilder.AppendLine($"StationId: {stationId}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<IndustrialCoreTestResultModel, TestCorePatternParametersModel>(
                    $"cores/testing/industrial/testpattern",
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
                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón industrial.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo patrón industrial en este momento.",
                    "ComponentsTestIndustrialCorePattern");
            }
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<double>?> GetIndustrialCoreFoilWidthsAsync(string itemId, int coreSize)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los anchos de lamina para el artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<IEnumerable<double>?>($"cores/testing/industrial/corefoilwidths/{itemId}/{coreSize}", CancellationToken.None).ConfigureAwait(false);
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
                    "ComponentsCoreFoilWidths");
            }
        }

        public async Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync(string itemId, int coreSize, double foilWidth)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de diseño del artículo:{itemId} tamaño:{coreSize}.");

                return await GetAsync<IndustrialItemVoltageDesignModel?>($"cores/testing/industrial/corevoltagedesign/{itemId}/{coreSize}/{foilWidth}", CancellationToken.None).ConfigureAwait(false);
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
                    "ComponentsIndustrialCoreVoltageDesign");
            }
        }

        #endregion

        #region Tests

        public async Task<IndustrialCoreTestSummaryModel?> GetIndustrialCoreTestSummaryAsync(
            string itemId,
            string batch,
            int serie,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información sobre pruebas del núcleo industrial con la orden '{itemId}-{batch}-{serie}'");

                return await GetAsync<IndustrialCoreTestSummaryModel?>($"cores/testing/industrial/summary/{itemId}/{batch}/{serie}", cancellationToken)
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
                    "ComponentsIndustrialCoreTestSummary");
            }
        }

        public async Task<IndustrialCoreTestResultModel?> GetIndustrialCoreTestResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await GetAsync<IndustrialCoreTestResultModel?>($"cores/testing/industrial/test/{testCode}", CancellationToken.None)
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
                    "GetIndustrialCoreTestResult");
            }
        }

        public async Task<IndustrialCoreTestModel?> GetIndustrialCoreTestAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await GetAsync<IndustrialCoreTestModel?>($"cores/testing/industrial/testcore/{testCode}", CancellationToken.None)
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
                    "GetIndustrialCoreTestResult");
            }
        }

        public async Task<IndustrialCoreSuggestedCodeResultModel?> GetIndustrialCoreSuggestedCodeResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await GetAsync<IndustrialCoreSuggestedCodeResultModel?>($"cores/testing/industrial/suggestedcode/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial en este momento.",
                    "IndustrialCoreSuggestedCodeResult");
            }
        }

        public async Task<IndustrialCoreLocationResultModel?> GetIndustrialCoreLocationResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await GetAsync<IndustrialCoreLocationResultModel?>($"cores/testing/industrial/location/{testCode}", CancellationToken.None)
                    .ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    $"No se pueden consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial en este momento.",
                    "IndustrialCoreLocationResult");
            }
        }

        public async Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync(TestCoreParametersModel command, CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo industrial con la orden '{command.ItemId}-{command.Batch}-{command.Serie}'");
                stringBuilder.AppendLine($"Tensión media: {command.AverageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {command.RMSVoltage}");
                stringBuilder.AppendLine($"Corriente: {command.Current}");
                stringBuilder.AppendLine($"Temperatura: {command.Temperature}");
                stringBuilder.AppendLine($"Watts: {command.Watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {command.CoreTemperature}");
                stringBuilder.AppendLine($"Estación: {command.StationId}");

                logger.LogInformation("{message}", stringBuilder.ToString());

#pragma warning disable CS8603 // Possible null reference return.
                return await PostAsync<IndustrialCoreTestResultModel, TestCoreParametersModel>(
                    $"cores/testing/industrial/test", command, cancellationToken)
                .ConfigureAwait(false);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo industrial con la orden '{command.ItemId}-{command.Batch}-{command.Serie}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede probar el núcleo industrial en este momento.",
                    "ComponentsIndustrialCore");
            }
        }

        #endregion

        #region Store

        public async Task StoreIndustrialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                await PostAsync($"cores/testing/industrial/store", new StoreCoreParametersModel(coreTestId, location, associatedCode, force), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede acomodar el núcleo en este momento.",
                    "StoreIndustrialCore");
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