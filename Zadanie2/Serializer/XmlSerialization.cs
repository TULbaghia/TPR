using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Serializer
{
    public class XmlSerialization
    {
        public static void Serialize(Object obj, string filePath, string stylesheetName)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                XmlWriter _writer = XmlWriter.Create(fs, new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = "\r\n",
                });
                _writer.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" " + String.Format("href=\"{0}\"", stylesheetName));
                xmlSerializer.Serialize(_writer, obj);
                _writer.Flush();
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    
                    return (T) xmlSerializer.Deserialize(fs);
                }
            }
            return default(T);
        }
    }
}
