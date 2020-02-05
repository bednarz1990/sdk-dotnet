using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders.POCO
{
    /// <summary>
    /// Enum LangEnum
    /// </summary>
    public enum LangEnum
    {
        /// <summary>
        /// The english us
        /// </summary>
        [XmlEnum(Name = "en-US")] ENGLISH_US = 1,
        /// <summary>
        /// The danish
        /// </summary>
        [XmlEnum(Name = "da-DK")] DANISH,
        /// <summary>
        /// The dutch
        /// </summary>
        [XmlEnum(Name = "nl-NL")] DUTCH,
        /// <summary>
        /// The italian
        /// </summary>
        [XmlEnum(Name = "it-IT")] ITALIAN,
        /// <summary>
        /// The japanese
        /// </summary>
        [XmlEnum(Name = "ja-JP")] JAPANESE,
        /// <summary>
        /// The norwegian
        /// </summary>
        [XmlEnum(Name = "nb-NO")] NORWEGIAN,
        /// <summary>
        /// The portugese brazil
        /// </summary>
        [XmlEnum(Name = "pt-BR")] PORTUGESE_BRAZIL,
        /// <summary>
        /// The portugese portugal
        /// </summary>
        [XmlEnum(Name = "pt-PT")] PORTUGESE_PORTUGAL,
        /// <summary>
        /// The slovak
        /// </summary>
        [XmlEnum(Name = "sk-SK")] SLOVAK,
        /// <summary>
        /// The spanish
        /// </summary>
        [XmlEnum(Name = "es-ES")] SPANISH,
        /// <summary>
        /// The swedish
        /// </summary>
        [XmlEnum(Name = "sv-SE")] SWEDISH,
        /// <summary>
        /// The ukrainian
        /// </summary>
        [XmlEnum(Name = "uk-UA")] UKRAINIAN,
        /// <summary>
        /// The english australia
        /// </summary>
        [XmlEnum(Name = "en-AU")] ENGLISH_AUSTRALIA,
        /// <summary>
        /// The english uk
        /// </summary>
        [XmlEnum(Name = "en-GB")] ENGLISH_UK,
        /// <summary>
        /// The french canada
        /// </summary>
        [XmlEnum(Name = "fr-CA")] FRENCH_CANADA,
        /// <summary>
        /// The french france
        /// </summary>
        [XmlEnum(Name = "fr-FR")] FRENCH_FRANCE,
        /// <summary>
        /// The german
        /// </summary>
        [XmlEnum(Name = "de-DE")] GERMAN,
        /// <summary>
        /// The korean
        /// </summary>
        [XmlEnum(Name = "ko-KR")] KOREAN,
        /// <summary>
        /// The polish
        /// </summary>
        [XmlEnum(Name = "po-PL")] POLISH,
        /// <summary>
        /// The russian
        /// </summary>
        [XmlEnum(Name = "ru-RU")] RUSSIAN,
        /// <summary>
        /// The turkish
        /// </summary>
        [XmlEnum(Name = "tr-TR")] TURKISH,
    }
}