namespace ProlecGE.ControlPisoMX.Http.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The error object contained in 400 and 500 responses returned from the service.
    /// Models OData protocol, 9.4 Error Response Body
    /// http://docs.oasis-open.org/odata/odata/v4.01/csprd05/part1-protocol/odata-v4.01-csprd05-part1-protocol.html#_Toc14172757
    /// </summary>
    public class Error
    {
        /// <summary>
        /// This code represents the HTTP status code when this Error object accessed from the ServiceException.Error object.
        /// This code represent a sub-code when the Error object is in the InnerError or ErrorDetails object.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; } = null!;

        /// <summary>
        /// The error message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        /// <summary>
        /// Indicates the target of the error, for example, the name of the property in error.
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; } = null!;

        /// <summary>
        /// An array of details that describe the error[s] encountered with the request.
        /// </summary>
        [JsonPropertyName("details")]
        public IEnumerable<ErrorDetail> Details { get; set; } = null!;

        /// <summary>
        /// The inner error of the response. These are additional error objects that may be more specific than the top level error.
        /// </summary>
        [JsonPropertyName("innererror")]
        public Error InnerError { get; set; } = null!;

        /// <summary>
        /// The Throw site of the error.
        /// </summary>
        public string ThrowSite { get; internal set; } = null!;

        /// <summary>
        /// Gets or set the client-request-id header returned in the response headers collection. 
        /// </summary>
        public string ClientRequestId { get; internal set; } = null!;

        /// <summary>
        /// The AdditionalData property bag.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; } = null!;

        /// <summary>
        /// Concatenates the error into a string.
        /// </summary>
        /// <returns>A human-readable string error response.</returns>
        public override string ToString()
        {
            StringBuilder errorStringBuilder = new();

            if (!string.IsNullOrEmpty(Code))
            {
                errorStringBuilder.AppendFormat("Code: {0}", Code);
                errorStringBuilder.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(Message))
            {
                errorStringBuilder.AppendFormat("Message: {0}", Message);
                errorStringBuilder.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(Target))
            {
                errorStringBuilder.AppendFormat("Target: {0}", Target);
                errorStringBuilder.Append(Environment.NewLine);
            }

            if (Details != null && Details.GetEnumerator().MoveNext())
            {
                errorStringBuilder.Append("Details:");
                errorStringBuilder.Append(Environment.NewLine);

                int i = 0;
                foreach (ErrorDetail detail in Details)
                {
                    errorStringBuilder.AppendFormat("\tDetail{0}:{1}", i, detail.ToString());
                    errorStringBuilder.Append(Environment.NewLine);
                    i++;
                }
            }

            if (InnerError != null)
            {
                errorStringBuilder.Append("Inner error:");
                errorStringBuilder.Append(Environment.NewLine);
                errorStringBuilder.Append("\t" + InnerError.ToString());
            }

            if (!string.IsNullOrEmpty(ThrowSite))
            {
                errorStringBuilder.AppendFormat("Throw site: {0}", ThrowSite);
                errorStringBuilder.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(ClientRequestId))
            {
                errorStringBuilder.AppendFormat("ClientRequestId: {0}", ClientRequestId);
                errorStringBuilder.Append(Environment.NewLine);
            }

            if (AdditionalData != null && AdditionalData.GetEnumerator().MoveNext())
            {
                errorStringBuilder.Append("AdditionalData:");
                errorStringBuilder.Append(Environment.NewLine);
                foreach (KeyValuePair<string, object> prop in AdditionalData)
                {
                    errorStringBuilder.AppendFormat("\t{0}: {1}", prop.Key, prop.Value?.ToString() ?? "null");
                    errorStringBuilder.Append(Environment.NewLine);
                }
            }

            return errorStringBuilder.ToString();
        }
    }

    /// <summary>
    /// The error details object.
    /// Models OData protocol, 9.4 Error Response Body details object.
    /// http://docs.oasis-open.org/odata/odata/v4.01/csprd05/part1-protocol/odata-v4.01-csprd05-part1-protocol.html#_Toc14172757
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// This code serves as a sub-status for the error code specified in the Error object.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; } = null!;

        /// <summary>
        /// The error message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        /// <summary>
        /// Indicates the target of the error, for example, the name of the property in error.
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; } = null!;

        /// <summary>
        /// The AdditionalData property bag.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; } = null!;

        /// <summary>
        /// Concatenates the error detail into a string.
        /// </summary>
        /// <returns>A string representation of an ErrorDetail object.</returns>
        public override string ToString()
        {
            StringBuilder errorDetailsStringBuilder = new();

            if (!string.IsNullOrEmpty(Code))
            {
                errorDetailsStringBuilder.Append(Environment.NewLine);
                errorDetailsStringBuilder.AppendFormat("\t\tCode: {0}", Code);
                errorDetailsStringBuilder.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(Message))
            {
                errorDetailsStringBuilder.AppendFormat("\t\tMessage: {0}", Message);
                errorDetailsStringBuilder.Append(Environment.NewLine);
            }

            if (!string.IsNullOrEmpty(Target))
            {
                errorDetailsStringBuilder.AppendFormat("\t\tTarget: {0}", Target);
                errorDetailsStringBuilder.Append(Environment.NewLine);
            }

            if (AdditionalData != null && AdditionalData.GetEnumerator().MoveNext())
            {
                errorDetailsStringBuilder.Append("\t\tAdditionalData:");
                errorDetailsStringBuilder.Append(Environment.NewLine);
                foreach (KeyValuePair<string, object> prop in AdditionalData)
                {
                    errorDetailsStringBuilder.AppendFormat("\t{0} : {1}", prop.Key, prop.Value.ToString());
                    errorDetailsStringBuilder.Append(Environment.NewLine);
                }
            }

            return errorDetailsStringBuilder.ToString();
        }
    }
}