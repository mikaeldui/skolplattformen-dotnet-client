using ActiveLogin.Identity.Swedish;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Skolplattformen
{
    using Routes = SkolplattformenVardnadshavareRoutes;

    // From https://github.com/kolplattformen/embedded-api/blob/main/lib/api.ts
    public partial class SkolplattformenVardnadshavareClient : IDisposable
    {
        private const string USERAGENT = "Mozilla/5.0 (Macintosh; Intel Mac OS X 11_1_0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";

        private CookieContainer _cookieContainer;
        private HttpClientHandler _httpClientHandler;
        private HttpClient _httpClient;

        public SkolplattformenVardnadshavareClient()
        {
            _cookieContainer = new CookieContainer();

            _httpClientHandler = new HttpClientHandler 
            { 
                UseCookies = true,
                CookieContainer = _cookieContainer,

                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                AllowAutoRedirect = true
            };

            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", USERAGENT);
        }

        public async Task<SkolplattformenUser> GetUserAsync() =>
            await _httpClient.GetFromJsonAsync<SkolplattformenUser>(Routes.User);

        public async Task<SkolplattformenChild[]> GetChildrenAsync() =>
            await _httpClient.GetEtjanstObjectAsync<SkolplattformenChild[]>(Routes.Children);

        public async Task<SkolplattformenCalendarItem[]> GetCalendarAsync(SkolplattformenChild child) =>
            await _httpClient.GetEtjanstObjectAsync<SkolplattformenCalendarItem[]>(Routes.Calendar(child.Id));

        public async Task<SkolplattformenClassmate[]> GetClassmatesAsync(SkolplattformenChild child) =>
            await _httpClient.GetEtjanstObjectAsync<SkolplattformenClassmate[]>(Routes.Classmates(child.Id));

        public async Task<SkolplattformenScheduleItem[]> GetScheduleAsync(SkolplattformenChild child, DateTime from, DateTime to) =>
            await _httpClient.GetEtjanstObjectAsync<SkolplattformenScheduleItem[]>(Routes.Schedule(child.Id, from, to));

        public async Task<SkolplattformenNewsItem[]> GetNewsAsync(SkolplattformenChild child) =>
            (await _httpClient.GetEtjanstObjectAsync<SkolplattformenNewsItem.Container>(Routes.News(child.Id))).NewsItems;

        public async Task<SkolplattformenNewsItem> GetNewsItemDetailsAsync(SkolplattformenChild child, SkolplattformenNewsItem newsItem) =>
            (await _httpClient.GetEtjanstObjectAsync<SkolplattformenNewsItem.Container>(Routes.NewsDetails(child.Id, newsItem.Id))).CurrentNewsItem;

        public async Task<SkolplattformenMenuItem[]> GetMenuAsync(SkolplattformenChild child) =>
            await _httpClient.GetEtjanstObjectAsync<SkolplattformenMenuItem[]>(Routes.Menu(child.Id));

        public async Task<SkolplattformenNotification[]> GetNotificationsAsync(SkolplattformenChild child) =>
            await _httpClient.GetEtjanstObjectAsync<SkolplattformenNotification[]>(Routes.Notifications(child.Id));

        public void Dispose() => _httpClient.Dispose();
    }
}
