//namespace ProlecGE.ControlPisoMX.BFWeb.Components
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Threading;
//    using System.Threading.Tasks;

//    using MediatR;

//    using Microsoft.Extensions.DependencyInjection;
//    using Microsoft.Extensions.Logging;

//    using ProlecGE.ControlPisoMX;
//    using ProlecGE.ControlPisoMX.BFWeb.Components.Clamps.Queries;
//    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Industrial.Queries;
//    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Commands;
//    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries;
//    using ProlecGE.ControlPisoMX.BFWeb.Components.Models;

//    using ProlecGE.ControlPisoMX.Gateways.Components.Cores.Industrial.Models;
//    using ProlecGE.ControlPisoMX.Gateways.Components.Cores.Models;
//    using ProlecGE.ControlPisoMX.Gateways.Components.Cores.Residential.Models;
//    using ProlecGE.ControlPisoMX.Gateways.Components.Insulations.Models;
//    using ProlecGE.ControlPisoMX.Gateways.Components.Summary.Models;

//    public class ComponentsGateway : IComponentsGateway, IClampsService
//    {
//        #region Fields

//        private readonly IServiceProvider serviceProvider;
//        private readonly IMediator mediator;
//        private readonly ILogger<ComponentsGateway> logger;

//        #endregion

//        #region Constructor

//        public ComponentsGateway(
//            IServiceProvider serviceProvider,
//            IMediator mediator,
//            ILogger<ComponentsGateway> logger)
//        {
//            this.serviceProvider = serviceProvider;
//            this.mediator = mediator;
//            this.logger = logger;
//        }

//        #endregion

//        #region ERP

//        public async Task<ERP.Models.ItemModel?> GetItemAsync(string itemId)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información del artículo '{itemId}'.");

//                return await mediator.Send(new ERP.Queries.ItemQuery(itemId), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar la información del artículo:{itemId}.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<ERP.Models.CartonShearModel>> GetItemCartonShearsAsync(string itemId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de los materiales de cizalla '{itemId}'.");

//                return await mediator.Send(new ERP.Queries.CartonShearsQuery(itemId), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de cizalla:{itemId}.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<ERP.Models.GuillotineShearModel>> GetItemGuillotineShearsAsync(string itemId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de los materiales de guillotina '{itemId}'.");

//                return await mediator.Send(new ERP.Queries.GuillotineShearsQuery(itemId), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de guillotina: {itemId}.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<ERP.Models.SierraShearModel>> GetItemSierraShearsAsync(string itemId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de los materiales de sierra '{itemId}'.");

//                return await mediator.Send(new ERP.Queries.SierraShearsQuery(itemId), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de sierra:{itemId}.");
//                throw;
//            }
//        }

//        public async Task<ERP.Models.AluminumTipPuntasModel?> GetItemAluminumTipsAsync(string itemId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de los materiales de cizalla '{itemId}'.");

//                return await mediator.Send(new ERP.Queries.ItemAluminumTipsQuery(itemId), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar los materiales de cizalla:{itemId}.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<ERP.Models.AluminiumCutModel>> GetItemAluminiumCutsAsync(string itemId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de los cortes de puntas de aluminio '{itemId}'.");

//                return await mediator.Send(new ERP.Queries.AluminiumCutsQuery(itemId), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar de los cortes de puntas de aluminio:{itemId}.");
//                throw;
//            }
//        }

//        #endregion

//        #region Cores

//        #region Residential

//        #region Plan

//        public async Task<IEnumerable<DateRangeAvailableModel>> GetDateRangeAvailableForTestQueryAsync()
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el rango de fechas disponibles para probar en el plan de fabricación.");

//                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

//                IEnumerable<ControlPisoMX.Cores.Models.DateRangeAvailableModel> dateRangeAvailable = await cores.GetDateRangeAvailableForTestQueryAsync()
//                    .ConfigureAwait(false);

//                return dateRangeAvailable
//                    .Select(item => new DateRangeAvailableModel(item.ProductLine, item.StartUtcDate, item.EndUtcDate))
//                    .ToList();
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar el rango de fechas disponibles para probar en el plan de fabricación.");
//                throw;
//            }
//        }

//        public async Task<QueryResult<string>> GetItemsPlannedToBeManufacturedAsync(int page, int pageSize, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");

//                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

//                return await cores.GetItemsPlannedToBeTestedAsync(page, pageSize, cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar los artículos planeados para la fabricación de núcleos: página:{page} tamaño:{pageSize}.");
//                throw;
//            }
//        }

//        public async Task<QueryResult<ManufacturedResidentialCoreModel>> GetManufacturedCoresAsync(
//            int page,
//            int pageSize,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el plan de pruebas de los núcleos: página:{page} tamaño:{pageSize}.");

