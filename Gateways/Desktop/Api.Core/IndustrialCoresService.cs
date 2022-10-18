namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Cores;
    using Cores.Industrial.Commands;
    using Cores.Industrial.Models;
    using Cores.Industrial.Queries;

    using MediatR;

    using Microsoft.Extensions.Logging;

    public class IndustrialCoresService : IIndustrialCoresService
    {
        #region Fields

        private readonly IMediator mediator;
        private readonly ILogger<IndustrialCoresService> logger;

        #endregion

        #region Constructor

        public IndustrialCoresService(
            IMediator mediator,
            ILogger<IndustrialCoresService> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        #endregion

        #region Pattern

        public async Task<IndustrialCorePatternModel?> GetIndustrialCorePatternDesignAsync()
        {
            try
            {
                logger.LogInformation($"Consultando pruebas realizadas al núcleo patrón industrial.");

                return await mediator.Send(new IndustrialCorePatternQuery(), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar las pruebas realizadas al núcleo patrón industrial.");
                throw;
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

                return await mediator.Send(
                    new Cores.Industrial.Commands.TestIndustrialCorePatternCommand(
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
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón residencial.");
                throw;
            }
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<double>?> GetIndustrialCoreFoilWidthsAsync(string itemId, int coreSize)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los anchos de lamina para el artículo:{itemId} tamaño:{coreSize}.");
                return await mediator.Send(new IndustrialCoreFoilWidthsQuery(itemId, coreSize), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los anchos de lamina para el:{itemId} tamaño:{coreSize}.");
                throw;
            }
        }

        public async Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync(string itemId, int coreSize, double foilWidth)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información de diseño del artículo:{itemId} tamaño:{coreSize}.");

                return await mediator.Send(
                    new IndustrialCoreVoltageDesignQuery(
                        itemId,
                        coreSize,
                        foilWidth),
                    CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar la información de diseño del artículo:{itemId} tamaño:{coreSize}.");
                throw;
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
                logger.LogInformation("{message}", $"Consultando información sobre pruebas del núcleo con la orden '{itemId}-{batch}-{serie}'");

                return await mediator.Send(new IndustrialCoreTestSummaryQuery(itemId, batch, serie), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar información sobre pruebas del núcleo con la orden '{itemId}-{batch}-{serie}'");
                throw;
            }
        }

        public async Task<IndustrialCoreTestResultModel?> GetIndustrialCoreTestResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await mediator.Send(new IndustrialCoreTestResultQuery(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");
                throw;
            }
        }

        public async Task<IndustrialCoreTestModel?> GetIndustrialCoreTestAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await mediator.Send(new IndustrialCoreTestQuery(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");
                throw;
            }
        }

        public async Task<IndustrialCoreSuggestedCodeResultModel?> GetIndustrialCoreSuggestedCodeResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await mediator.Send(new IndustrialCoreSuggestedCodeResultQuery(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial");
                throw;
            }
        }

        public async Task<IndustrialCoreLocationResultModel?> GetIndustrialCoreLocationResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando la ubicacion del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial");

                return await mediator.Send(new IndustrialCoreLocationResultQuery(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial");
                throw;
            }
        }

        public async Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync(TestCoreParametersModel command, CancellationToken cancellationToken)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo con la orden '{command.ItemId}-{command.Batch}-{command.Serie}'");
                stringBuilder.AppendLine($"Tamaño dona: {command.CoreSize}");
                stringBuilder.AppendLine($"Ancho de lámina: {command.FoilWidth}");
                stringBuilder.AppendLine($"Tensión media: {command.AverageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {command.RMSVoltage}");
                stringBuilder.AppendLine($"Corriente: {command.Current}");
                stringBuilder.AppendLine($"Temperatura: {command.Temperature}");
                stringBuilder.AppendLine($"Watts: {command.Watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {command.CoreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

                return await mediator.Send(
                    new TestIndustrialCoreCommand(
                        command.ItemId,
                        command.Batch,
                        command.Serie,
                        command.CoreSize,
                        command.FoilWidth,
                        command.TestCode,
                        command.AverageVoltage,
                        command.RMSVoltage,
                        command.Current,
                        command.Temperature,
                        command.Watts,
                        command.CoreTemperature,
                        command.StationId),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con la orden '{command.ItemId}-{command.Batch}-{command.Serie}'.");
                throw;
            }
        }

        #endregion

        #region Store

        public async Task StoreIndustrialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                await mediator.Send(new StoreIndustrialCoreCommand(coreTestId, location, associatedCode, force), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");
                throw;
            }
        }

        #endregion
    }
}