using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    [JsonConverter(typeof(SkolplattformenNotificationConverter))]
    public class SkolplattformenNotification
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public DateTime DateCreated { get; set; }
        public string Message { get; set; }
        public Uri Url { get; set; }
        public string? Category { get; set; }
        public string Type { get; set; }

        private class SkolplattformenNotificationConverter : JsonConverter<SkolplattformenNotification>
        {
            public override SkolplattformenNotification Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (!JsonDocument.TryParseValue(ref reader, out JsonDocument document) ||
                    !document.RootElement.TryGetProperty("notification", out JsonElement notification) ||
                    !document.RootElement.TryGetProperty("notificationMessagee", out JsonElement notificationMessage) ||
                    !notificationMessage.TryGetProperty("messages", out JsonElement messages) ||
                    !messages.TryGetProperty("message", out JsonElement message) ||
                    !message.TryGetProperty("messageTypes", out JsonElement messageTypes) ||
                    !message.TryGetProperty("sender", out JsonElement sender))
                    return null;

                return new SkolplattformenNotification()
                {
                    Id = notification.GetString(),
                    DateCreated = notification.GetDateTime(),
                    Message = message.GetProperty("messagetext").GetString(),
                    Category = message.GetProperty("category").GetString(),
                    Url = new Uri(message.GetProperty("linkbackurl").GetString()),
                    Type = messageTypes.GetProperty("type").GetString(),
                    Sender = sender.GetProperty("name").GetString()
                };
            }

            public override void Write(Utf8JsonWriter writer, SkolplattformenNotification value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
