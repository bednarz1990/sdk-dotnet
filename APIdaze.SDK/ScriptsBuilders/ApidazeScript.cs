using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders
{
    [XmlRoot(ElementName = "document",
        DataType = "string",
        IsNullable = false)]
    public class ApidazeScript
    {
        [XmlArrayItem(typeof(Answer), ElementName = "answer")]
        [XmlArrayItem(typeof(Hangup), ElementName = "hangup")]
        [XmlArrayItem(typeof(Playback), ElementName = "playback")]
        [XmlArrayItem(typeof(Bind), ElementName = "bind")]
        [XmlArray("work")]
        public List<object> Nodes { get; set; }

        public ApidazeScript AddNode(object node)
        {
            Nodes.Add(node);
            return this;
        }

        public ApidazeScript()
        {
            Nodes = new List<object>();
        }
        public string ToXml()
        {
            var listOfType = new List<Type>() { typeof(Hangup), typeof(Answer), typeof(Playback), typeof(Bind) };

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Fragment,
                CloseOutput = false,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            };

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ApidazeScript), listOfType.ToArray());

            MemoryStream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(stream, settings);
            serializer.Serialize(stream, this, xns);
            stream.Position = 0;
            return Encoding.UTF8.GetString(stream.GetBuffer());
        }

    }
}
