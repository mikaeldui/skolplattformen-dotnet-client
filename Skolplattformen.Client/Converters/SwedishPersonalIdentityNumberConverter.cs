using ActiveLogin.Identity.Swedish;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skolplattformen.Converters
{
    [DebuggerStepThrough]
    internal class SwedishPersonalIdentityNumberConverter : JsonConverter<SwedishPersonalIdentityNumber>
    {
        public override SwedishPersonalIdentityNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => SwedishPersonalIdentityNumber.Parse(reader.GetString());

        public override void Write(Utf8JsonWriter writer, SwedishPersonalIdentityNumber value, JsonSerializerOptions options) => writer.WriteStringValue(value.To10DigitString());
    }

    [DebuggerStepThrough]
    internal class JsonSwedishPersonalIdentityNumberAttribute : JsonConverterAttribute
    {
        public JsonSwedishPersonalIdentityNumberAttribute() : base(typeof(SwedishPersonalIdentityNumberConverter))
        {
        }
    }
}
