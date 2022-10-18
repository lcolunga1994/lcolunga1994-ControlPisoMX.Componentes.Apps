namespace ProlecGE.ControlPisoMX.Http
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The DateTimeOffset Converter.
    /// </summary>
    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        /// <summary>
        /// Converts the JSON object into a DateTime object
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
        /// <param name="typeToConvert">The object type.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use on deserialization.</param>
        /// <returns></returns>
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return DateTimeOffset.Parse(reader.GetString());
#pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception dateTimeOffsetParseException)
            {
                throw new Exceptions.ServiceException(
                    new Exceptions.Error
                    {
                        Code = Exceptions.ErrorConstants.Codes.GeneralException,
                        Message = Exceptions.ErrorConstants.Messages.UnableToDeserializeDateTimeOffset,
                    },
                    dateTimeOffsetParseException);
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
        /// <param name="dateTimeOffsetValue">The dateTime value.</param>
        /// <param name="options">The calling serializer options</param>
        public override void Write(Utf8JsonWriter writer, DateTimeOffset dateTimeOffsetValue, JsonSerializerOptions options) =>
            // use the serializer's native implementation with ISO 8601-1:2019 format support(and also faster)
            JsonSerializer.Serialize(writer, dateTimeOffsetValue, typeof(DateTimeOffset));
    }
}