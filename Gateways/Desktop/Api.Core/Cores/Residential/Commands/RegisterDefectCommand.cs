namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Residential.Models;

    public class RegisterDefectCommand : IRequest<ResidentialCoreTestResultModel>
    {
        #region Constructor

        public RegisterDefectCommand(
            string testCode,
            string defect)
        {
            if (string.IsNullOrWhiteSpace(testCode))
            {
                throw new UserException("El identificador de la prueba no puede ser vacío o espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(defect))
            {
                throw new UserException("El defecto no puede ser vacío o espacios en blanco.");
            }

            TestCode = testCode.Trim();
            Defect = defect.Trim();
        }

        #endregion

        #region Properties

        public string TestCode { get; }

        public string Defect { get; }

        #endregion
    }

    public class RegisterDefectCommandHandler : IRequestHandler<RegisterDefectCommand, ResidentialCoreTestResultModel>
    {
        #region Fields

        private readonly ControlPisoMX.Cores.IMicroservice cores;
        private readonly AutoMapper.IMapper mapper;

        #endregion

        #region Constructor

        public RegisterDefectCommandHandler(
            AutoMapper.IMapper mapper,
            ControlPisoMX.Cores.IMicroservice cores)
        {
            this.cores = cores;
            this.mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(
            RegisterDefectCommand request,
            CancellationToken cancellationToken)
        {
            return mapper.Map<ResidentialCoreTestResultModel>(await cores
                .RegisterDefectAsync(
                    request.TestCode,
                    request.Defect,
                    cancellationToken)
                .ConfigureAwait(false));
        }

        #endregion
    }
}