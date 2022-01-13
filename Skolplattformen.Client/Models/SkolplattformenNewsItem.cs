using System;
using System.Text.Json.Serialization;

namespace Skolplattformen
{
    /// <summary>
    /// A news item from the school, for example a weekly news letter
    /// </summary>
    public class SkolplattformenNewsItem
    {
        const string IMAGE_HOST = "https://etjanst.stockholm.se/Vardnadshavare/inloggad2/NewsBanner?url=";

        [JsonPropertyName("newsId")] public string Id { get; set; }

        [JsonPropertyName("authorDisplayName")] public string? Author { get; set; }

        public string? Header { get; set; }

        [JsonPropertyName("preamble")] public string? Intro { get; set; }

        public string? Body { get; set; }

        public DateTime? Published { get; set; }

        public DateTime? Modified { get; set; }

        [JsonPropertyName("bannerImageUrl")] public Uri? ImageUrl { get; set; }

        public Uri? FullImageUrl => new(IMAGE_HOST + ImageUrl);

        [JsonPropertyName("altText")] public string? ImageAltText { get; set; }

        internal class Container
        {
            public SkolplattformenCollection<SkolplattformenNewsItem> NewsItems { get; set; }

            public SkolplattformenNewsItem CurrentNewsItem { get; set; }
        }
    }
}
