using ActiveLogin.Identity.Swedish;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Skolplattformen
{
    using Routes = SkolplattformenBankIdRoutes;

    // From https://github.com/kolplattformen/embedded-api/blob/main/lib/api.ts
    public partial class SkolplattformenVardnadshavareClient
    {
        private SkolplattformenBankidStatus _bankIdStatus;

        public SkolplattformenBankidStatus BankIdStatus
        {
            get => _bankIdStatus;
            set
            {
                if (_bankIdStatus != value)
                {
                    _bankIdStatus = value;
                    BankidStatusChanged?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<SkolplattformenBankidStatus> BankidStatusChanged;

        /// <summary> You can subscribe to <see cref="BankidStatusChanged"/> for updates on the progress. </summary>
        public async Task<bool> TryAuthenticateAsync(string identityNumber) => await TryAuthenticateAsync(identityNumber, CancellationToken.None);

        /// <summary> You can subscribe to <see cref="BankidStatusChanged"/> for updates on the progress. </summary>
        public async Task<bool> TryAuthenticateAsync(string identityNumber, CancellationToken cancellationToken) => await TryAuthenticateAsync(SwedishPersonalIdentityNumber.Parse(identityNumber), cancellationToken);

        /// <summary> You can subscribe to <see cref="BankidStatusChanged"/> for updates on the progress. </summary>
        public async Task<bool> TryAuthenticateAsync(SwedishPersonalIdentityNumber identityNumber) => await TryAuthenticateAsync(identityNumber, CancellationToken.None);

        /// <summary> You can subscribe to <see cref="BankidStatusChanged"/> for updates on the progress. </summary>
        public async Task<bool> TryAuthenticateAsync(SwedishPersonalIdentityNumber identityNumber, CancellationToken cancellationToken)
        {
            var ticket = await _httpClient.GetFromJsonAsync<SkolplattformenBankIdAuthTicket>(Routes.Login(identityNumber.To12DigitString()));

            while(true)
            {
                var status = await _httpClient.GetStringAsync(Routes.LoginStatus(ticket.Order), cancellationToken);

                if (Enum.TryParse(status.Remove("!").Remove("_"), true, out SkolplattformenBankidStatus bankIdStatus))
                    BankIdStatus = bankIdStatus;
                else
                    BankIdStatus = SkolplattformenBankidStatus.Unknown;

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
