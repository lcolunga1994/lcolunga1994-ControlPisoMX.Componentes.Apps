namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class TestCodeLengthValidatorCommand : IRequest<bool>
    {
        #region Constructor
        public TestCodeLengthValidatorCommand(string? testCode)
        {
            TestCode = testCode;
        }
        #endregion

        #region Properties

        public string? TestCode { get; set; }

        #endregion
    }

    public class TestCodeLengthValidatorCommandHandler : IRequestHandler<TestCodeLengthValidatorCommand, bool>
    {
        #region Fields

        private readonly ITestCodeLengthValidator _testCodeLengthValidator;

        #endregion

        #region Constructor

        public TestCodeLengthValidatorCommandHandler(ITestCodeLengthValidator testCodeLengthValidator)
        {
            _testCodeLengthValidator = testCodeLengthValidator;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(TestCodeLengthValidatorCommand request, CancellationToken cancellationToken)
        {
            return request.TestCode != null && await _testCodeLengthValidator
                .ReadAsync(request.TestCode, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}