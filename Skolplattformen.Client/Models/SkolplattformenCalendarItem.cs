using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    public class SkolplattformenCalendarItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        [JsonPropertyName("longEventDateTime")]
        public DateTime? StartDate { get; set; }
        [JsonPropertyName("longEndDateTime")]
        public DateTime? EndDate { get; set; }
        [JsonPropertyName("allDayEvent")]
        public bool? AllDay { get; set; }
    }
}
