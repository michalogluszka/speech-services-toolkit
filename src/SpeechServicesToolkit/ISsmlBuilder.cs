namespace SpeechServicesToolkit.TTS
{
    public interface ISsmlBuilder
    {
        string GenerateSsml(string locale, string voiceName, string text);
    }
}