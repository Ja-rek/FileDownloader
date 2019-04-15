using System;
using System.IO;
using System.Net.Http;
using Monads;

namespace DownloadBoot.Download
{
    internal class HttpService
    {
        private HttpClient client;

        public HttpService()
        {
            client = new HttpClient();
            client.Timeout = new TimeSpan(0, 60, 0);
        }

        public Maybe<string> GetAsString(string endpoint)
        {
            var result = client.GetAsync(endpoint).Result;

            if (result.IsSuccessStatusCode)
            {
                return result.Content
                    .ReadAsStringAsync()
                    .Result;
            }

            return null;
        }

        public Maybe<Stream> GetAsStream(string endpoint)
        {
            var result = client.GetAsync(endpoint).Result;

            if (result.IsSuccessStatusCode)
            {
                return result.Content
                    .ReadAsStreamAsync()
                    .Result;
            }

            return null;
        }
    }
}
