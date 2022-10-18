namespace ProlecGE.ControlPisoMX.Cores.Testing.Residential.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;

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

        private readonly IResidentialCoresService service;

        #endregion

        #region Constructor

        public RegisterDefectCommandHandler(
            IResidentialCoresService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        public async Task<ResidentialCoreTestResultModel> Handle(
            RegisterDefectCommand request,
            CancellationToken cancellationToken)
        {
            return await service.RegisterDefectAsync(
                request.TestCode,
                request.Defect,
                cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion
    }
}