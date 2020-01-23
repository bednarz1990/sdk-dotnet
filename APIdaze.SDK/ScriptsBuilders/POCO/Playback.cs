﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace APIdaze.SDK.ScriptsBuilders
{
    public class Playback
    {
        [XmlAttribute("file")]
        public string File { get; set; }

        public static Playback FromFile(string file)
        {
            return new Playback { File = file };
        }

        [XmlElement("bind")]
        public List<Bind> Binds { get; set; }

        [XmlAttribute("input-timeout")]
        public double InputTimeoutMillis { get; set; }
    }
}