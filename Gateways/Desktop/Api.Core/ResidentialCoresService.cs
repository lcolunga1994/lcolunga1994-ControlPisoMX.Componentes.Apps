namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using Cores.Models;
    using Cores.Residential.Commands;
    using Cores.Residential.Models;
    using Cores.Residential.Queries;
    using Cores.Supply.Models;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using Microsoft.Extensions.Configuration;

    public class ResidentialCoresService : IResidentialCoresService
    {
        #region Fields

        private readonly IServiceProvider serviceProvider;
        private readonly IMediator mediator;
        private readonly ILogger<ResidentialCoresService> logger;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public ResidentialCoresService(
            IServiceProvider serviceProvider,
            IMediator mediator,
            ILogger<ResidentialCoresService> logger,
            IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            this.mediator = mediator;
            this.logger = logger;
            _configuration = configuration;
        }

        #endregion

        #region Item design

        public async Task<ItemModel?> GetItemAsync(string itemId)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando información del artículo '{itemId}'.");

                return await mediator.Send(new ItemQuery(itemId), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar la información del artículo:{itemId}.");
                throw;
            }
        }

        public async Task<CoreVoltageDesignModel?> GetResidentialCoreVoltageDesignAsync(
            string itemId,
            int coreSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el diseño del voltaje: artículo:{itemId} tamaño:{coreSize}.");

                return await mediator.Send(
                    new CoreVoltageDesignQuery(itemId, coreSize),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el diseño del voltaje: artículo:{itemId} tamaño:{coreSize}.");
                throw;
            }
        }

        #endregion

        #region Plan

        public async Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync()
        {
            try
            {
                logger.LogInformation($"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                IEnumerable<ControlPisoMX.Cores.Models.DateRangeAvailableModel> dateRangeAvailable = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                    await cores.GetDateRangeAvailableForTestQueryAsync()
                    .ConfigureAwait(false)
                    : await cores.GetDateRangeAvailableForTestQueryAsync_discpiso()
                    .ConfigureAwait(false);

                return dateRangeAvailable
                    .Select(item => new DateRangeAvailableModel(item.ProductLine, item.StartUtcDate, item.EndUtcDate))
                    .ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el rango de fechas disponibles para probar en el plan de fabricación.");
                throw;
            }
        }
        public async Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync_discpiso()
        {
            try
            {
                logger.LogInformation($"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                IEnumerable<ControlPisoMX.Cores.Models.DateRangeAvailableModel> dateRangeAvailable = await cores.GetDateRangeAvailableForTestQueryAsync_discpiso()
                    .ConfigureAwait(false);

                return dateRangeAvailable
                    .Select(item => new DateRangeAvailableModel(item.ProductLine, item.StartUtcDate, item.EndUtcDate))
                    .ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el rango de fechas disponibles para probar en el plan de fabricación.");
                throw;
            }
        }

        public async Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                ControlPisoMX.Cores.QueryResult<string> items = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                    await cores.GetItemsPlannedToBeTestedAsync(page, pageSize, cancellationToken)
                    .ConfigureAwait(false)
                    : await cores.GetItemsPlannedToBeTestedAsync_discpiso(page, pageSize, cancellationToken)
                    .ConfigureAwait(false);

                return new Cores.QueryResult<string>(items.Data, items.Count);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");
                throw;
            }
        }
        public async Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync_discpiso(int page, int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                ControlPisoMX.Cores.QueryResult<string> items = await cores.GetItemsPlannedToBeTestedAsync_discpiso(page, pageSize, cancellationToken)
                    .ConfigureAwait(false);

                return new Cores.QueryResult<string>(items.Data, items.Count);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");
                throw;
            }
        }
        public async Task<Cores.QueryResult<string>> GetItemsPlannedToBeManufacturedAsync_discpiso_AMO(int page, int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                ControlPisoMX.Cores.QueryResult<string> items = await cores.GetItemsPlannedToBeTestedAsync_discpiso_AMO(page, pageSize, cancellationToken)
                    .ConfigureAwait(false);

                return new Cores.QueryResult<string>(items.Data, items.Count);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");
                throw;
            }
        }

        public async Task<Cores.QueryResult<ManufacturedResidentialCoreModel>> GetManufacturedCoresAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de pruebas de los núcleos: página:{page} tamaño:{pageSize}.");

                return await mediator.Send(
                    new Cores.Queries.ManufacturedCoresQuery(page, pageSize),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el plan de pruebas de núcleos: página:{page} tamaño:{pageSize}.");
                throw;
            }
        }

        public async Task<CoreManufacturingPlanModel?> GetNextCoreToBeManufacturedAsync(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación del artículo '{itemId}'.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                return await mediator.Send(new NextItemSequenceInPlanQuery(itemId), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el plan de fabricación  del artículo '{itemId}'.");
                throw;
            }
        }
        public async Task<CoreManufacturingPlanModel?> GetNextCoreToBeManufacturedAsync_AMO(string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el plan de fabricación del artículo '{itemId}'.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                return await mediator.Send(new NextItemSequenceInPlanQuery_AMO(itemId), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el plan de fabricación  del artículo '{itemId}'.");
                throw;
            }
        }

        #endregion

        #region Pattern

        public async Task<ResidentialCorePatternTestsSummaryModel?> GetResidentialCorePatternTestSummaryAsync()
        {
            try
            {
                logger.LogInformation($"Consultando pruebas realizadas al núcleo patrón residencial.");

                return await mediator.Send(new Cores.Queries.ResidentialCorePatternTestsSummaryQuery(), CancellationToken.None)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    $"Ocurrió un error al consultar las pruebas realizadas al núcleo patrón residencial.");
                throw;
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

                logger.LogInformation("{message}", stringBuilder.ToString());

                return await mediator.Send(new Cores.Commands.TestResidentialCorePatternCommand(
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

                return await mediator
                    .Send(new Cores.Queries.ResidentialCoreTestSummaryQuery(
                        itemId,
                        batch,
                        serie,
                        sequence), cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");
                throw;
            }
        }

        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode)
        {
            try
            {
                return bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ? await mediator.Send(new ResidentialCoreTestQuery(testCode), CancellationToken.None)
                     : await mediator.Send(new ResidentialCoreTestQuery_discpiso(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial", testCode);
                throw;
            }
        }
        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync_discpiso(string testCode)
        {
            try
            {
                return await mediator.Send(new ResidentialCoreTestQuery_discpiso(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial", testCode);
                throw;
            }
        }

        public async Task<ResidentialCoreSuggestedCodeResultModel?> GetResidentialCoreSuggestedCodeResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await mediator.Send(new ResidentialCoreSuggestedCodeResultQuery(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial");
                throw;
            }
        }

        public async Task<ResidentialCoreLocationResultModel?> GetResidentialCoreLocationResultAsync(string testCode)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial");

                return await mediator.Send(new ResidentialCoreLocationResultQuery(testCode), CancellationToken.None);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "{message}", $"Ocurrió un error al consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial");
                throw;
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
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo con el artículo '{itemId}':");
                stringBuilder.AppendLine($"Tamaño dona: {coreSize}");
                stringBuilder.AppendLine($"Etiqueta: {tag}");
                stringBuilder.AppendLine($"Código: {testCode}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

                return await mediator.Send(
                    new Cores.Commands.TestResidentialCoreCommand(
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
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con el artículo '{itemId}'.");
                throw;
            }
        }

        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync_AMO(
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
                System.Text.StringBuilder stringBuilder = new($"Probando núcleo con el artículo '{itemId}':");
                stringBuilder.AppendLine($"Tamaño dona: {coreSize}");
                stringBuilder.AppendLine($"Etiqueta: {tag}");
                stringBuilder.AppendLine($"Código: {testCode}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

                return await mediator.Send(
                    new Cores.Commands.TestResidentialCoreCommand_AMO(
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
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo con el artículo '{itemId}'.");
                throw;
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
                System.Text.StringBuilder stringBuilder = new($"Retrabajo para el artículo'{itemId}':");
                stringBuilder.AppendLine($"Código: {testCode}");
                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
                stringBuilder.AppendLine($"Corriente: {current}");
                stringBuilder.AppendLine($"Temperatura: {temperature}");
                stringBuilder.AppendLine($"Watts: {watts}");
                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

                logger.LogInformation("{message}", stringBuilder.ToString());

                return await mediator.Send(
                    new Cores.Commands.ReworkResidentialCoreCommand(
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
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al probar el núcleo '{itemId}' (retrabajo).");
                throw;
            }
        }

        #endregion

        #region Defects

        public async Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectConceptListAsync(
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando el listado de defedectos registrados: página:{page} tamaño:{pageSize}.");

                return await mediator.Send(
                    new Cores.Queries.DefectConceptQuery(page, pageSize),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al consultar el listado de defedectos registrados: página:{page} tamaño:{pageSize}.");
                throw;
            }
        }

        public async Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
            string testCode,
            string defect,
            CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Registrando defecto para el núcleo con la etiqueta '{testCode}' ({defect}).");

                return await mediator.Send(
                    new Cores.Commands.RegisterDefectCommand(testCode, defect),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", $"Ocurrió un error al registrar un defecto para el núcleo con la etiqueta '{testCode}' ({defect}).");
                throw;
            }
        }

        #endregion

        #region Store

        public async Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

                await mediator
                    .Send(new StoreResidentialCoreCommand(
                            coreTestId,
                            location ?? throw new UserException("La ubicación es requerida."),
                            associatedCode,
                            force),
                        cancellationToken);
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

        #region Supply        

        public async Task<IEnumerable<InsulationMachineModel>> GetWindingMachinesAsync(CancellationToken cancellationToken)
        {
            try
            {
                ProlecGE.ControlPisoMX.Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<ProlecGE.ControlPisoMX.Insulations.IMicroservice>();

                return (bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ? 
                      await insulations.GetMachinesAsync(cancellationToken).ConfigureAwait(false)
                    : await insulations.GetMachinesAsync_sqlctp(cancellationToken).ConfigureAwait(false))
                    .Select(e => new InsulationMachineModel(e.Number, e.Available))
                    .ToArray();
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "Ocurrió un error al consultar las maquinas CMS.");
                }
                throw;
            }
        }

        public async Task<IEnumerable<ResidentialSuppliedCoreTestModel>> GetResidentialCoreSupplyByOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Consultando los núcleos relacionados a la orden -{itemId}-{batch}-{serie}-.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                return (await cores.GetResidentialCoreSupplyByOrderAsync(itemId, batch, serie, cancellationToken)
                    .ConfigureAwait(false))
                    .Select(e => new ResidentialSuppliedCoreTestModel(e.ItemId, e.Batch, e.Serie, e.Serie, e.Identifier, e.WattsCorr, e.Color, e.SupplyUtcDate, e.Id, e.Tag)
                    );
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "{message}", $"Ocurrió un error al consultar los núcleos relacionados a la orden -{itemId}-{batch}-{serie}-.");
                }
                throw;
            }
        }

        public async Task AddSupplyCoreAsync(AddSupplyCoreModel supply, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Agregando suministro de núcleo -{supply.ItemId}-{supply.Batch}-{supply.Serie}-{supply.TestCode}.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();
                if(bool.Parse(_configuration.GetSection("UseBaan").Value.ToString())) { 
                     await cores.AddSupplyCoreAsync(new ControlPisoMX.Cores.Models.Residential.AddSupplyCoreModel(supply.ItemId, supply.Batch,
                                    supply.Serie, supply.TestCode, supply.User), cancellationToken)
                    .ConfigureAwait(false);
                }
                else 
                { 
                    await cores.AddSupplyCoreAsync_sqlctp(new ControlPisoMX.Cores.Models.Residential.AddSupplyCoreModel(supply.ItemId, supply.Batch,
                                    supply.Serie, supply.TestCode, supply.User), cancellationToken)
                    .ConfigureAwait(false);
                }

            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "{message}", $"Ocurrió un error al agregar suministro de núcleo {supply.ItemId}-{supply.Batch}-{supply.Serie}-{supply.TestCode}.");
                }
                throw;
            }
        }

        public async Task RemoveSupplyCoreAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("{message}", $"Removiendo suministro de núcleo -{id}.");

                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

                
                if(bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()))
                {
                    await cores.RemoveSupplyCoreAsync(id, cancellationToken)
                .ConfigureAwait(false);
                }
                else
                {
                    await cores.RemoveSupplyCoreAsync_sqlctp(id, cancellationToken)
                .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                if (ex is not UserException)
                {
                    logger.LogError(ex, "{message}", $"Ocurrió un error al remover el suministro de núcleo -{id}.");
                }
                throw;
            }
        }

        #endregion
    }
}