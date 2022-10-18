namespace ProlecGE.ControlPisoMX.Security.Forms.QueryHandlers
{
    using MediatR;

    using ProlecGE.ControlPisoMX.Identity.Models;
    using ProlecGE.ControlPisoMX.Security.Forms.Queries;

    using System.Threading.Tasks;

    public class UserDummyQueryHandler : IRequestHandler<UserQuery, User?>
    {
        #region Methods

        public async Task<User?> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new User()
            {
                Name = "Demostración",
                UserName = request.UserName
            });
        }

        #endregion
    }
}