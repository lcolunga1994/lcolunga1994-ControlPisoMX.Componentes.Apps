namespace ProlecGE.ControlPisoMX.Cores.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.Extensions.Configuration;

    public class StationIdentifierQuery
        : IRequest<string>
    { }

    public class StationIdentifierQueryHandler
        : IRequestHandler<StationIdentifierQuery, string>
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public StationIdentifierQueryHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<string> Handle(StationIdentifierQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.Run(() =>
                {
                    string stationId = _configuration.GetValue<string>("TestDesktopName");

                    return string.IsNullOrWhiteSpace(stationId)
                        ? throw new UserException("El identificador de la mesa de prueba no está definido.", "UserError")
                        : stationId;
                });
            }
            catch (Exception ex)
            {
                throw UserException
                    .WithInnerException("Ocurrió un error al consultar el identificador de la estación de trabajo.", ex);
            }
        }

        #endregion
    }
}