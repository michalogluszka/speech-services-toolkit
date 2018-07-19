using System;
using System.Collections.Generic;
using System.Text;

namespace SpeechServicesToolkit.TTS
{
    public class TTSRequestParameters
    {
        /// <summary>
        /// Gets or sets the request URI.
        /// </summary>
        public Uri RequestUri { get; set; }

        /// <summary>
        /// Authorization Token.
        /// </summary>
        public string AuthorizationToken { get; set; }

        /// <summary>
        /// Gets or sets the ssml
        /// </summary>
        public string Ssml { get; set; }

        public AudioOutputFormat OutputFormat { get; set; }

    }
}
