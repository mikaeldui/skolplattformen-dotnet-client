using ActiveLogin.Identity.Swedish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skolplattformen.Converters
{
    internal class SwedishPersonalIdentityNumberConverter : JsonConverter<SwedishPersonalIdentityNumber>
    {
        public override SwedishPersonalIdentityNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();

            return SwedishPersonalIdentityNumber.Parse(s);
        }

        public override void Write(Utf8JsonWriter writer, SwedishPersonalIdentityNumber value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
