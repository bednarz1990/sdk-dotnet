using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders.POCO
{
    /// <summary>
    /// Enum VoiceEnum
    /// </summary>
    public enum VoiceEnum
    {
        /// <summary>
        /// The female a
        /// </summary>
        [XmlEnum(Name = "female-a")] FEMALE_A = 1,
        /// <summary>
        /// The female b
        /// </summary>
        [XmlEnum(Name = "female-b")] FEMALE_B,
        /// <summary>
        /// The female c
        /// </summary>
        [XmlEnum(Name = "female-c")] FEMALE_C,
        /// <summary>
        /// The male a
        /// </summary>
        [XmlEnum(Name = "male-a")] MALE_A,
        /// <summary>
        /// The male b
        /// </summary>
        [XmlEnum(Name = "male-b")] MALE_B,
        /// <summary>
        /// The male c
        /// </summary>
        [XmlEnum(Name = "male-c")] MALE_C
    }
}