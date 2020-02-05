using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders.POCO
{
    /// <summary>
    /// Class Conference.
    /// </summary>
    public class Conference
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlText(typeof(string))] public string Name { get; set; }
    }
}
