namespace ProlecGE.ControlPisoMX.Http
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides method(s) to deserialize raw HTTP responses into strong types.
    /// </summary>
    public class ResponseHandler : IResponseHandler
    {
        #region Fields

        private readonly ISerializer serializer;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs a new <see cref="ResponseHandler"/>.
        /// </summary>
        /// <param name="serializer"></param>
        public ResponseHandler(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Process raw HTTP response into requested domain type.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="response">The HttpResponseMessage to handle</param>
        /// <returns></returns>
        public async Task<T?> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.Content != null)
                {
                    using System.IO.Stream responseStream = await response.Content
                        .ReadAsStreamAsync();

                    return serializer.DeserializeObject<T>(responseStream);
                }
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return default;
                }
                else
                {
                    await EnsureSuccessStatusCodeAsync(response);
                }
            }

            return default;
        }

        /// <summary>
        /// Process raw HTTP response into requested domain type.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="response">The HttpResponseMessage to handle</param>
        /// <returns></returns>
        public async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response)
        {
            if (response.Content?.Headers.ContentType != null &&
                        response.Content.Headers.ContentType.MediaType == "application/problem+json")
            {
                using System.IO.Stream responseStream = await response.Content
                        .ReadAsStreamAsync();

                Exceptions.ProblemDetails? problem = null;

                try
                {
                    problem = serializer.DeserializeObject<Exceptions.ProblemDetails>(responseStream);
                }
                catch
                {
                }

                if (problem != null)
                {
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string? errorCode = null;
                        if (problem.Extensions.ContainsKey("errorCode"))
                        {
                            errorCode = problem.Extensions["errorCode"]?.ToString();
                        }

                        if (!string.IsNullOrEmpty(errorCode))
                        {
                            throw new UserException(problem.Title, errorCode);
                        }

                        throw new UserException(problem.Title);
                    }
                }
            }
            response.EnsureSuccessStatusCode();

            await Task.CompletedTask;
        }

        #endregion
    }
}