//                return await mediator.Send(
//                    new Cores.Queries.ManufacturedCoresQuery(page, pageSize),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar el plan de pruebas de núcleos: página:{page} tamaño:{pageSize}.");
//                throw;
//            }
//        }

//        public async Task<CoreManufacturingPlanModel?> GetNextCoreToBeManufacturedAsync(string itemId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el plan de fabricación del artículo '{itemId}'.");

//                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

//                return await mediator.Send(new NextItemSequenceInPlanQuery(itemId), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el plan de fabricación  del artículo '{itemId}'.");
//                throw;
//            }
//        }

//        #endregion

//        #region Pattern

//        public async Task<ResidentialCorePatternTestsSummaryModel?> GetResidentialCorePatternTestSummaryAsync()
//        {
//            try
//            {
//                logger.LogInformation($"Consultando pruebas realizadas al núcleo patrón residencial.");

//                return await mediator.Send(new Cores.Queries.ResidentialCorePatternTestsSummaryQuery(), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar las pruebas realizadas al núcleo patrón residencial.");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreTestResultModel> TestResidentialCorePatternAsync(
//           string testCode,
//           double averageVoltage,
//           double rmsVoltage,
//           double current,
//           double temperature,
//           double watts,
//           double coreTemperature,
//           string? stationId,
//           CancellationToken cancellationToken)
//        {
//            try
//            {
//                System.Text.StringBuilder stringBuilder = new($"Probando núcleo patrón residencial:");
//                stringBuilder.AppendLine($"testCode: {testCode}");
//                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
//                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
//                stringBuilder.AppendLine($"Corriente: {current}");
//                stringBuilder.AppendLine($"Temperatura: {temperature}");
//                stringBuilder.AppendLine($"Watts: {watts}");
//                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");
//                stringBuilder.AppendLine($"StationId: {stationId}");

//                logger.LogInformation(stringBuilder.ToString());

//                return await mediator.Send(new Cores.Commands.TestResidentialCorePatternCommand(
//                        testCode,
//                        averageVoltage,
//                        rmsVoltage,
//                        current,
//                        temperature,
//                        watts,
//                        coreTemperature,
//                        stationId),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón residencial.");
//                throw;
//            }
//        }

//        #endregion

//        #region Queries

//        public async Task<ERP.Models.ItemVoltageDesignModel?> GetResidentialCoreVoltageDesignAsync(
//            string itemId,
//            CoreSizes coreSize,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el diseño del voltaje: artículo:{itemId} tamaño:{coreSize}.");

//                return await mediator.Send(
//                    new ERP.Queries.ItemVoltageDesignQuery(
//                        itemId,
//                        coreSize),
//                    cancellationToken);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar el diseño del voltaje: artículo:{itemId} tamaño:{coreSize}.");
//                throw;
//            }
//        }

//        #endregion

//        #region Tests

//        public async Task<ResidentialCoreTestSummaryModel?> GetResidentialCoreTestSummaryAsync(
//            string itemId,
//            string batch,
//            int serie,
//            int sequence,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");

//                return await mediator
//                    .Send(new Cores.Queries.ResidentialCoreTestSummaryQuery(
//                        itemId,
//                        batch,
//                        serie,
//                        sequence), cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el total de piezas aprobadas de la unidad '{itemId}-{batch}-{serie}' secuencia {sequence}.");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreTestModel?> GetResidentialCoreTestAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");

//                return await mediator.Send(new ResidentialCoreTestQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el resultado de la prueba con código '{testCode}' realizada a un núcleo residencial");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreSuggestedCodeResultModel?> GetResidentialCoreSuggestedCodeResultAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial");

//                return await mediator.Send(new ResidentialCoreSuggestedCodeResultQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo residencial");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreLocationResultModel?> GetResidentialCoreLocationResultAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial");

//                return await mediator.Send(new ResidentialCoreLocationResultQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo residencial");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreTestResultModel> TestResidentialCoreAsync(
//            string? tag,
//            string itemId,
//            CoreSizes coreSize,
//            double averageVoltage,
//            double rmsVoltage,
//            double current,
//            double temperature,
//            double watts,
//            double coreTemperature,
//            string testCode,
//            string? stationId,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                System.Text.StringBuilder stringBuilder = new($"Probando núcleo con el artículo '{itemId}':");
//                stringBuilder.AppendLine($"Tamaño dona: {coreSize}");
//                stringBuilder.AppendLine($"Etiqueta: {tag}");
//                stringBuilder.AppendLine($"Código: {testCode}");
//                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
//                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
//                stringBuilder.AppendLine($"Corriente: {current}");
//                stringBuilder.AppendLine($"Temperatura: {temperature}");
//                stringBuilder.AppendLine($"Watts: {watts}");
//                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

