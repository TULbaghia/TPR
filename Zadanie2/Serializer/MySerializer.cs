using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Serializer
{
    public class MySerializer : Formatter
    {
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private StringBuilder StringBuilder { get; set; }
        public MySerializer()
        {
            Binder = new MySerializerBinder();
            StringBuilder = new StringBuilder();
            Context = new StreamingContext();
        }
        public override object Deserialize(Stream serializationStream)
        {
            byte[] bytes = new byte[serializationStream.Length];
            serializationStream.Read(bytes);
            String text = Encoding.UTF8.GetString(bytes);

            String[] lines = text.Split(Environment.NewLine);

            List<BuildHelper> objects = new List<BuildHelper>();
            List<KeyValuePair<int, String>> currentClass = new List<KeyValuePair<int, String>>();

            for (int i = 0; i < lines.Length-1; i++)
            {
                char endChar = lines[i][lines[i].Length - 1];
                String[] tmpSplitByQuote = lines[i].Split("\"");

                BuildHelper buildHelper = new BuildHelper();
                if (currentClass.Count != 0)
                {
                    buildHelper.parentObject = currentClass[currentClass.Count - 1];
                    buildHelper.currentObject = currentClass[currentClass.Count - 1];
                }

                if ( endChar == '}')
                {
                    if( lines[i][0] == '}' )
                    {
                        currentClass.RemoveAt(currentClass.Count-1);
                        continue;
                    } 
                    else
                    {
                        buildHelper.variableName = tmpSplitByQuote[1];
                        if ( lines[i].Contains("{\"type\": "))
                        {
                            buildHelper.type = tmpSplitByQuote[5];
                            buildHelper.value = lines[i].Substring(lines[i].IndexOf(buildHelper.type) + buildHelper.type.Length + "\", \"value\": \"".Length).TrimEnd(new char[] { '"', '}' });

                        } else
                        {
                            String[] tmp = lines[i].Split("{ ")[1].TrimEnd(new char[] { ' ', '}' }).Split(", ");
                            buildHelper.childObject = new KeyValuePair<int, string>(int.Parse(tmp[0]), tmp[1]);
                            buildHelper.type = "REFERENCE";
                        }
                    }
                } 
                else
                {
                    buildHelper.variableName = tmpSplitByQuote[1];
                    buildHelper.assemblyName = tmpSplitByQuote[3];
                    buildHelper.type = "OBJECT";
                    String[] tmp = lines[i].Split("{ ")[1].Split(", ");
                    buildHelper.currentObject = new KeyValuePair<int, string>(int.Parse(tmp[0]), tmp[1]);
                    if (tmp[1].Equals("System.String"))
                    {
                        buildHelper.value = lines[++i];
                    }
                    currentClass.Add(buildHelper.currentObject);
                }
                objects.Add(buildHelper);
            }

            //fill SerializationInfo with null references and values
            Dictionary<int, object> deserializedObjectList = new Dictionary<int, object>();
            Dictionary<int, SerializationInfo> objectList = new Dictionary<int, SerializationInfo>();
            foreach (BuildHelper bh in objects)
            {
                if(bh.type == "OBJECT")
                {
                    if (bh.currentObject.Value == "System.String")
                    {
                        objectList.TryGetValue(bh.parentObject.Key, out SerializationInfo parentSerializationInfo);
                        parentSerializationInfo.AddValue(bh.variableName, null);
                        deserializedObjectList.Add(bh.currentObject.Key, new String(bh.value));
                        continue;
                    }
                    SerializationInfo serializationInfo = new SerializationInfo(Binder.BindToType(bh.assemblyName, bh.currentObject.Value), new FormatterConverter());
                    objectList.Add(bh.currentObject.Key, serializationInfo);
                    if( !bh.variableName.Equals("") )
                    {
                        objectList.TryGetValue(bh.parentObject.Key, out SerializationInfo parentSerializationInfo);
                        parentSerializationInfo.AddValue(bh.variableName, null);
                    }
                } 
                else
                {
                    objectList.TryGetValue(bh.currentObject.Key, out SerializationInfo serializationInfo);
                    if (bh.type.Equals("REFERENCE"))
                    {
                        serializationInfo.AddValue(bh.variableName, bh.value);
                    }
                    else
                    {
                        Type pType = Type.GetType(bh.type);
                        serializationInfo.AddValue(bh.variableName, Convert.ChangeType(bh.value, pType, CultureInfo.InvariantCulture), pType);
                    }
                }
            }

            foreach (KeyValuePair<int, SerializationInfo> x in objectList)
            {
                object o = Activator.CreateInstance(x.Value.ObjectType, x.Value, Context);
                deserializedObjectList.Add(x.Key, o);
            }

            //add references to deserialized objects
            foreach (BuildHelper bh in objects)
            {
                if (bh.childObject.Key.Equals(-1))
                {
                    continue;
                }
                if (bh.type == "OBJECT" && !bh.variableName.Equals(""))
                {
                    object o = deserializedObjectList[bh.parentObject.Key];
                    //foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                    //{
                    //    if (propertyInfo.Name.ToLower().Equals(bh.variableName.ToLower()))
                    //    {
                    //        propertyInfo.SetValue(o, deserializedObjectList[bh.currentObject.Key]);
                    //    }
                    //}
                    foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == deserializedObjectList[bh.currentObject.Key].GetType())
                        {
                            propertyInfo.SetValue(o, deserializedObjectList[bh.currentObject.Key]);
                        }
                    }
                }
                if (bh.type == "REFERENCE")
                {
                    object o = deserializedObjectList[bh.currentObject.Key];
                    //foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                    //{
                    //    if (propertyInfo.Name.ToLower().Equals(bh.variableName.ToLower()))
                    //    {
                    //        propertyInfo.SetValue(o, deserializedObjectList[bh.childObject.Key]);
                    //    }
                    //}
                    foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == deserializedObjectList[bh.childObject.Key].GetType())
                        {
                            propertyInfo.SetValue(o, deserializedObjectList[bh.childObject.Key]);
                        }
                    }
                }
            }

            return deserializedObjectList[1];
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            m_idGenerator = new ObjectIDGenerator();
            WriteMember("", graph);
            serializationStream.Write(Encoding.UTF8.GetBytes(StringBuilder.ToString()));
            serializationStream.Flush();
            StringBuilder.Clear();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (obj == null)
            {
                StringBuilder.AppendLine("\"" + name + "\": " + "{ -1, null }");
            }
            else
            {
                if (obj is ISerializable serializable)
                {
                    Binder.BindToName(obj.GetType(), out string assemblyInfo, out string typeName);
                    StringBuilder.Append("\"" + name + "\": " + "{ " + m_idGenerator.GetId(obj, out bool firstTime) + ", " + typeName);

                    if (firstTime)
                    {
                        StringBuilder.AppendLine(", \"" + assemblyInfo + "\"");
                        SerializationInfo serializationInfo = new SerializationInfo(serializable.GetType(), new FormatterConverter());
                        serializable.GetObjectData(serializationInfo, Context);
                        foreach (SerializationEntry serializationEntry in serializationInfo)
                        {
                            WriteMember(serializationEntry.Name, serializationEntry.Value);
                        }
                        StringBuilder.AppendLine("}");
                    } else
                    {
                        StringBuilder.AppendLine(" }");
                    }
                }
                else if (obj is string serializableString)
                {
                    Binder.BindToName(obj.GetType(), out string assemblyInfo, out string typeName);
                    StringBuilder.Append("\"" + name + "\": " + "{ " + m_idGenerator.GetId(obj, out bool firstTime) + ", " + typeName);

                    if (firstTime)
                    {
                        StringBuilder.AppendLine(", \"" + assemblyInfo + "\"");
                        StringBuilder.AppendLine(serializableString);
                        StringBuilder.AppendLine("}");
                    }
                    else
                    {
                        StringBuilder.AppendLine(" }");
                    }
                }
                else
                {
                    throw new SerializationException();
                }
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            StringBuilder.AppendLine("\"" + name + "\": {\"type\": \"" + val.GetType().FullName + "\", \"value\": \"" + val.ToString(CultureInfo.InvariantCulture) + "\"}");
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            StringBuilder.AppendLine("\"" + name + "\": {\"type\": \"" + val.GetType().FullName + "\", \"value\": \"" + val.ToString(CultureInfo.InvariantCulture) + "\"}");
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            StringBuilder.AppendLine("\"" + name + "\": {\"type\": \"" + val.GetType().FullName + "\", \"value\": \"" + val.ToString(CultureInfo.InvariantCulture) + "\"}");
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}
