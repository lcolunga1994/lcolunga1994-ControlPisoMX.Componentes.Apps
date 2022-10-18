namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api.Controllers
{
    using Application.Queries;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v1/residential")]
    public class ResidentialController : ControllerBase
    {
        #region Fields

        private readonly ILogger<ResidentialController> logger;
        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public ResidentialController(ILogger<ResidentialController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        #endregion

        #region Methods

        [Route("missingitemdesigncontact")]
        [HttpGet]
        public async Task<ActionResult<string>> MissingItemDesignContact()
        {
            try
            {
                logger.LogInformation($"Consultando el contacto por pérdida de información en el diseño del nucleo.");
                string contact = await mediator
                    .Send(new ResidentialMissingCoreDesignContactQuery(), CancellationToken.None)
                    .ConfigureAwait(false);

                return Ok(contact);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la información.");
                throw;
            }
        }

        [Route("missingcoremanufacturingplancontact")]
        [HttpGet]
        public async Task<ActionResult<string>> MissingCoreManufacturingPlanContact()
        {
            try
            {
                logger.LogInformation($"Consultando el contacto por pérdida de información en la orden.");
                string contact = await mediator
                    .Send(new ResidentialMissingCoreManufacturingPlanContactQuery(), CancellationToken.None)
                    .ConfigureAwait(false);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la información.");
                throw;
            }
        }

        [Route("internalerrorcontact")]
        [HttpGet]
        public async Task<ActionResult<string>> InternalErrorContact()
        {
            try
            {
                logger.LogInformation($"Consultando el contacto por falla interna en el sistema.");
                string contact = await mediator
                    .Send(new ResidentialInternalErrorContactQuery(), CancellationToken.None)
                    .ConfigureAwait(false);

                return Ok(contact);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error al consultar la información.");
                throw;
            }
        }
        #endregion
    }
}