//                logger.LogInformation(stringBuilder.ToString());

//                return await mediator.Send(
//                    new Cores.Commands.TestResidentialCoreCommand(
//                        tag,
//                        itemId,
//                        coreSize,
//                        averageVoltage,
//                        rmsVoltage,
//                        current,
//                        temperature,
//                        watts,
//                        coreTemperature,
//                        testCode,
//                        stationId),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al probar el núcleo con el artículo '{itemId}'.");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreTestResultModel> ReworkResidentialCoreAsync(
//            string itemId,
//            CoreSizes coreSize,
//            double averageVoltage,
//            double rmsVoltage,
//            double current,
//            double temperature,
//            double watts,
//            double coreTemperature,
//            string testCode,
//            string? stationId,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                System.Text.StringBuilder stringBuilder = new($"Retrabajo para el artículo'{itemId}':");
//                stringBuilder.AppendLine($"Código: {testCode}");
//                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
//                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
//                stringBuilder.AppendLine($"Corriente: {current}");
//                stringBuilder.AppendLine($"Temperatura: {temperature}");
//                stringBuilder.AppendLine($"Watts: {watts}");
//                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");

//                logger.LogInformation(stringBuilder.ToString());

//                return await mediator.Send(
//                    new Cores.Commands.ReworkResidentialCoreCommand(
//                        itemId,
//                        coreSize,
//                        averageVoltage,
//                        rmsVoltage,
//                        current,
//                        temperature,
//                        watts,
//                        coreTemperature,
//                        testCode,
//                        stationId),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al probar el núcleo '{itemId}' (retrabajo).");
//                throw;
//            }
//        }

//        #endregion

//        #region Defects

//        public async Task<IEnumerable<CoreTestDefectConceptModel>> GetDefectConceptListAsync(
//            int page,
//            int pageSize,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el listado de defedectos registrados: página:{page} tamaño:{pageSize}.");

//                return await mediator.Send(
//                    new Cores.Queries.DefectConceptQuery(page, pageSize),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar el listado de defedectos registrados: página:{page} tamaño:{pageSize}.");
//                throw;
//            }
//        }

//        public async Task<ResidentialCoreTestResultModel> RegisterDefectAsync(
//            string testCode,
//            string defect,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Registrando defecto para el núcleo con la etiqueta '{testCode}' ({defect}).");

//                return await mediator.Send(
//                    new Cores.Commands.RegisterDefectCommand(testCode, defect),
//                    cancellationToken);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al registrar un defecto para el núcleo con la etiqueta '{testCode}' ({defect}).");
//                throw;
//            }
//        }

//        #endregion

//        #region Store

//        public async Task StoreResidentialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

//                await mediator.Send(new StoreResidentialCoreCommand(coreTestId, location, associatedCode, force), cancellationToken);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");
//                throw;
//            }
//        }

//        #endregion

//        #region Supply

//        public async Task<IEnumerable<ResidentialOrderAvailableToSupplyModel>> GetOrdersAvailableToSupplyCoresAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando las ordenes disponibles para suministrar núcleos.");

//                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

//                return (await cores.GetResidentialOrdersAvailableToSupplyAsync(cancellationToken)
//                    .ConfigureAwait(false))
//                    .Select(e => new ResidentialOrderAvailableToSupplyModel(e.ItemId, e.Batch, e.Serie, e.Machine, e.ScheduleUtcDate)
//                    {
//                        Line = e.Line
//                    });
//            }
//            catch (Exception ex)
//            {
//                if (ex is not UserException)
//                {
//                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes disponibles para suministrar núcleos.");
//                }
//                throw;
//            }
//        }

//        public async Task AddResidentialOrdersToSupplyListAsync(List<OrderToSupplyModel> orders, CancellationToken cancellationToken)
//        {
//            try
//            {
//                await mediator
//                    .Send(new AddOrderToSupplyListCommand(orders), cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                if (ex is not UserException)
//                {
//                    logger.LogError(ex, "Ocurrió un error al registrar las ordenes como disponibles para suministrar núcleos.");
//                }
//                throw;
//            }
//        }

