using Microsoft.CognitiveServices.Speech;
using SpeechServicesToolkit.Authorization.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeechServicesToolkit.STT
{
    public class Recorder
    {
        private string _key = String.Empty;

        public Recorder()
        {
            var keyProvider = new SubscriptionKeyEnviromentVariableProvider("SpeechServiceSubscriptionKey");
            _key = keyProvider.GetSubscriptionKey();
        }

        public void Record()
        {
            var config = SpeechConfig.FromSubscription(_key, "westeurope");


        }
    }
}
