namespace ProlecGE.ControlPisoMX.Security.Forms.CommandHandlers
{

    using ProlecGE.ControlPisoMX.Security.Forms.Command;

    using System.Threading.Tasks;

    public class ChangePasswordDummyCommandHandler : MediatR.IRequestHandler<ChangePasswordCommand, bool>
    {
        #region Methods

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1500, cancellationToken).ConfigureAwait(false);
            
            return true;
        }

        #endregion
    }
}
