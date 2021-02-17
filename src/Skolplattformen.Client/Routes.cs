using ActiveLogin.Identity.Swedish;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skolplattformen
{
    // From https://github.com/kolplattformen/embedded-api/blob/main/lib/routes.ts

    internal static class SkolplattformenBankIdBankIdRoutes
    {
        public static Uri Login(SwedishPersonalIdentityNumber identityNumber) =>
            new Uri($"https://login003.stockholm.se/NECSadcmbid/authenticate/NECSadcmbid?TARGET=-SM-HTTPS%3a%2f%2flogin001%2estockholm%2ese%2fNECSadc%2fmbid%2fb64startpage%2ejsp%3fstartpage%3daHR0cHM6Ly9ldGphbnN0LnN0b2NraG9sbS5zZS92YXJkbmFkc2hhdmFyZS9pbmxvZ2dhZDIvaGVt&initialize=bankid&personalNumber={identityNumber.To10DigitString()}&_={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");

        public static Uri LoginStatus(string order) =>
            new Uri($"https://login003.stockholm.se/NECSadcmbid/authenticate/NECSadcmbid?TARGET=-SM-HTTPS%3a%2f%2flogin001%2estockholm%2ese%2fNECSadc%2fmbid%2fb64startpage%2ejsp%3fstartpage%3daHR0cHM6Ly9ldGphbnN0LnN0b2NraG9sbS5zZS92YXJkbmFkc2hhdmFyZS9pbmxvZ2dhZDIvaGVt&verifyorder={order}&_={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}");

        public static readonly Uri LoginCookie =
            new Uri("https://login003.stockholm.se/NECSadcmbid/authenticate/SiteMinderAuthADC?TYPE=33554433&REALMOID=06-42f40edd-0c5b-4dbc-b714-1be1e907f2de&GUID=&SMAUTHREASON=0&METHOD=GET&SMAGENTNAME=IfNE0iMOtzq2TcxFADHylR6rkmFtwzoxRKh5nRMO9NBqIxHrc38jFyt56FASdxk1&TARGET=-SM-HTTPS%3a%2f%2flogin001%2estockholm%2ese%2fNECSadc%2fmbid%2fb64startpage%2ejsp%3fstartpage%3daHR0cHM6Ly9ldGphbnN0LnN0b2NraG9sbS5zZS92YXJkbmFkc2hhdmFyZS9pbmxvZ2dhZDIvR2V0Q2hpbGRyZW4%3d");
    }

    internal static class SkolplattformenVardnadshavareRoutes
    {
        public static readonly Uri User =
            new Uri("https://etjanst.stockholm.se/vardnadshavare/base/getuserdata");

        public static readonly Uri Children =
            new Uri("https://etjanst.stockholm.se/vardnadshavare/inloggad2/GetChildren");

        public static Uri Calendar(string childId) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/Calender/GetSchoolCalender?childId={childId}&rowLimit=50");

        public static Uri Classmates(string childId) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/contacts/GetStudentsByClass?studentId={childId}");

        public static Uri News(string childId) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/News/GetNewsOverview?childId={childId}");

        public static Uri NewsDetails(string childId, string newsId) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/News/GetNewsArticle?newsItemId={newsId}&childId={childId}");

        public static Uri Image(string url) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/NewsBanner?url={url}");

        public static Uri Notifications(string childId) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/Overview/GetNotification?childId={childId}");

        public static Uri Menu(string childId) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/Matsedel/GetMatsedelRSS?childId={childId}");

        public static Uri Schedule(string childId, DateTime fromDate, DateTime endDate) =>
            new Uri($"https://etjanst.stockholm.se/vardnadshavare/inloggad2/Calender/GetSchema?childId={childId}&startDate={fromDate}&endDate={endDate}");
    }
}
