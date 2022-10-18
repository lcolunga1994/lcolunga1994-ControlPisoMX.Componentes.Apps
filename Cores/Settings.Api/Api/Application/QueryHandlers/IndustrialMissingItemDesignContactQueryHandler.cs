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

    public class IndustrialMissingItemDesignContactQueryHandler
        : IRequestHandler<IndustrialMissingCoreDesignContactQuery, string>
    {
        #region Fields

        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructor

        public IndustrialMissingItemDesignContactQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<string> Handle(IndustrialMissingCoreDesignContactQuery request, CancellationToken cancellationToken)
        {
            string? setting = await unitOfWork.Settings
                .Where(e => e.Name == Setting.IndustrialMissingItemDesignContact)
                .Select(e => e.Value)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (setting is null)
            {
                setting = "Contactar con el líder de ingeniería.";
                await unitOfWork.Settings.AddAsync(new Setting(Setting.IndustrialMissingItemDesignContact, setting), cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return setting ?? string.Empty;
        }

        #endregion
    }
}