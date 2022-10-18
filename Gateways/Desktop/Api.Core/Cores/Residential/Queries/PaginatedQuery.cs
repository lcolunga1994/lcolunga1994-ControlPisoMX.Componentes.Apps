namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Queries
{
    public class PaginatedQuery
    {
        #region Constructor

        public PaginatedQuery(int page = 1, int pageSize = 100)
        {
            Page = page;
            PageSize = pageSize;
        }

        #endregion

        #region Properties

        public int Page { get; set; }

        public int PageSize { get; set; }

        #endregion
    }
}