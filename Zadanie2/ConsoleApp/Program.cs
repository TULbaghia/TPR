using ModelClasses.XmlModel;
using ModelClasses.Zadanie1.Data;
using ModelClasses.Zadanie2;
using Serializer;
using System;
using System.IO;
using System.Xml.Schema;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath, xsdFilePath, xsltFilePath, htmlFilePath;
            Class1 class1Deserialized = null;
            DataContext dataContextDeserialized = null;
            Katalog katalogDeserialized = null;

            Console.WriteLine("         Zadanie 2 - Serializacja        \r");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("Custom - Graph");
            Console.WriteLine("\t1 - Graph custom serialization");
            Console.WriteLine("\t2 - Graph custom deserialization");
            Console.WriteLine("\t3 - Show deserialized Graph object");
            Console.WriteLine("JSON - Graph");
            Console.WriteLine("\t4 - Graph JSON serialization");
            Console.WriteLine("\t5 - Graph JSON deserialization");
            Console.WriteLine("\t6 - Show deserialized JSON Graph object");
            Console.WriteLine("JSON - Zadanie1");
            Console.WriteLine("\t7 - DataContext JSON serialization");
            Console.WriteLine("\t8 - DataContext JSON deserialization");
            Console.WriteLine("\t9 - Show deserialized JSON object");
            Console.WriteLine("XML - Katalog");
            Console.WriteLine("\t10 - Katalog XML serialization");
            Console.WriteLine("\t11 - Katalog XML deserialization");
            Console.WriteLine("\t12 - Show deserialized Katalog XML object");
            Console.WriteLine("\t13 - Validate XML from serialized Katalog");
            Console.WriteLine("\t14 - Transform XML from serialized Katalog");
            Console.WriteLine("0 - Exit");

            do
            {
                Console.Write("\nYour choice: ");
                switch (Console.ReadLine())
                {
                    #region MySerializer graph options
                    case "1":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }
                            Class1 class1 = new Class1("KLASA1", DateTime.Now, 1.1d);
                            Class2 class2 = new Class2("KLASA2", DateTime.Now, 2.2d);
                            Class3 class3 = new Class3("KLASA3", DateTime.Now, 3.3d);
                            class1.Class2 = class2;
                            class1.Class3 = class3;
                            class2.Class1 = class1;
                            class2.Class3 = class3;
                            class3.Class1 = class1;
                            class3.Class2 = class2;
                            MySerializer mySerializer = new MySerializer();
                            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                            {
                                mySerializer.Serialize(fs, class1);
                                Console.WriteLine("> Serialization done");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                MySerializer mySerializer = new MySerializer();
                                using (FileStream fsDes = new FileStream(filePath, FileMode.Open))
                                {
                                    class1Deserialized = (Class1)mySerializer.Deserialize(fsDes);
                                    Console.WriteLine("> Deserialization done");
                                }
                            }
                            else
                            {
                                Console.WriteLine("> Given filePath does not exist");
                            }
                            break;
                        }
                    case "3":
                        {
                            if (class1Deserialized == null)
                            {
                                Console.WriteLine("> You should deserialize the class first");
                            }
                            else Console.WriteLine(class1Deserialized.ToString());
                            break;
                        }
                    #endregion

                    #region JsonSerializer graph options
                    case "4":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }
                            Class1 class1 = new Class1("KLASA1", new DateTime(2011, 1, 1, 1, 1, 1), 1.1d);
                            Class2 class2 = new Class2("KLASA2", new DateTime(2022, 2, 2, 2, 2, 2), 2.2d);
                            Class3 class3 = new Class3("KLASA3", new DateTime(2033, 3, 3, 3, 3, 3), 3.3d);
                            class1.Class2 = class2;
                            class1.Class3 = class3;
                            class2.Class1 = class1;
                            class2.Class3 = class3;
                            class3.Class1 = class1;
                            class3.Class2 = class2;
                            JsonSerializer.Serialize(class1, filePath);
                            Console.WriteLine("> Serialization done");
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                try
                                {
                                    class1Deserialized = (Class1)JsonSerializer.Deserialize<Class1>(filePath);
                                    Console.WriteLine("> Deserialization done");
                                }
                                catch (Exception e)
                                {
                                    class1Deserialized = null;
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("> Given filePath does not exist");
                            }
                            break;
                        }
                    case "6":
                        {
                            if (class1Deserialized == null)
                            {
                                Console.WriteLine("> You should deserialize the class first");
                            }
                            else Console.WriteLine(class1Deserialized.ToString());
                            break;
                        }
                    #endregion

                    #region JsonSerializer zadanie1 options
                    case "7":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }
                            DataContext dataContext = new DataContext();
                            IDataFiller dataFiller = new ConstDataFiller();
                            dataFiller.Fill(dataContext);
                            JsonSerializer.Serialize(dataContext, filePath);
                            Console.WriteLine("> Serialization done");
                            break;
                        }
                    case "8":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (File.Exists(filePath))
                            {
                                try
                                {
                                    dataContextDeserialized = (DataContext)JsonSerializer.Deserialize<DataContext>(filePath);
                                    Console.WriteLine("> Deserialization done");
                                }
                                catch (Exception e) 
                                {
                                    dataContextDeserialized = null;
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("> Given filePath does not exist");
                            }
                            break;
                        }
                    case "9":
                        {
                            if (dataContextDeserialized == null)
                            {
                                Console.WriteLine("> You should deserialize the class first");
                            }
                            else Console.WriteLine(dataContextDeserialized.ToString());
                            break;
                        }
                    #endregion

                    #region XML Katalog options
                    case "10":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (!filePath.Contains("\\"))
                            {
                                filePath = ".\\XmlModel\\" + filePath;
                            }
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }
                            Katalog katalog = new Katalog();
                            IXmlDataFiller xmlFiller = new ConstXmlDataFiller();
                            xmlFiller.Fill(katalog);
                            XmlSerialization.Serialize(katalog, filePath, "Katalog.xslt");
                            Console.WriteLine("> Serialization done");
                            break;
                        }
                    case "11":
                        {
                            Console.Write("Enter file path: ");
                            filePath = Console.ReadLine();
                            if (!filePath.Contains("\\"))
                            {
                                filePath = ".\\XmlModel\\" + filePath;
                            }
                            if (File.Exists(filePath))
                            {
                                try 
                                {
                                    katalogDeserialized = XmlSerialization.Deserialize<Katalog>(filePath);
                                    Console.WriteLine("> Deserialization done");
                                }
                                catch (Exception e)
                                {
                                    katalogDeserialized = null;
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("> Given filePath does not exist");
                            }
                            break;
                        }
                    case "12":
                        {
                            if (katalogDeserialized == null)
                            {
                                Console.WriteLine("> You should deserialize the class first");
                            }
                            else Console.WriteLine(katalogDeserialized.ToString());
                            break;
                        }
                    case "13":
                        {
                            Console.Write("Enter xml file path: ");
                            filePath = Console.ReadLine();
                            if (!filePath.Contains("\\"))
                            {
                                filePath = ".\\XmlModel\\" + filePath;
                            }
                            Console.Write("Enter xsd file path: ");
                            xsdFilePath = Console.ReadLine();
                            if (!xsdFilePath.Contains("\\"))
                            {
                                xsdFilePath = ".\\XmlModel\\" + xsdFilePath;
                            }
                            try
                            {
                                XmlSerialization.ValidateXml(xsdFilePath, filePath);
                                Console.WriteLine("Validation successful");
                            } 
                            catch (XmlSchemaValidationException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch (FileLoadException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case "14":
                        {
                            Console.Write("Enter xml file path: ");
                            filePath = Console.ReadLine();
                            if (!filePath.Contains("\\"))
                            {
                                filePath = ".\\XmlModel\\" + filePath;
                            }
                            Console.Write("Enter xslt file path: ");
                            xsltFilePath = Console.ReadLine();
                            if (!xsltFilePath.Contains("\\"))
                            {
                                xsltFilePath = ".\\XmlModel\\" + xsltFilePath;
                            }
                            Console.Write("Enter result file path: ");
                            htmlFilePath = Console.ReadLine();
                            if (!htmlFilePath.Contains("\\"))
                            {
                                htmlFilePath = ".\\XmlModel\\" + htmlFilePath;
                            }
                            try
                            {
                                XmlSerialization.XsltTransform(xsltFilePath, filePath, htmlFilePath);
                                Console.WriteLine("Transformation successful");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    #endregion

                    #region Options handling
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("> Unknown option");
                            break;
                        }
                    #endregion
                }

            } while (true);
        }
    }
}
