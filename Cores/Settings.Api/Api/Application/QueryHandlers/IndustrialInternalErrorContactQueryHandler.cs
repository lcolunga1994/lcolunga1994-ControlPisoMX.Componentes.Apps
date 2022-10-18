namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Application.QueryHandlers
{
    using Domain;
    using Domain.Entities;

    using MediatR;

    using Microsoft.EntityFrameworkCore;

    using Queries;

    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class IndustrialInternalErrorContactQueryHandler
        : IRequestHandler<IndustrialInternalErrorContactQuery, string>
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructor

        public IndustrialInternalErrorContactQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<string> Handle(IndustrialInternalErrorContactQuery request, CancellationToken cancellationToken)
        {
            string? setting = await unitOfWork.Settings
                .Where(e => e.Name == Setting.IndustrialInternalErrorContact)
                .Select(e => e.Value)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (setting is null)
            {
                setting = "Contactar a sistemas ext: 2125.";
                await unitOfWork.Settings.AddAsync(new Setting(Setting.IndustrialInternalErrorContact, setting), cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return setting ?? string.Empty;
        }

        #endregion
    }
}