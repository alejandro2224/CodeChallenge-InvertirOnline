namespace CodingChallenge.Data.Localizacion
{
    public interface ILocalizationProvider
    {
        string GetTranslation(string key, Language language);
    }
}