namespace ProlecGE.ControlPisoMX.Http
{
    using System.Text.Json;

    public static class CSharpJsonSerializerOptions
    {
        public static JsonSerializerOptions ConfigureControlPisoOptions(this JsonSerializerOptions jsonSerializerOptions)
        {
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            jsonSerializerOptions.Converters.Add(new DateTimeOffsetConverter());
            jsonSerializerOptions.Converters.Add(new Exceptions.ProblemDetailsJsonConverter());
            return jsonSerializerOptions;
        }
    }
}