using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Skolplattformen
{
    internal static class EtjanstExtensions
    {
        public static async Task<T> GetEtjanstObjectAsync<T>(this HttpClient httpClient, Uri requestUri)
        {
            var etjanstResponse = await httpClient.GetFromJsonAsync<EtjanstResponse<T>>(requestUri);

            if (!etjanstResponse.Success)
                throw new EtjanstException(etjanstResponse.Error);

            return etjanstResponse.Data;
        }
    }

    internal class EtjanstResponse<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
