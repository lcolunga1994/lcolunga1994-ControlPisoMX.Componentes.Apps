namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class TestCodeTextValidatorCommand : IRequest<bool>
    {
        #region Constructor

        public TestCodeTextValidatorCommand(string? testCode)
        {
            TestCode = testCode;
        }

        #endregion

        #region Properties

        public string? TestCode { get; set; }

        #endregion
    }

    public class TestCodeTextValidatorCommandHandler : IRequestHandler<TestCodeTextValidatorCommand, bool>
    {
        #region Fields

        private readonly ITestCodeTextValidator _testCodeTextValidator;

        #endregion

        #region Constructor

        public TestCodeTextValidatorCommandHandler(ITestCodeTextValidator testCodeTextValidator)
        {
            _testCodeTextValidator = testCodeTextValidator;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(TestCodeTextValidatorCommand request, CancellationToken cancellationToken)
        {
            return request.TestCode != null && await _testCodeTextValidator
                .ReadAsync(request.TestCode, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}