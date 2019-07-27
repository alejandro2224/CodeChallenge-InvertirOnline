using CodingChallenge.Data.Localizacion;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests.Localizacion
{
    [TestFixture]
    public class LocalizationProviderTests
    {
        [Test]
        public void MustObtainTranslationInThreeLanguages()
        {
            var localizationProvider = new LocalizationProvider();
            var key = "Square";

            var esTranslation = localizationProvider.GetTranslation(
                key,
                "es");

            var enTranslation = localizationProvider.GetTranslation(
                key,
                "en");

            var itTranslation = localizationProvider.GetTranslation(
                key,
                "it");

            Assert.That(esTranslation, Is.EqualTo("Cuadrado"));
            Assert.That(enTranslation, Is.EqualTo("Square"));
            Assert.That(itTranslation, Is.EqualTo("Quadrato"));
        }
    }
}
