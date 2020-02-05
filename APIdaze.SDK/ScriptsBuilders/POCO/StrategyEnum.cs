using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders.POCO
{
    /// <summary>
    /// Enum StrategyEnum
    /// </summary>
    public enum StrategyEnum
    {
        /// <summary>
        /// The simultaneous
        /// </summary>
        [XmlEnum(Name = "simultaneous")] SIMULTANEOUS = 1,
        /// <summary>
        /// The sequence
        /// </summary>
        [XmlEnum(Name = "sequence")] SEQUENCE = 2
    }
}