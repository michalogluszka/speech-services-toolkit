using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeechServicesToolkit.TTS.Http
{
    //TODO: This shouldn't be wrapper
    class TTSClientWrapper : IDisposable
    {
        private HttpClient _client;

        private HttpClientHandler _clientHandler;

        public TTSClientWrapper()
        {
            var cookieContainer = new CookieContainer();
            
            _clientHandler = new HttpClientHandler() { CookieContainer = new CookieContainer(), UseProxy = false };
            
            _client = new HttpClient(_clientHandler);
        }

        public Task<HttpResponseMessage> SendAsync(TTSRequest ttsRequest, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            _client.DefaultRequestHeaders.Clear();

            foreach (var header in ttsRequest.Headers)
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            var response = _client.SendAsync(ttsRequest.RequestMessage);

            return response;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                    _clientHandler.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TTSClientWrapper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
