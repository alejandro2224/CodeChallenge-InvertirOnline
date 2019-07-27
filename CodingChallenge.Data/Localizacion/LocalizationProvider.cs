using System.Globalization;
using System.Resources;

namespace CodingChallenge.Data.Localizacion
{
    public class LocalizationProvider : ILocalizationProvider
    {
        private ResourceManager _resourceManager;

        public LocalizationProvider()
        {
            _resourceManager = new ResourceManager(
                "CodingChallenge.Data.Localizacion.Localizacion",
                GetType().Assembly)
            {
                IgnoreCase = true
            };
        }

        public string GetTranslation(string key, string twoKeyCulture)
        {
            return _resourceManager.GetString(
                key,
                new CultureInfo(twoKeyCulture));
        }
    }
}
