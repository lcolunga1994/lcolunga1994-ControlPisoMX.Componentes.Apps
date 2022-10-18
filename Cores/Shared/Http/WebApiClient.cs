namespace ProlecGE.ControlPisoMX.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Class to access to the WebAPI Controller
    /// </summary>
    public class WebApiClient
    {
        #region Fields

        private const string RequestJsonContentType = "application/json";
        private readonly IResponseHandler responseHandler;
        private WebAPIUser? user;

        /// <summary>
        /// Relative URI fragment of the login endpoint.
        /// </summary>
        protected const string LoginUriFragment = "/token";

        protected List<HttpMessageHandler>? httpHandlers;

        #endregion

        #region Constructor

        public WebApiClient(
            HttpClient httpClient,
            ISerializer? serializer = null)
        {
            ApiRouteName = "api";
            HttpClient = httpClient;

            if (HttpClient.BaseAddress == null)
            {
                throw new ArgumentException("The http client does not have a base address");
            }
            BaseUrl = HttpClient.BaseAddress.OriginalString;
            Serializer = serializer ?? new Serializer();
            HttpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue(RequestJsonContentType));
            responseHandler = new ResponseHandler(Serializer);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseUrl">server urlPrefix</param>
        /// <param name="securityToken">Authentication Token</param>
        public WebApiClient(string baseUrl, params HttpMessageHandler[] handlers)
        {
            if (string.IsNullOrEmpty(baseUrl) || !Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            if (!baseUrl.EndsWith("/"))
            {
                baseUrl = string.Concat(baseUrl, "/");
            }

            Serializer = new Serializer();
            responseHandler = new ResponseHandler(Serializer);

            BaseUrl = baseUrl;
            ApiRouteName = "api";

            httpHandlers = handlers.ToList();

            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(RequestJsonContentType));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Service base url
        /// </summary>
        protected string BaseUrl
        {
            get; private set;
        }

        /// <summary>
        /// The route separator used to denote the api in a uri like
        /// .../{app}/api/{serviceName}.
        /// </summary>
        public string ApiRouteName { get; set; }

        /// <summary>
        /// The current authenticated user provided after a successful call to
        /// <see cref="LogInAsync(string, string)"/>.
        /// </summary>
        public WebAPIUser? CurrentUser
        {
            get => user;
            protected set
            {
                if (user != value)
                {
                    user = value;
                    UpdateToken();
                }
            }
        }

        private HttpClient HttpClient { get; set; }

        /// <summary>
        /// Gets a serializer for serializing and deserializing JSON objects.
        /// </summary>
        public ISerializer Serializer { get; private set; }

        #endregion

        #region Methods

        public void SetUser(string userName, string token) => CurrentUser = new WebAPIUser(userName, token);

        /// <summary>
        /// Get application token
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<WebAPIUser?> LogInAsync(string username, string password)
        {
            Uri requestUri = new($"{BaseUrl}{LoginUriFragment}");
            string tokenRequest = $"grant_type=password&username={username}&password={password}";
            using (HttpResponseMessage response = await HttpClient
                .PostAsync(requestUri, CreateHttpContent(tokenRequest)))
            {
                await responseHandler
                    .EnsureSuccessStatusCodeAsync(response);

                string? contentResponse = null;

                if (response.Content != null)
                {
                    contentResponse = await response.Content.ReadAsStringAsync();
                }

                if (!string.IsNullOrEmpty(contentResponse))
                {
                    CurrentUser = SerializeUser(contentResponse);
                }
            }
            return CurrentUser;
        }

        public void LogOff() => CurrentUser = null;

        /// <summary>
        /// Do GetByVisitor
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T?> GetAsync<T>(
            string url,
            CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await HttpClient
                    .GetAsync(CreateUri(url), cancellationToken)
                    .ConfigureAwait(false);

                return await responseHandler
                    .HandleResponseAsync<T>(response)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException();
            }
        }

        public async Task<T?> GetAsync<T, U>(string url, U entity, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await HttpClient
                    .SendAsync(new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = CreateUri(url),
                        Content = CreateHttpContent(entity)
                    }, cancellationToken)
                    .ConfigureAwait(false);

                return await responseHandler
                    .HandleResponseAsync<T>(response)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException();
            }
        }


        /// <summary>
        /// Do post
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task PostAsync(string url)
        {
            using HttpResponseMessage response = await HttpClient
                .PostAsync(CreateUri(url), CreateHttpContent(null));

            await responseHandler
                .EnsureSuccessStatusCodeAsync(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Do post
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T?> PostAsync<T>(
            string url,
            CancellationToken cancellationToken)
        {
            using HttpResponseMessage response = await HttpClient
                .PostAsync(CreateUri(url), CreateHttpContent(null), cancellationToken)
                .ConfigureAwait(false);

            return await responseHandler
                .HandleResponseAsync<T>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Do post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task PostAsync<T>(string url, T entity, CancellationToken cancellationToken)
        {
            using HttpResponseMessage response = await HttpClient
                .PostAsync(CreateUri(url), CreateHttpContent(entity), cancellationToken);

            await responseHandler
                .HandleResponseAsync<T>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Do post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<R?> PostAsync<R, T>(string url, T entity, CancellationToken cancellationToken)
        {
            using HttpResponseMessage response = await HttpClient
                .PostAsync(CreateUri(url), CreateHttpContent(entity), cancellationToken);

            return await responseHandler
                 .HandleResponseAsync<R>(response)
                 .ConfigureAwait(false);
        }

        /// <summary>
        /// Do post
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T?> PostAsync<T>(T entity)
        {
            using HttpResponseMessage response = await HttpClient
                .PostAsync(CreateUri(""), CreateHttpContent(entity));

            return await responseHandler
                .HandleResponseAsync<T>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="url"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task PutAsync<T>(string url, T entity)
        {
            using HttpResponseMessage response = await HttpClient
                .PutAsync(CreateUri(url), CreateHttpContent(entity));

            await responseHandler
                .EnsureSuccessStatusCodeAsync(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string url)
        {
            using HttpResponseMessage response = await HttpClient
                .DeleteAsync(CreateUri(url));

            await responseHandler
                .EnsureSuccessStatusCodeAsync(response)
                .ConfigureAwait(false);
        }

        ///// <summary>
        ///// Refreshes access token with the identity provider for the logged in user.
        ///// </summary>
        ///// <returns>
        ///// Task that will complete when the user has finished refreshing access token
        ///// </returns>
        //public async Task<MobileServiceUser> RefreshUserAsync()
        //{
        //    if (this.CurrentUser == null || string.IsNullOrEmpty(this.CurrentUser.MobileServiceAuthenticationToken))
        //    {
        //        throw new InvalidOperationException("MobileServiceUser must be set before calling refresh");
        //    }
        //    string response = null;
        //    MobileServiceHttpClient client = this.HttpClient;
        //    if (this.AlternateLoginHost != null)
        //    {
        //        client = this.AlternateAuthHttpClient;
        //    }
        //    try
        //    {
        //        response = await client.RequestWithoutHandlersAsync(HttpMethod.Get, RefreshUserAsyncUriFragment, this.CurrentUser, null, MobileServiceFeatures.RefreshToken);
        //    }
        //    catch (MobileServiceInvalidOperationException ex)
        //    {
        //        string message = string.Empty;
        //        if (ex.Response != null)
        //        {
        //            switch (ex.Response.StatusCode)
        //            {
        //                case HttpStatusCode.BadRequest:
        //                    message = "Refresh failed with a 400 Bad Request error. The identity provider does not support refresh, or the user is not logged in with sufficient permission.";
        //                    break;
        //                case HttpStatusCode.Unauthorized:
        //                    message = "Refresh failed with a 401 Unauthorized error. Credentials are no longer valid.";
        //                    break;
        //                case HttpStatusCode.Forbidden:
        //                    message = "Refresh failed with a 403 Forbidden error. The refresh token was revoked or expired.";
        //                    break;
        //                default:
        //                    message = "Refresh failed due to an unexpected error.";
        //                    break;
        //            }
        //            throw new MobileServiceInvalidOperationException(message, innerException: ex, request: ex.Request, response: ex.Response);
        //        }
        //        throw;
        //    }

        //    if (!string.IsNullOrEmpty(response))
        //    {
        //        JToken authToken = JToken.Parse(response);

        //        this.CurrentUser.MobileServiceAuthenticationToken = (string)authToken["authenticationToken"];
        //    }

        //    return this.CurrentUser;
        //}

        #endregion

        #region Functionality

        protected virtual WebAPIUser? SerializeUser(string contentResponse)
            => JsonSerializer.Deserialize<WebAPIUser>(contentResponse);

        private void UpdateToken()
        {
            if (CurrentUser != null && !string.IsNullOrEmpty(CurrentUser.Token))
            {
                string token = CurrentUser.Token.StartsWith("Bearer ") ? CurrentUser.Token[7..] : CurrentUser.Token;
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                HttpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        private Uri CreateUri(string url) => HttpClient.BaseAddress == null
                ? throw new ArgumentException("The http client does not have a base address")
                : new Uri($"{HttpClient.BaseAddress.AbsoluteUri.TrimEnd('/')}/{ApiRouteName}/{url.TrimStart('/')}");


        /// <summary> 
        /// Creates an <see cref="HttpContent"/> instance from a string. 
        /// </summary> 
        /// <param name="content"> 
        /// The string content from which to create the <see cref="HttpContent"/> instance.  
        /// </param> 
        /// <returns> 
        /// An <see cref="HttpContent"/> instance or null if the <paramref name="content"/> 
        /// was null. 
        /// </returns> 
        private HttpContent CreateHttpContent(object? serializableObject)
        {
            HttpContent httpContent = new StringContent("");
            httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse(RequestJsonContentType);

            if (serializableObject != null)
            {
                if (serializableObject is Stream inputStream)
                {
                    return new StreamContent(inputStream);
                }
                else
                {
                    string? contentObject = Serializer.SerializeObject(serializableObject);

                    if (contentObject != null)
                    {
                        StringContent? content = new(contentObject);
                        content.Headers.ContentType = MediaTypeHeaderValue.Parse(RequestJsonContentType);
                        return content;
                    }
                }
            }

            return httpContent;
        }

        #endregion
    }

    /// <summary>
    /// An authenticated HtpClient user.
    /// </summary>
    public class WebAPIUser
    {
        #region Properties

        //[JsonProperty("access_token")]
        public string Token { get; set; }

        //[JsonProperty("token_type")]
        //public string TokenType { get; set; }

        //[JsonProperty("expires_in")]
        public int EspiresIn { get; set; }

        //[JsonProperty("refresh_token")]
        public string? RefreshToken { get; set; }

        //[JsonProperty("userName")]
        public string UserName { get; set; }

        //[JsonProperty(".issued")]
        public DateTime Issued { get; set; }

        //[JsonProperty(".expires")]
        public DateTime Expiration { get; set; }

        public bool IsValidToken => Expiration > DateTime.UtcNow;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the HttpClientUser class.
        /// </summary>
        /// <param name="userId">
        /// User id of a successfully authenticated user.
        /// </param>
        public WebAPIUser(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            UserName = userName;
            Token = token;
        }

        #endregion
    }
}