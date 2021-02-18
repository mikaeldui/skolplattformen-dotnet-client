using ActiveLogin.Identity.Swedish;
using Skolplattformen.Converters;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    public class SkolplattformenUser
    {
        [JsonPropertyName("socialSecurityNumber"), JsonConverter(typeof(SwedishPersonalIdentityNumberConverter))]
        public SwedishPersonalIdentityNumber PersonalNumber { get; set; }
        public bool? IsAuthenticated { get; set; }
        [JsonPropertyName("userFirstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("userLastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("userEmail")]
        public string? Email { get; set; }
        public string? NotificationId { get; set; }
    }
}
