namespace ProlecGE.ControlPisoMX.Http
{
    using System.IO;
    using System.Text.Json;

    /// <summary>
    /// An <see cref="ISerializer"/> implementation using the JSON.NET serializer.
    /// </summary>
    public class Serializer : ISerializer
    {
        #region Fields

        private readonly JsonSerializerOptions jsonSerializerOptions;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the serializer with defaults for the JsonSerializer settings.
        /// </summary>
        public Serializer()
            : this(
                  new JsonSerializerOptions
                  {
                      DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                      PropertyNameCaseInsensitive = true
                  })
        {
        }

        /// <summary>
        /// Constructor for the serializer.
        /// </summary>
        /// <param name="jsonSerializerSettings">The serializer settings to apply to the serializer.</param>
        public Serializer(JsonSerializerOptions jsonSerializerSettings)
        {
            jsonSerializerOptions = jsonSerializerSettings;
            jsonSerializerOptions.ConfigureControlPisoOptions();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deserializes the stream to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type.</typeparam>
        /// <param name="stream">The stream to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T? DeserializeObject<T>(Stream stream)
        {
            return stream == null || stream.Length == 0
                ? default
                : JsonSerializer.DeserializeAsync<T>(stream, jsonSerializerOptions)
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Deserializes the JSON string to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type.</typeparam>
        /// <param name="inputString">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T? DeserializeObject<T>(string inputString)
            => string.IsNullOrEmpty(inputString) ? default : JsonSerializer.Deserialize<T>(inputString, jsonSerializerOptions);

        /// <summary>
        /// Serializes the specified object into a JSON string.
        /// </summary>
        /// <param name="serializeableObject">The object to serialize.</param>
        /// <returns>The JSON string.</returns>
        public string? SerializeObject(object serializeableObject)
        {
            if (serializeableObject == null)
            {
                return null;
            }

            if (serializeableObject is Stream stream)
            {
                using StreamReader? streamReader = new(stream);
                return streamReader.ReadToEnd();
            }

            return serializeableObject is string stringValue ? stringValue : JsonSerializer.Serialize(serializeableObject, jsonSerializerOptions);
        }

        #endregion
    }
}