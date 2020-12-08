using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

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
                    try
                    {
                        return (T)xmlSerializer.Deserialize(fs);
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            return default(T);
        }

        public static void ValidateXml(string xsdPath, string xmlPath)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("http://p.lodz.pl", xsdPath);
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(xmlPath, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
                document.Validate(eventHandler);
            }
            catch (XmlSchemaValidationException ex)
            {
                throw new XmlSchemaValidationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new FileLoadException(ex.Message);
            }
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    throw new XmlSchemaValidationException(e.Message);
                case XmlSeverityType.Warning:
                    throw new XmlSchemaValidationException(e.Message);
            }
        }

        public static void XsltTransform(string xslPath, string xmlPath, string htmlPath)
        {
            XslTransform xslt = new XslTransform();
            xslt.Load(xslPath);

            XPathDocument mydata = new XPathDocument(xmlPath);

            using (FileStream fs = new FileStream(htmlPath, FileMode.OpenOrCreate))
            {
                xslt.Transform(mydata, null, fs, null);
            }
        }


    }
}
