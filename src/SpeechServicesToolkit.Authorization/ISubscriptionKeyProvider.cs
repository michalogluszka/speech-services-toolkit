using System;
using System.Collections.Generic;
using System.Text;

namespace SpeechServicesToolkit.Authorization
{
    public interface ISubscriptionKeyProvider
    {
        /// <summary>
        /// Provides endpoint and subscription key
        /// </summary>
        /// <returns>endpoint,subscriptionkey</returns>
        string GetSubscriptionKey();
    }
}
