using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeechServicesToolkit.Authorization;
using SpeechServicesToolkit.Authorization.Providers;
using SpeechServicesToolkit.TTS;

namespace SpeechServicesToolkit.Tests
{
    [TestClass]
    public class TalkerTests
    {
        private string _accessToken;

        private Uri _requestUri = new Uri("https://westus.tts.speech.microsoft.com/cognitiveservices/v1");

        [TestInitialize]
        public void Initialize()
        {
            Uri issueTokenUri = new Uri("https://westus.api.cognitive.microsoft.com/sts/v1.0/issuetoken");

            ISubscriptionKeyProvider provider = new SubscriptionKeyEnviromentVariableProvider("SpeechServiceSubscriptionKey");
            var auth = new AzureAuthToken(provider, issueTokenUri);

            _accessToken = auth.GetAccessToken();
        }

        [TestMethod]
        public void VoiceNameTest()
        {
            var ssmlBuilder = new SimpleTextSsmlBuilder();
            var serviceClient = new Talker();

            serviceClient.OnAudioAvailable += PlayAudio;
            serviceClient.OnError += ErrorHandler;

            string voiceName = "Microsoft Server Speech Text to Speech Voice (en-US, Jessa24KRUS)";
            // string voiceName = "Microsoft Server Speech Text to Speech Voice (en-US, Guy24KRUS)";
            // string voiceName = "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)";

            string ssml = ssmlBuilder.GenerateSsml("en-US", voiceName, "Hello. You are so awesome!");

            var requestParams = new TalkerParameters()
            {
                AuthorizationToken = _accessToken,
                RequestUri = _requestUri,
                OutputFormat = AudioOutputFormat.Riff24Khz16BitMonoPcm,
                Ssml = ssml
            };

            serviceClient.Speak(CancellationToken.None, requestParams).Wait();      
        }

        private static void PlayAudio(object sender, GenericEventArgs<Stream> args)
        {
            Debug.WriteLine(args.EventData);

            // For SoundPlayer to be able to play the wav file, it has to be encoded in PCM.
            // Use output audio format AudioOutputFormat.Riff16Khz16BitMonoPcm to do that.
            SoundPlayer player = new SoundPlayer(args.EventData);
            player.PlaySync();
            args.EventData.Dispose();
        }

        /// <summary>
        /// Handler an error when a TTS request failed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="GenericEventArgs{Exception}"/> instance containing the event data.</param>
        private static void ErrorHandler(object sender, GenericEventArgs<Exception> e)
        {
            Debug.WriteLine("Unable to complete the TTS request: [{0}]", e.ToString());
            Assert.Fail("Failed to connect to server");
        }
    }
}