//        public async Task<IEnumerable<OrderPrintableAttributeModel>> GetSupplyCoresAsync(List<ResidentialOrderAvailableToSupplyModel> order, CancellationToken cancellationToken)
//        {
//            try
//            {
//                #region Dummy data
//                return await Task.FromResult(new List<OrderPrintableAttributeModel>()
//                {
//                    //ANL471
//                new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Line",
//                    Value="1"
//                },
//                 new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Fecha",
//                    Value=DateTime.UtcNow.ToString("s")//se debe transformar a local en el frente
//                },
//                  new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Color",
//                    Value="Amarillo"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Strip",
//                    Value="A=10.45"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Dimensiones",
//                    Value="18"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Sec",
//                    Value="187"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Market",
//                    Value="Exp"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Pilot",
//                    Value="TST"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Devanadora",
//                    Value="1537"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Type",
//                    Value="POSTE"
//                }
//                   ,
//                   //ANH339
//                 new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Line",
//                    Value="1"
//                },
//                 new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Fecha",
//                    Value=DateTime.UtcNow.ToString("s")//se debe transformar a local en el frente
//                },
//                  new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Color",
//                    Value="Amarillo"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Strip",
//                    Value="A=55.4"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Dimensiones",
//                    Value="18"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Sec",
//                    Value="187"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Market",
//                    Value="Exp"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Pilot",
//                    Value=" "
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANH339",
//                    Batch="160",
//                    Serie=51,
//                    Attibute="Devanadora",
//                    Value="1537"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Type",
//                    Value="POSTE"
//                }
//                   ,
//                   //ANH339
//                 new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Line",
//                    Value="1"
//                },
//                 new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Fecha",
//                    Value=DateTime.UtcNow.ToString("s")//se debe transformar a local en el frente
//                },
//                  new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Color",
//                    Value="Amarillo"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Strip",
//                    Value="A=12.7"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Dimensiones",
//                    Value="18"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Sec",
//                    Value="187"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Market",
//                    Value="Exp"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Pilot",
//                    Value=" "
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="PCL753",
//                    Batch="333",
//                    Serie=18,
//                    Attibute="Devanadora",
//                    Value="1537"
//                },
//                   new OrderPrintableAttributeModel()
//                {
//                    ItemId="ANL471",
//                    Batch="251",
//                    Serie=1,
//                    Attibute="Type",
//                    Value="POSTE"
//                }
//                });
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                if (ex is not UserException)
//                {
//                    logger.LogError(ex, "Ocurrió un error al suministrar los núcleos.");
//                }
//                throw;
//            }
//        }

//        #endregion

//        #endregion

//        #region Industrial

//        #region Pattern

//        public async Task<IndustrialCorePatternModel?> GetIndustrialCorePatternDesignAsync()
//        {
//            try
//            {
//                logger.LogInformation($"Consultando pruebas realizadas al núcleo patrón industrial.");

//                return await mediator.Send(new IndustrialCorePatternQuery(), CancellationToken.None)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar las pruebas realizadas al núcleo patrón industrial.");
//                throw;
//            }
//        }

//        public async Task<IndustrialCoreTestResultModel> TestIndustrialCorePatternAsync(
//           string testCode,
//           double averageVoltage,
//           double rmsVoltage,
//           double current,
//           double temperature,
//           double watts,
//           double coreTemperature,
//           string? stationId,
//           CancellationToken cancellationToken)
//        {
//            try
//            {
//                System.Text.StringBuilder stringBuilder = new($"Probando núcleo patrón industrial:");
//                stringBuilder.AppendLine($"testCode: {testCode}");
//                stringBuilder.AppendLine($"Tensión media: {averageVoltage}");
//                stringBuilder.AppendLine($"Tensión eficaz: {rmsVoltage}");
//                stringBuilder.AppendLine($"Corriente: {current}");
//                stringBuilder.AppendLine($"Temperatura: {temperature}");
//                stringBuilder.AppendLine($"Watts: {watts}");
//                stringBuilder.AppendLine($"Temperatura Termopar: {coreTemperature}");
//                stringBuilder.AppendLine($"StationId: {stationId}");

//                logger.LogInformation(stringBuilder.ToString());

//                return await mediator.Send(
//                    new Cores.Industrial.Commands.TestIndustrialCorePatternCommand(
//                        testCode,
//                        averageVoltage,
//                        rmsVoltage,
//                        current,
//                        temperature,
//                        watts,
//                        coreTemperature,
//                        stationId),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al probar el núcleo patrón residencial.");
//                throw;
//            }
//        }

//        #endregion

//        #region Queries

//        public async Task<IEnumerable<double>?> GetIndustrialCoreFoilWidthsAsync(string itemId, CoreSizes coreSize)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando los anchos de lamina para el artículo:{itemId} tamaño:{coreSize}.");
//                return await mediator.Send(new IndustrialCoreFoilWidthsQuery(itemId, coreSize), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar los anchos de lamina para el:{itemId} tamaño:{coreSize}.");
//                throw;
//            }
//        }

