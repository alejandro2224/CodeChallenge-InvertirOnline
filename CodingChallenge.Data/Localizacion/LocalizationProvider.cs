using System.Globalization;
using System.Resources;

namespace CodingChallenge.Data.Localizacion
{
    public class LocalizationProvider : ILocalizationProvider
    {
        private readonly ResourceManager _resourceManager;

        public static LocalizationProvider Instance => new LocalizationProvider();

        private LocalizationProvider()
        {
            _resourceManager = new ResourceManager(
                "CodingChallenge.Data.Localizacion.Localizacion",
                GetType().Assembly)
            {
                IgnoreCase = true
            };
        }

        public string GetTranslation(string key, Language language)
        {
            return _resourceManager.GetString(
                key,
                new CultureInfo(language.ToString()));
        }
    }
}
