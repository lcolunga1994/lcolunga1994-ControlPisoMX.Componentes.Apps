namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class ReadTestValuesCommand : IRequest<CoreTestsValues>
    {
        #region Constructor

        public ReadTestValuesCommand(double testVoltage)
        {
            TestVoltage = testVoltage;
        }

        #endregion

        #region Properties

        public double TestVoltage { get; set; }

        #endregion
    }

    public class ReadTestValuesCommandHandler : IRequestHandler<ReadTestValuesCommand, CoreTestsValues>
    {
        #region Fields

        private readonly ICoreTestValuesReader coreTestValuesReader;

        #endregion

        #region Constructor

        public ReadTestValuesCommandHandler(ICoreTestValuesReader coreTestValuesReader)
        {
            this.coreTestValuesReader = coreTestValuesReader;
        }

        #endregion

        #region Methods

        public async Task<CoreTestsValues> Handle(ReadTestValuesCommand request, CancellationToken cancellationToken)
        {
            return await coreTestValuesReader
                .ReadAsync(request.TestVoltage, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}