//        public async Task<IndustrialItemVoltageDesignModel?> GetIndustrialCoreVoltageDesignAsync(string itemId, CoreSizes coreSize, double foilWidth)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de diseño del artículo:{itemId} tamaño:{coreSize}.");

//                return await mediator.Send(
//                    new IndustrialCoreVoltageDesignQuery(
//                        itemId,
//                        coreSize,
//                        foilWidth),
//                    CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al consultar la información de diseño del artículo:{itemId} tamaño:{coreSize}.");
//                throw;
//            }
//        }

//        #endregion

//        #region Tests

//        public async Task<IndustrialCoreTestSummaryModel?> GetIndustrialCoreTestSummaryAsync(
//            string itemId,
//            string batch,
//            int serie,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información sobre pruebas del núcleo con la orden '{itemId}-{batch}-{serie}'");

//                return await mediator.Send(new IndustrialCoreTestSummaryQuery(itemId, batch, serie), cancellationToken);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar información sobre pruebas del núcleo con la orden '{itemId}-{batch}-{serie}'");
//                throw;
//            }
//        }

//        public async Task<IndustrialCoreTestResultModel?> GetIndustrialCoreTestResultAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");

//                return await mediator.Send(new IndustrialCoreTestResultQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");
//                throw;
//            }
//        }

//        public async Task<IndustrialCoreTestModel?> GetIndustrialCoreTestAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");

//                return await mediator.Send(new IndustrialCoreTestQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el resultado para la prueba con código '{testCode}' realizada a un núcleo industrial");
//                throw;
//            }
//        }

//        public async Task<IndustrialCoreSuggestedCodeResultModel?> GetIndustrialCoreSuggestedCodeResultAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial");

//                return await mediator.Send(new IndustrialCoreSuggestedCodeResultQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el código sugerido para la prueba con código '{testCode}' realizada a un núcleo industrial");
//                throw;
//            }
//        }

//        public async Task<IndustrialCoreLocationResultModel?> GetIndustrialCoreLocationResultAsync(string testCode)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando la ubicacion del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial");

//                return await mediator.Send(new IndustrialCoreLocationResultQuery(testCode), CancellationToken.None);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar la ubicación del núcleo para la prueba con código '{testCode}' realizada a un núcleo industrial");
//                throw;
//            }
//        }

//        public async Task<IndustrialCoreTestResultModel> TestIndustrialCoreAsync(
//            Gateways.Components.Cores.Industrial.Commands.TestIndustrialCoreCommand command,
//            CancellationToken cancellationToken)
//        {
//            try
//            {
//                System.Text.StringBuilder stringBuilder = new($"Probando núcleo con la orden '{command.ItemId}-{command.Batch}-{command.Serie}'");
//                stringBuilder.AppendLine($"Tamaño dona: {command.CoreSize}");
//                stringBuilder.AppendLine($"Ancho de lámina: {command.FoilWidth}");
//                stringBuilder.AppendLine($"Tensión media: {command.AverageVoltage}");
//                stringBuilder.AppendLine($"Tensión eficaz: {command.RMSVoltage}");
//                stringBuilder.AppendLine($"Corriente: {command.Current}");
//                stringBuilder.AppendLine($"Temperatura: {command.Temperature}");
//                stringBuilder.AppendLine($"Watts: {command.Watts}");
//                stringBuilder.AppendLine($"Temperatura Termopar: {command.CoreTemperature}");

//                logger.LogInformation(stringBuilder.ToString());

//                return await mediator.Send(
//                    new Cores.Industrial.Commands.TestIndustrialCoreCommand(
//                        command.ItemId,
//                        command.Batch,
//                        command.Serie,
//                        command.CoreSize,
//                        command.FoilWidth,
//                        command.TestCode,
//                        command.AverageVoltage,
//                        command.RMSVoltage,
//                        command.Current,
//                        command.Temperature,
//                        command.Watts,
//                        command.CoreTemperature,
//                        command.StationId),
//                    cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al probar el núcleo con la orden '{command.ItemId}-{command.Batch}-{command.Serie}'.");
//                throw;
//            }
//        }

//        #endregion

//        #region Store

//        public async Task StoreIndustrialCoreAsync(Guid coreTestId, string location, string? associatedCode, bool force, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Acomodando el núcleo con identificador '{coreTestId}' en la ubicación '{location}'.");

//                await mediator.Send(new Cores.Industrial.Commands.StoreIndustrialCoreCommand(coreTestId, location, associatedCode, force), cancellationToken);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al acomodar el núcleo con identificador '{coreTestId}'.");
//                throw;
//            }
//        }

//        #endregion

