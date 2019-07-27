namespace CodingChallenge.Data.Localizacion
{
    public interface ILocalizationProvider
    {
        string GetTranslation(string key, string twoKeyCulture);
    }
}