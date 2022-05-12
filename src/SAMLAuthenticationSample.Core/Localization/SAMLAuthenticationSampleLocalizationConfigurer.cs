using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SAMLAuthenticationSample.Localization
{
    public static class SAMLAuthenticationSampleLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SAMLAuthenticationSampleConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SAMLAuthenticationSampleLocalizationConfigurer).GetAssembly(),
                        "SAMLAuthenticationSample.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
