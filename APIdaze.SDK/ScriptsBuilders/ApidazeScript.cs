using APIdaze.SDK.ScriptsBuilders.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders
{
    //, DataType = "string", IsNullable = false
    [XmlRoot(ElementName = "document")]
    public class ApidazeScript
    {
        public ApidazeScript()
        {
            Nodes = new List<object>();
        }

        [XmlArrayItem(typeof(Conference), ElementName = "conference")]
        [XmlArrayItem(typeof(Echo), ElementName = "echo")]
        [XmlArrayItem(typeof(Intercept), ElementName = "intercept")]
        [XmlArrayItem(typeof(Record), ElementName = "record")]
        [XmlArrayItem(typeof(Ringback), ElementName = "ringback")]
        [XmlArrayItem(typeof(Speak), ElementName = "speak")]
        [XmlArrayItem(typeof(Wait), ElementName = "wait")]
        [XmlArrayItem(typeof(Answer), ElementName = "answer")]
        [XmlArrayItem(typeof(Hangup), ElementName = "hangup")]
        [XmlArrayItem(typeof(Playback), ElementName = "playback")]
        [XmlArrayItem(typeof(Bind), ElementName = "bind")]
        [XmlArrayItem(typeof(Dial), ElementName = "dial")]
        [XmlArray("work")]
        public List<object> Nodes { get; set; }

        public ApidazeScript AddNode(object node)
        {
            Nodes.Add(node);
            return this;
        }

        public string ToXml(bool withFormatting = true)
        {
            var listOfType = new List<Type> { typeof(Hangup), typeof(Answer),
                typeof(Playback), typeof(Bind), typeof(Dial), typeof(Conference),
                typeof(Echo), typeof(Intercept), typeof(Record), typeof(Ringback),
                typeof(Speak), typeof(Wait) };

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Document,
                CloseOutput = false,
                NamespaceHandling = NamespaceHandling.OmitDuplicates,
                Indent = withFormatting,
            };

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            var serializer = new XmlSerializer(typeof(ApidazeScript), listOfType.ToArray());

            using var stream = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stream, settings);

            serializer.Serialize(xmlWriter, this, xns);
            var withoutSpace = stream.ToString().Replace(" />", "/>");
            return withoutSpace;
        }
    }
}