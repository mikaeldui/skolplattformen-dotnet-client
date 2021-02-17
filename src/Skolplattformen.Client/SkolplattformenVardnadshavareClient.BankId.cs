using ActiveLogin.Identity.Swedish;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Skolplattformen
{
    using Routes = SkolplattformenBankIdBankIdRoutes;

    // From https://github.com/kolplattformen/embedded-api/blob/main/lib/api.ts
    public partial class SkolplattformenVardnadshavareClient
    {
        private SkolplattformenBankidStatus _bankidStatus;

        public SkolplattformenBankidStatus BankidStatus
        {
            get => _bankidStatus;
            set
            {
                if (_bankidStatus != value)
                {
                    _bankidStatus = value;
                    BankidStatusChanged?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<SkolplattformenBankidStatus> BankidStatusChanged;

        /// <summary>
        /// You can subscribe to <see cref="BankidStatusChanged"/> for updates on the progress.
        /// </summary>
        public async Task<bool> TryAuthenticateAsync(SwedishPersonalIdentityNumber identityNumber, CancellationToken cancellationToken)
        {
            var ticket = await _httpClient.GetFromJsonAsync<SkolplattformenBankIdAuthTicket>(Routes.Login(identityNumber));

            while(true)
            {
                var status = await _httpClient.GetStringAsync(Routes.LoginStatus(ticket.Order), cancellationToken);

                if (Enum.TryParse(status.Remove('!'), true, out SkolplattformenBankidStatus bankidStatus))
                    BankidStatus = bankidStatus;
                else
                    BankidStatus = SkolplattformenBankidStatus.Unknown;

                switch (status)
                {
                    case "OK":
                        var cookieResponse = await _httpClient.GetAsync(Routes.LoginCookie);
                        _ = cookieResponse.Headers.GetValues("Set-Cookie");

                        return true;
                    case "ERROR!":
                        return false;
                    default:
                        await Task.Delay(1000, cancellationToken);
                        break;
                }
            }
        }
    }
}
