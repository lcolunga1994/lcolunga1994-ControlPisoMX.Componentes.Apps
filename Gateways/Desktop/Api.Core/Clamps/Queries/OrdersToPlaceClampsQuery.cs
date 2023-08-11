namespace ProlecGE.ControlPisoMX.BFWeb.Components.Clamps.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Models;

    public class OrdersToPlaceClampsQuery : IRequest<IEnumerable<OrderWithClampsModel>> { }

    public class OrdersToPlaceClampsQueryHandler
        : IRequestHandler<OrdersToPlaceClampsQuery, IEnumerable<OrderWithClampsModel>>
    {
        #region Fields

        private readonly ILogger<OrdersToPlaceClampsQueryHandler> logger;
        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly ControlPisoMX.ERP.IMicroservice erp;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public OrdersToPlaceClampsQueryHandler(
            ILogger<OrdersToPlaceClampsQueryHandler> logger,
            ControlPisoMX.Cores.IMicroservice cores,
            ControlPisoMX.ERP.IMicroservice erp,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.cores = cores;
            this.erp = erp;
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<OrderWithClampsModel>> Handle(OrdersToPlaceClampsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Consultando las ordenes a las que no se les han colocado los herrajes.");

                var orders = await cores
                    .GetOrdersToPlaceClampsAsync(CancellationToken.None)
                    .ConfigureAwait(false);

                List<OrderWithClampsModel> result = new();

                foreach (var order in orders)
                {
                    ERP.Models.ItemModel? item = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ? 
                        await erp.GetItemAsync(order.ItemId, CancellationToken.None).ConfigureAwait(false)
                      : await erp.GetItemAsync_discpiso(order.ItemId, CancellationToken.None).ConfigureAwait(false);

                    if (item is not null)
                    {
                        IEnumerable<ControlPisoMX.ERP.Models.ItemClampModel> itemClamps = bool.Parse(_configuration.GetSection("UseBaan").Value.ToString()) ?
                            await erp.GetItemClampsAsync(order.ItemId, CancellationToken.None).ConfigureAwait(false):
                            await erp.GetItemClampsAsync_LN(order.ItemId,int.Parse(_configuration.GetSection("Cia").Value.ToString()), CancellationToken.None).ConfigureAwait(false);                        

                        result.Add(new OrderWithClampsModel()
                        {
                            ItemId = order.ItemId,
                            Batch = order.Batch,
                            Serie = order.Serie,
                            Machine = order.Machine,
                            ProductLine = (Models.ProductLine)order.ProductLine,
                            Sequence = order.Sequence,
                            Market = item.Ctyo ?? "",
                            Top = itemClamps
                                .Where(e => e.Place == "Top")
                                .Select(e => new ItemClampModel()
                                {
                                    DrawId = e.DrawId,
                                    A = e.A,
                                    B = e.B,
                                    C = e.C,
                                    X = e.X,
                                    D = e.D,
                                    E = e.E,
                                    F = e.F,
                                    J = e.J,
                                    L = e.L,
                                    T = e.T,
                                    G = e.G,
                                    H = e.H,
                                    K = e.K
                                })
                                .FirstOrDefault(),
                            Bottom = itemClamps
                                .Where(e => e.Place == "Bottom")
                                .Select(e => new ItemClampModel()
                                {
                                    DrawId = e.DrawId,
                                    A = e.A,
                                    B = e.B,
                                    C = e.C,
                                    X = e.X,
                                    D = e.D,
                                    E = e.E,
                                    F = e.F,
                                    J = e.J,
                                    L = e.L,
                                    T = e.T,
                                    G = e.G,
                                    H = e.H,
                                    K = e.K
                                })
                                .FirstOrDefault()
                        });
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar las ordenes a las que no se les han colocado los herrajes.");
                throw;
            }
        }

        #endregion
    }
}