//        #endregion

//        #endregion

//        #region Clamps

//        public async Task<IEnumerable<OrderWithClampsModel>> GetOrdersToPlaceClampsAsync()
//        {
//            try
//            {
//                return await mediator.Send(new OrdersToPlaceClampsQuery(), CancellationToken.None).ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                if (ex is not UserException)
//                {
//                    logger.LogError(ex, "Ocurrió un error al consultar las ordenes a las que no se les han colocado los herrajes.");
//                }
//                throw;
//            }
//        }

//        #endregion

//        #region Insulations

//        #region Security

//        public async Task<string> GetUserAsync(string username, string password, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el usuario.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return await insulations.GetUserAsync(username, password, cancellationToken).ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al tratar de consultar el usuario");
//                throw;
//            }
//        }

//        public async Task<bool> ValidateUserPasswordAsync(string username, string password, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Validando usuario.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return await insulations.ValidateUserPasswordAsync(username, password, cancellationToken).ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al tratar de validar el usuario");
//                throw;
//            }
//        }

//        #endregion

//        #region Configurations

//        public async Task<bool> IsManufacturingAllowedAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando el estado de las labores");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return await insulations.IsManufacturingAllowedAsync(cancellationToken).ConfigureAwait(false);

//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el estado de la labores");
//                throw;
//            }
//        }

//        public async Task ChangeAllowManufacturingAsync(bool allow, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Suspendiendo/iniciar labores.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                await insulations.ChangeAllowManufacturingAsync(allow, cancellationToken)
//                .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al tratar  de suspender/iniciar labores");
//                throw;
//            }
//        }

//        public async Task<int?> GetMinimumManufactureMinutesAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando minutos minimos por orden.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                int? minutes = await insulations.GetMinimumManufactureMinutesAsync(cancellationToken)
//                    .ConfigureAwait(false);

//                if (minutes == null)
//                {
//                    logger.LogInformation($"No se encontró el minimo de minutos por orden.");
//                }

//                return minutes;
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar el minimo de minutos por orden.");
//                throw;
//            }
//        }

//        public async Task<int> GetManufacturingMinutesAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando minutos asignados para ordenes.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                int minutes = await insulations.GetManufacturingMinutesAsync(cancellationToken)
//                    .ConfigureAwait(false);

//                return minutes;
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar de minutos asignados por ordenes.");
//                throw;
//            }
//        }

//        public async Task<bool> MachineCanPrintAsync(string machine, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando si la maquina puede imprimir");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return await insulations.MachineCanPrintAsync(machine, cancellationToken).ConfigureAwait(false);

//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar si la maquina puede imprimir.");
//                throw;
//            }
//        }

//        public async Task<MachineWorkloadFlagConfigurationModel> GetMachineWorkloadSemaphoreAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando de configuración de colores de carga de trabajo de las maquinas.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                Insulations.Models.MachineWorkloadFlagConfigurationModel? config = await insulations.GetMachineWorkloadSemaphoreAsync(cancellationToken)
//                    .ConfigureAwait(false);

//                MachineWorkloadFlagConfigurationModel configurations = new(config.NormalColor
//                    , config.WarningColor,
//                    config.CriticalColor,
//                    config.LockedColor,
//                    config.HighLevel,
//                    config.LowLevel);

//                return configurations;
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar la configuración de colores de carga de trabajo de las maquinas.");
//                throw;
//            }
//        }

//        #endregion

//        #region Queries

//        public async Task<IEnumerable<InsulationMachineModel>> GetInsulationMachinesAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando maquinas de aislamiento.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return (await insulations.GetMachinesAsync(cancellationToken)
//                    .ConfigureAwait(false))
//                    .Select(e => new InsulationMachineModel(e.Number, e.Available))
//                    .ToArray();
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar maquinas de aislamiento.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<OrderToManufacturingModel>> GetOrdersScheduledToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando planes de fabricación en la maquina {machine} y fecha {utcDate}.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();
//                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

//                IEnumerable<Insulations.Models.ManufacturingPlanItemModel> scheduledOrders = await insulations
//                    .GetManufacturingPlanByMachineAsync(utcDate, machine, cancellationToken)
//                    .ConfigureAwait(false);

//                List<OrderToManufacturingModel> result = new List<OrderToManufacturingModel>();

//                OrderToManufacturingModel orderModel;

//                foreach (Insulations.Models.ManufacturingPlanItemModel scheduledOrder in scheduledOrders)
//                {
//                    orderModel = new OrderToManufacturingModel(scheduledOrder.ItemId,
//                        scheduledOrder.Batch,
//                        scheduledOrder.Serie,
//                        scheduledOrder.Sequence);

