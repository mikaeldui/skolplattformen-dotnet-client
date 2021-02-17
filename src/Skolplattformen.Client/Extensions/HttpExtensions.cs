using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Skolplattformen
{
    /// <summary> Extensions for System.Net.Http. </summary>
    internal static class HttpExtensions
    {
        /// <summary>
        /// Send a GET request to the specified Uri with a cancellation token, and serialize the HTTP content to a string, as an asynchronous operation
        /// </summary>
        [DebuggerStepThrough]
        public static async Task<string> GetStringAsync(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(requestUri, cancellationToken);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
