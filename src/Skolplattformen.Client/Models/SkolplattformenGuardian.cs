using System.Net.Mail;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    public class SkolplattformenGuardian
    {
        [JsonPropertyName("emailhome")]
        public MailAddress? Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonPropertyName("telmobile")]
        public string? Mobile { get; set; }
        public string? Address { get; set; }
    }
}
