namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores
{
    using System.Collections.Generic;
    using System.Linq;

    public class QueryResult<TResult>
    {
        #region Properties

        public IEnumerable<TResult> Data { get; set; }

        public int Count { get; set; }

        #endregion

        #region Constructor

        public QueryResult()
        {
            Data = Enumerable.Empty<TResult>();
        }

        public QueryResult(IEnumerable<TResult> data, int count)
        {
            Data = data;
            Count = count;
        }

        #endregion
    }
}