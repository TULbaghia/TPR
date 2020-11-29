using System;
using System.Collections.Generic;
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

            String[] lines = text.Split("\n");

            List<BuildHelper> objects = new List<BuildHelper>();
            List<KeyValuePair<int, String>> currentClass = new List<KeyValuePair<int, String>>();

            for (int i = 0; i < lines.Length-1; i++)
            {
                char endChar = lines[i][lines[i].Length - 1];

                if( endChar == '}')
                {
                    if( lines[i][0] == '}' )
                    {
                        currentClass.RemoveAt(currentClass.Count-1);
                    } else
                    {
                        BuildHelper buildHelper = new BuildHelper();
                        if (currentClass.Count != 0)
                        {
                            buildHelper.parentObject = currentClass[currentClass.Count - 1];
                            buildHelper.currentObject = currentClass[currentClass.Count - 1];
                        }
                        String[] tmpSplitByQuote = lines[i].Split("\"");
                        buildHelper.variableName = tmpSplitByQuote[1];

                        if( lines[i].Contains("{\"type\": "))
                        {
                            buildHelper.type = tmpSplitByQuote[5];
                            buildHelper.value = lines[i].Substring(lines[i].IndexOf(buildHelper.type) + buildHelper.type.Length + "\", \"value\": \"".Length).TrimEnd(new char[] { '"', '}' });

                        } else
                        {
                            String[] tmp = lines[i].Split("{ ")[1].TrimEnd(new char[] { ' ', '}' }).Split(", ");
                            buildHelper.childObject = new KeyValuePair<int, string>(int.Parse(tmp[0]), tmp[1]);
                            buildHelper.type = "REFERENCE";
                        }
                        objects.Add(buildHelper);
                    }
                } else
                {
                    BuildHelper buildHelper = new BuildHelper();

                    if(currentClass.Count != 0)
                    {
                        buildHelper.parentObject = currentClass[currentClass.Count - 1];
                    }

                    buildHelper.variableName = lines[i].Split("\"")[1];
                    buildHelper.type = "OBJECT";
                    String[] tmp = lines[i].Split("{ ")[1].Split(", ");
                    KeyValuePair<int, string> kp = new KeyValuePair<int, string>(int.Parse(tmp[0]), tmp[1]);
                    buildHelper.currentObject = kp;

                    currentClass.Add(kp);
                    objects.Add(buildHelper);
                }
            }

            //fill SerializationInfo with null references
            Dictionary<int, SerializationInfo> objectList = new Dictionary<int, SerializationInfo>();
            foreach (BuildHelper bh in objects)
            {
                if(bh.type == "OBJECT")
                {
                    SerializationInfo serializationInfo = new SerializationInfo(Binder.BindToType("ModelClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", bh.currentObject.Value), new FormatterConverter());
                    objectList.Add(bh.currentObject.Key, serializationInfo);
                    if( !bh.variableName.Equals("") )
                    {
                        objectList.TryGetValue(bh.parentObject.Key, out SerializationInfo parentSerializationInfo);
                        parentSerializationInfo.AddValue(bh.variableName, null);
                    }
                } else if (bh.variableName.Equals(""))
                {
                    SerializationInfo serializationInfo = new SerializationInfo(Binder.BindToType("", bh.type), new FormatterConverter());
                    objectList.Add(1, serializationInfo);
                }
                else
                {
                    objectList.TryGetValue(bh.currentObject.Key, out SerializationInfo serializationInfo);
                    serializationInfo.AddValue(bh.variableName, bh.value);
                }
            }

            //serialize objects with null references
            Dictionary<int, object> deserializedObjectList = new Dictionary<int, object>();
            foreach (KeyValuePair<int, SerializationInfo> x in objectList)
            {
                object o = Activator.CreateInstance(x.Value.ObjectType, x.Value, Context);
                deserializedObjectList.Add(x.Key, o);
            }

            //add references to serialized objects
            foreach (BuildHelper bh in objects)
            {
                if (bh.type == "OBJECT" && !bh.variableName.Equals(""))
                {
                    object o = deserializedObjectList[bh.parentObject.Key];
                    foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                    {
                        if (propertyInfo.Name.ToLower().Equals(bh.variableName.ToLower()))
                        {
                            propertyInfo.SetValue(o, deserializedObjectList[bh.currentObject.Key]);
                        }
                    }
                }
                if (bh.type == "REFERENCE")
                {
                    object o = deserializedObjectList[bh.currentObject.Key];
                    foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
                    {
                        if (propertyInfo.Name.ToLower().Equals(bh.variableName.ToLower()))
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
            if (obj is string)
            {
                WriteString((string)obj, name);
                return;
            }
            else
            {
                if (obj is ISerializable serializable)
                {
                    Binder.BindToName(obj.GetType(), out string assemblyInfo, out string typeName);
                    StringBuilder.Append("\"" + name + "\": " + "{ " + m_idGenerator.GetId(obj, out bool firstTime) + ", " + typeName);

                    if (firstTime)
                    {
                        StringBuilder.Append("\n");
                        SerializationInfo serializationInfo = new SerializationInfo(serializable.GetType(), new FormatterConverter());
                        serializable.GetObjectData(serializationInfo, Context);
                        foreach (SerializationEntry serializationEntry in serializationInfo)
                        {
                            WriteMember(serializationEntry.Name, serializationEntry.Value);
                        }
                        StringBuilder.Append("}\n");
                    } else
                    {
                        StringBuilder.Append(" }\n");
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
            StringBuilder.Append("\"" + name + "\": {\"type\": \"" + val.GetType().FullName + "\", \"value\": \"" + val + "\"}\n");
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
            StringBuilder.Append("\"" + name + "\": {\"type\": \"" + val.GetType().FullName + "\", \"value\": \"" + val + "\"}\n");
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            StringBuilder.Append("\"" + name + "\": {\"type\": \"" + val.GetType().FullName + "\", \"value\": \"" + val + "\"}\n");
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

        protected void WriteString(String text, string name)
        {
            StringBuilder.Append("\"" + name + "\": {\"type\": \"" + text.GetType().FullName + "\", \"value\": \"" + text + "\"}\n");
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
