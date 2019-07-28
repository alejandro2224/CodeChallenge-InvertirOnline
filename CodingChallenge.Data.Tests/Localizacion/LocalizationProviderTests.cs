using System;
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
            var localizationProvider = LocalizationProvider.Instance;
            const string key = "Square";

            var esTranslation = localizationProvider.GetTranslation(
                key,
                Language.Es);

            var enTranslation = localizationProvider.GetTranslation(
                key,
                Language.En);

            var itTranslation = localizationProvider.GetTranslation(
                key,
                Language.It);

            Assert.That(esTranslation, Is.EqualTo("Cuadrado"));
            Assert.That(enTranslation, Is.EqualTo("Square"));
            Assert.That(itTranslation, Is.EqualTo("Quadrato"));
        }

        [Test]
        public void GetTranslationMustThrowException()
        {
            var localizationProvider = LocalizationProvider.Instance;
            Assert.Throws<ArgumentNullException>(
                () => localizationProvider.GetTranslation(null, Language.En));
        }
    }
}
