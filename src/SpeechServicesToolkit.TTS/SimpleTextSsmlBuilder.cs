using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SpeechServicesToolkit.TTS
{
    public class SimpleTextSsmlBuilder : ISsmlBuilder
    {
        /// <summary>
        /// Generates SSML.
        /// </summary>
        /// <param name="locale">The locale.</param>
        /// <param name="voiceType">The gender.</param>
        /// <param name="voiceName">The voice name.</param>
        /// <param name="text">The text input.</param>
        public string GenerateSsml(string locale, string voiceName, string text)
        {
            var ssmlDoc = new XDocument(
                              new XElement("speak",
                                  new XAttribute("version", "1.0"),
                                  new XAttribute(XNamespace.Xml + "lang", "en-US"),
                                  new XElement("voice",
                                      new XAttribute(XNamespace.Xml + "lang", locale),
                                      new XAttribute("name", voiceName),
                                      text)));
            return ssmlDoc.ToString();
        }

        ///// <summary>
        ///// Generates SSML.
        ///// </summary>
        ///// <param name="locale">The locale.</param>
        ///// <param name="voiceType">The gender.</param>
        ///// <param name="voiceName">The voice name.</param>
        ///// <param name="text">The text input.</param>
        //public string GenerateSsml(string locale, Gender voiceType, string text)
        //{
        //    var genderValue = "";
        //    switch (voiceType)
        //    {
        //        case Gender.Male:
        //            genderValue = "Male";
        //            break;

        //        case Gender.Female:
        //        default:
        //            genderValue = "Female";
        //            break;
        //    }

        //    var ssmlDoc = new XDocument(
        //                      new XElement("speak",
        //                          new XAttribute("version", "1.0"),
        //                          new XAttribute(XNamespace.Xml + "lang", "en-US"),
        //                          new XElement("voice",
        //                              new XAttribute(XNamespace.Xml + "lang", locale),
        //                              new XAttribute("name", "Microsoft Server Speech Text to Speech Voice (en-US, Jessa24KRUS)"),
        //                              new XAttribute(XNamespace.Xml + "gender", genderValue),
        //                              text)));
        //    return ssmlDoc.ToString();
        //}



    }
}
