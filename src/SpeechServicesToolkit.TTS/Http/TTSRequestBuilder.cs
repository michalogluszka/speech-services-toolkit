using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SpeechServicesToolkit.TTS.Http
{
    class TTSRequestBuilder
    {
        public TTSRequest Build(TTSRequestParameters parameters)
        {
            var request = new TTSRequest();            

            request.Headers.Add(new KeyValuePair<string, string>("Content-Type", "application/ssml+xml"));

            string outputFormat = ConvertOutputFormat(parameters.OutputFormat);
            request.Headers.Add(new KeyValuePair<string, string>("X-Microsoft-OutputFormat", outputFormat));
            // authorization Header
            request.Headers.Add(new KeyValuePair<string, string>("Authorization", parameters.AuthorizationToken));
            // Refer to the doc
            request.Headers.Add(new KeyValuePair<string, string>("X-Search-AppId", "07D3234E49CE426DAA29772419F436CA"));
            // Refer to the doc
            request.Headers.Add(new KeyValuePair<string, string>("X-Search-ClientID", "1ECFAE91408841A480F00935DC390960"));
            // The software originating the requestB
            request.Headers.Add(new KeyValuePair<string, string>("User-Agent", "TTSClient"));

            request.RequestMessage = new HttpRequestMessage(HttpMethod.Post, parameters.RequestUri)
            {
                Content = new StringContent(parameters.Ssml)
            };

            return request;

        }

        private string ConvertOutputFormat(AudioOutputFormat format)
        {
            switch (format)
            {
                case AudioOutputFormat.Raw16Khz16BitMonoPcm:
                    return "raw-16khz-16bit-mono-pcm";
                case AudioOutputFormat.Raw8Khz8BitMonoMULaw:
                    return "raw-8khz-8bit-mono-mulaw";
                case AudioOutputFormat.Riff16Khz16BitMonoPcm:
                    return "riff-16khz-16bit-mono-pcm";
                case AudioOutputFormat.Riff8Khz8BitMonoMULaw:
                    return "riff-8khz-8bit-mono-mulaw";
                case AudioOutputFormat.Ssml16Khz16BitMonoSilk:
                    return "ssml-16khz-16bit-mono-silk";
                case AudioOutputFormat.Raw16Khz16BitMonoTrueSilk:
                    return "raw-16khz-16bit-mono-truesilk";
                case AudioOutputFormat.Ssml16Khz16BitMonoTts:
                    return "ssml-16khz-16bit-mono-tts";
                case AudioOutputFormat.Audio16Khz128KBitRateMonoMp3:
                    return "audio-16khz-128kbitrate-mono-mp3";
                case AudioOutputFormat.Audio16Khz64KBitRateMonoMp3:
                    return "audio-16khz-64kbitrate-mono-mp3";
                case AudioOutputFormat.Audio16Khz32KBitRateMonoMp3:
                    return "audio-16khz-32kbitrate-mono-mp3";
                case AudioOutputFormat.Audio16Khz16KbpsMonoSiren:
                    return "audio-16khz-16kbps-mono-siren";
                case AudioOutputFormat.Riff16Khz16KbpsMonoSiren:
                    return "riff-16khz-16kbps-mono-siren";
                case AudioOutputFormat.Raw24Khz16BitMonoPcm:
                    return "raw-24khz-16bit-mono-pcm";
                case AudioOutputFormat.Riff24Khz16BitMonoPcm:
                    return "riff-24khz-16bit-mono-pcm";
                case AudioOutputFormat.Audio24Khz48KBitRateMonoMp3:
                    return "audio-24khz-48kbitrate-mono-mp3";
                case AudioOutputFormat.Audio24Khz96KBitRateMonoMp3:
                    return "audio-24khz-96kbitrate-mono-mp3";
                case AudioOutputFormat.Audio24Khz160KBitRateMonoMp3:
                    return "audio-24khz-160kbitrate-mono-mp3";
                default:
                    return "riff-16khz-16bit-mono-pcm";
            }

        }
    }
}
