namespace ProlecGE.ControlPisoMX.Security.Forms.QueryHandlers
{

    using ProlecGE.ControlPisoMX.Security.Forms.Queries;

    using System.Threading.Tasks;

    public class ValidateUserPasswordDummyQueryHandler : MediatR.IRequestHandler<ValidateUserPasswordQuery, bool>
    {
        #region Methods

        public Task<bool> Handle(ValidateUserPasswordQuery request, CancellationToken cancellationToken)
        {
            return request.UserName == "J181" && request.Password == "NANO" ? Task.FromResult(true) : Task.FromResult(false);
        }

        #endregion
    }
}