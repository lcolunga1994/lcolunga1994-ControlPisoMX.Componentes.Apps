namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class RegisterLastTimeCoreTestCommand : IRequest { }

    public class RegisterLastTimeCoreTestCommandHandler : IRequestHandler<RegisterLastTimeCoreTestCommand, Unit>
    {
        #region Fields

        private readonly IRegisterLastTimeCoreTestWriter _registerLastTimeCoreTestReader;

        #endregion

        #region Constructor

        public RegisterLastTimeCoreTestCommandHandler(IRegisterLastTimeCoreTestWriter registerLastTimeCoreTestReader)
        {
            _registerLastTimeCoreTestReader = registerLastTimeCoreTestReader;
        }

        #endregion

        #region Methods

        public async Task<Unit> Handle(RegisterLastTimeCoreTestCommand request, CancellationToken cancellationToken)
        {
            await _registerLastTimeCoreTestReader
                .WriteAsync(cancellationToken)
                .ConfigureAwait(false);

            return Unit.Value;
        }

        #endregion
    }
}
