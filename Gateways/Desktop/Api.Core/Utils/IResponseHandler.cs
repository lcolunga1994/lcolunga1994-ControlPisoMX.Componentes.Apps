namespace ProlecGE.ControlPisoMX.Http
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface required for all response handlers.
    /// </summary>
    public interface IResponseHandler
    {
        #region Methods

        /// <summary>
        /// Process raw HTTP response into the requested domain type.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="response">The HttpResponseMessage to handle.</param>
        /// <returns></returns>
        Task<T?> HandleResponseAsync<T>(HttpResponseMessage response);

        Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response);

        #endregion
    }
}