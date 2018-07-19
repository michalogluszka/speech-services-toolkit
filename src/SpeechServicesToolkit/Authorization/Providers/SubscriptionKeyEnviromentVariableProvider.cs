using System;
using System.Collections.Generic;
using System.Text;

namespace SpeechServicesToolkit.Authorization.Providers
{
    public class SubscriptionKeyEnviromentVariableProvider : ISubscriptionKeyProvider
    {

        private string _subscriptionKeyVariableName;

        public SubscriptionKeyEnviromentVariableProvider(string subscriptionKeyVariableName)
        {
            _subscriptionKeyVariableName = subscriptionKeyVariableName;
        }

        public string GetSubscriptionKey()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable(_subscriptionKeyVariableName, EnvironmentVariableTarget.User);

            if (String.IsNullOrEmpty(subscriptionKey))
                throw new InvalidOperationException("Missing environment variable:" + _subscriptionKeyVariableName);


            return subscriptionKey;

        }
    }
}
