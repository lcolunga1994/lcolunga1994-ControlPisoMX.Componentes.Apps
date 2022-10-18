namespace ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using ProlecGE.ControlPisoMX.BFWeb.Components.InspectionCMS.Models;

    internal class InsulationQuery : IRequest<IEnumerable<InsulationModel>>
    {
        #region Constructor

        public InsulationQuery(string itemId)
        {
            ItemId = itemId;
        }

        #endregion

        #region Properties

        public string ItemId { get; }

        #endregion
    }

    internal class InsulationQueryHandler : IRequestHandler<InsulationQuery, IEnumerable<InsulationModel>>
    {
        #region Fields

        private readonly ControlPisoMX.ERP.IMicroservice erp;

        #endregion

        #region Constructor

        public InsulationQueryHandler(ControlPisoMX.ERP.IMicroservice erp)
        {
            this.erp = erp;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<InsulationModel>> Handle(InsulationQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ERP.Models.AluminiumCutModel>? itemAluminium = await erp.GetItemAluminiumCutsAsync(request.ItemId, cancellationToken)
                .ConfigureAwait(false);

            List<InsulationModel> insulations = new();

            foreach (ERP.Models.AluminiumCutModel aluminium in itemAluminium)
            {
                if (aluminium.Description.StartsWith("PUNTAS AL N"))
                {
                    insulations.Add(new InsulationModel()
                    {
                        Description = "N",
                        Decimal1 = aluminium.L ?? 0d,
                        String1 = aluminium.String1 ?? ""
                    });
                }
                else if (aluminium.Description.StartsWith("PUNTAS AL, TERM"))
                {
                    insulations.Add(new InsulationModel()
                    {
                        Description = "CANTIDAD",
                        Decimal1 = aluminium.Quantity,
                        String1 = aluminium.String1 ?? ""
                    });

                    insulations.Add(new InsulationModel()
                    {
                        Description = "A",
                        Decimal1 = aluminium.A ?? 0d,
                        String1 = ""
                    });

                    insulations.Add(new InsulationModel()
                    {
                        Description = "B",
                        Decimal1 = aluminium.B ?? 0d,
                        String1 = ""
                    });


                    insulations.Add(new InsulationModel()
                    {
                        Description = "T",
                        Decimal1 = aluminium.T ?? 0d,
                        String1 = ""
                    });
                }
            }

            return insulations;
        }
        #endregion
    }
}
