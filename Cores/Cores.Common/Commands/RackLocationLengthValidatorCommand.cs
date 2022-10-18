namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class RackLocationLengthValidatorCommand : IRequest<bool>
    {
        #region Constructor
        public RackLocationLengthValidatorCommand(string? rackLocation)
        {
            RackLocation = rackLocation;
        }
        #endregion

        #region Properties

        public string? RackLocation { get; set; }

        #endregion
    }

    public class RackLocationLengthValidatorCommandHandler : IRequestHandler<RackLocationLengthValidatorCommand, bool>
    {
        #region Fields

        private readonly IRackLocationLengthValidator _rackLocationLengthValidator;

        #endregion

        #region Constructor

        public RackLocationLengthValidatorCommandHandler(IRackLocationLengthValidator rackLocationLengthValidator)
        {
            _rackLocationLengthValidator = rackLocationLengthValidator;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(RackLocationLengthValidatorCommand request, CancellationToken cancellationToken)
        {
            return request.RackLocation != null && await _rackLocationLengthValidator
                .ReadAsync(request.RackLocation, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}