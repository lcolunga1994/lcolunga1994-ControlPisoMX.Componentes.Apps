namespace ProlecGE.ControlPisoMX.Cores.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Services;

    public class ReadCalibrationStatusCommand : IRequest<bool> { }

    public class ReadCalibrationStatusCommandHandler : IRequestHandler<ReadCalibrationStatusCommand, bool>
    {
        #region Fields

        private readonly ICalibrationStatusValidateReader _calibrationStatusValidateReader;

        #endregion

        #region Constructor

        public ReadCalibrationStatusCommandHandler(ICalibrationStatusValidateReader calibrationStatusValidateReader)
        {
            _calibrationStatusValidateReader = calibrationStatusValidateReader;
        }

        #endregion

        #region Methods

        public async Task<bool> Handle(ReadCalibrationStatusCommand request, CancellationToken cancellationToken)
        {
            return await _calibrationStatusValidateReader
                .ReadAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}
