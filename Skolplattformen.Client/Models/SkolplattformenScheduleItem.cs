using System;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    public class SkolplattformenScheduleItem
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        [JsonPropertyName("longEventDateTime")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("longEndDateTime")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("isSameDate")]
        public bool OneDayEvent { get; set; }
        public bool AllDayEvent { get; set; }
    }
}
