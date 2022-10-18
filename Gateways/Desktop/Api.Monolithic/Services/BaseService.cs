namespace Cores.Services
{
    using Microsoft.EntityFrameworkCore;

    public class BaseService
    {
        #region Properties

        protected DbContext Context { get; set; }

        #endregion

        #region Constructor

        public BaseService(DbContext context)
        {
            Context = context;
        }

        #endregion
    }
}