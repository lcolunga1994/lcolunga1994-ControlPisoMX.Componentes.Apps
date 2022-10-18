namespace ProlecGE.ControlPisoMX.Insulations.Forms.ClientApp.Queries
{
    using System.Threading.Tasks;

    public class MachineCanPrintQuery : MediatR.IRequest<bool>
    {
        #region Fields
        public string Machine { get; set; }

        #endregion

        #region Constructor

        public MachineCanPrintQuery(string machine)
        {
            Machine = machine;
        }

        #endregion
    }

    public class MachineCanPrintQueryHandler : MediatR.IRequestHandler<MachineCanPrintQuery, bool>
    {
        #region Fields

        private readonly BFWeb.Components.IInsulationsService service;


        #endregion

        #region Constructor
        public MachineCanPrintQueryHandler(BFWeb.Components.IInsulationsService service)
        {
            this.service = service;

        }

        #endregion

        #region Handler

        public async Task<bool> Handle(MachineCanPrintQuery request, CancellationToken cancellationToken)
        {
            return await service.MachineCanPrintAsync(request.Machine, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}