//                    ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? coreTestResult = await cores
//                        .GetResidentialCoreTestByOrder(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, scheduledOrder.Sequence);

//                    if (coreTestResult != null)
//                    {
//                        orderModel.CoreTestColor = coreTestResult.Color;
//                    }

//                    result.Add(orderModel);
//                }

//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar planes de fabricación en la maquina {machine} y fecha {utcDate}.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando las ordenes.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return (await insulations.GetManufacturingOrdersAsync(cancellationToken).ConfigureAwait(false))
//                    .Select(e => new InsulationManufactureModel(e.Id, e.ItemId, e.Batch, e.Quantity, e.Serie, e.Sequence, e.Machine, e.RequestUtcDate, e.Priority, e.Status, e.Dimensions))
//                    .ToArray();
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar las ordenes.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<InsulationManufactureModel>> GetInsulationManufacturingOrdersInProgressAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando ordenes en ejecucion..");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                return (await insulations.GetManufacturingOrdersInProgressAsync(cancellationToken).ConfigureAwait(false)).Select(e =>
//                     new InsulationManufactureModel(e.Id, e.ItemId, e.Batch, e.Quantity, e.Serie, e.Sequence, e.Machine, e.RequestUtcDate, e.Priority, e.Status, e.Dimensions))
//                      .ToArray();

//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar ordenes en ejecucion.");
//                throw;
//            }
//        }

//        public async Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de orden.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                Insulations.Models.ManufacturingItemModel? result = (await insulations.GetManufacturingOrderAsync(itemId, batch, serie, cancellationToken).ConfigureAwait(false));

//                if (result is null)
//                {
//                    return null;
//                }

//                return new InsulationManufactureModel(result.Id, result.ItemId, result.Batch, result.Quantity, result.Serie, result.Sequence,
//                    result.Machine, result.RequestUtcDate, result.Priority, result.Status, result.Dimensions);

//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar información de orden.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<MachineAssignedOrdersModel>> GetMachineAssignedOrdersAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando asignación por maquina.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                IEnumerable<InsulationMachineModel> machines = (await insulations.GetMachinesAsync(cancellationToken)
//                    .ConfigureAwait(false))
//                    .Select(e => new InsulationMachineModel(e.Number, e.Available))
//                    .ToArray();

//                IEnumerable<MachineAssignedOrdersModel> assignations = (await insulations.GetMachineAssignedOrdersAsync(cancellationToken)
//                    .ConfigureAwait(false))
//                    .Select(e => new MachineAssignedOrdersModel(e.Number, e.Summary, true))
//                    .ToArray();

//                List<MachineAssignedOrdersModel> result = machines.GroupJoin(
//                    assignations,
//                    outerKeySelector => outerKeySelector.Number,
//                    innerKeySelector => innerKeySelector.Number,
//                    (machine, collection) => new MachineAssignedOrdersModel(machine.Number,
//                            collection.Select(e => e.Summary).Sum(),
//                            machine.Available)).ToList();

//                logger.LogInformation($"Termina consulta asignación por maquina.");

//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar asignación por maquina.");
//                throw;
//            }
//        }

//        public async Task<IEnumerable<OrderToManufacturingModel>> GetOrdersToManufactureAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando planes de fabricación en la maquina {machine} y fecha {utcDate}.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();
//                ControlPisoMX.Cores.IMicroservice cores = serviceProvider.GetRequiredService<ControlPisoMX.Cores.IMicroservice>();

//                IEnumerable<Insulations.Models.ManufacturingPlanItemModel> scheduledOrders = await insulations
//                    .GetOrdersToManufactureAsync(utcDate, machine, cancellationToken)
//                    .ConfigureAwait(false);

//                List<OrderToManufacturingModel> result = new List<OrderToManufacturingModel>();

//                OrderToManufacturingModel orderModel;

//                foreach (Insulations.Models.ManufacturingPlanItemModel scheduledOrder in scheduledOrders)
//                {
//                    orderModel = new OrderToManufacturingModel(scheduledOrder.ItemId,
//                        scheduledOrder.Batch,
//                        scheduledOrder.Serie,
//                        scheduledOrder.Sequence);

//                    ControlPisoMX.Cores.Models.Residential.ResidentialCoreTestModel? coreTestResult = await cores
//                        .GetResidentialCoreTestByOrder(scheduledOrder.ItemId, scheduledOrder.Batch, scheduledOrder.Serie, scheduledOrder.Sequence);

//                    if (coreTestResult != null)
//                    {
//                        orderModel.CoreTestColor = coreTestResult.Color;
//                    }

//                    result.Add(orderModel);
//                }

//                return result;
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar planes de fabricación en la maquina {machine} y fecha {utcDate}.");
//                throw;
//            }
//        }


//        #endregion

//        #region Manufacturing

//        public async Task AddOrdersToManufacturingAsync(List<OrderToManufactureModel> orders)
//        {
//            try
//            {
//                List<Insulations.Models.OrderToManufactureModel> insulationOrders = new();
//                ControlPisoMX.ERP.IMicroservice erp = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();

//                foreach (OrderToManufactureModel order in orders)
//                {
//                    logger.LogInformation($"Agregando plan de fabricación con articulo: {order.ItemId}, lote: {order.Batch}, serie:{order.Serie}, secuncia:{order.Sequence}.");
//                    string? dimentions = await erp.GetItemDimentionsAsync(order.ItemId, CancellationToken.None).ConfigureAwait(false);
//                    insulationOrders.Add(new Insulations.Models.OrderToManufactureModel(order.ItemId, order.Batch, order.Serie, order.Sequence, dimentions));
//                }

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                await insulations.AddOrdersToManufacturingAsync(insulationOrders).ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(ex, $"Ocurrió un error al agregar ordenes a la lista de fabricación.");
//                throw;
//            }
//        }

//        public async Task AddRepairOrderAsync(string itemId, string batch, int quantity, int priority, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Consultando información de validaciones para agregar orden a reparar.");

//                ControlPisoMX.ERP.IMicroservice erpMicroservice = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();
//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();

//                bool orderExistsInCatalog = await erpMicroservice.GetManufacturingPlanValidationAsync(itemId, batch, cancellationToken);
//                if (!orderExistsInCatalog)
//                {
//                    throw new UserException("La orden no está registrada en el catálogo de ordenes de fabricación. Revise el código de la orden y el consecutivo");
//                }

//                bool orderExistsInManufacturingPlan = await erpMicroservice.GetManufacturingProgramValidationAsync(itemId, batch, cancellationToken);
//                if (!orderExistsInManufacturingPlan)
//                {
//                    throw new UserException("La orden no está registrada en el programa de fabricación. Revise el código de la orden y el consecutivo.");
//                }

//                await insulations.AddRepairOrderAsync(itemId, batch, quantity, priority, cancellationToken);

//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al consultar la información de validaciones para agregar orden a reparar.");
//                throw;
//            }
//        }

//        public async Task StartOrderManufacturingAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Iniciando orden pendiente por ejecutar.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();
//                ControlPisoMX.ERP.IMicroservice erp = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();


//                await insulations.StartOrderManufacturingAsync(CancellationToken.None)
//                .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex, "Ocurrió un error al iniciar la orden.");
//                throw;
//            }
//        }

//        public async Task UpdateOrderManufacturingPriorityAsync(Guid id, int priority, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Actualizando prioridad de orden: {id}.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();



//                await insulations.UpdateOrderManufacturingPriorityAsync(id, priority, cancellationToken)
//                .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex,
//                    $"Ocurrió un error al tratar  de actualizar la prioridad de la orden: {id}");
//                throw;
//            }
//        }

//        public async Task FinishOrderManufacturingAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation($"Terminando orden pendiente por ejecutar.");

//                Insulations.IMicroservice insulations = serviceProvider.GetRequiredService<Insulations.IMicroservice>();
//                ControlPisoMX.ERP.IMicroservice erp = serviceProvider.GetRequiredService<ControlPisoMX.ERP.IMicroservice>();


//                await insulations.FinishOrderManufacturingAsync(CancellationToken.None)
//                .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                logger.LogError(
//                    ex, "Ocurrió un error al terminar la orden.");
//                throw;
//            }
//        }

//        #endregion

//        #endregion

//        #region Manufacturing summary

//        public async Task<IEnumerable<ManufacturingSummaryModel>> GetManufacturingSummaryAsync(DateTime utcDate, string machine, CancellationToken cancellationToken)
//        {
//            try
//            {
//                logger.LogInformation("Consultando el estatus de fabricación de las ordenes planeadas en la fecha {utcDate} para la maquina {machine}.", utcDate.ToString("s"), machine);

//                return await mediator
//                    .Send(new ManufacturingSummaryQuery(utcDate, machine), cancellationToken)
//                    .ConfigureAwait(false);
//            }
//            catch (Exception ex)
//            {
//                if (ex is not UserException)
//                {
//                    logger.LogError(ex, "Ocurrió un error al consultar el estatus de fabricación de las ordenes planeadas en la fecha {utcDate} para la maquina {machine}.", utcDate.ToString("s"), machine);
//                }
//                throw;
//            }
//        }

//        #endregion
//    }
//}