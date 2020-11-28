using System;
using System.IO;
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
            StringBuilder = new StringBuilder();
            Binder = new MySerializerBinder();
            Context = new StreamingContext();
        }
        public override object Deserialize(Stream serializationStream)
        {
            byte[] bytes = new byte[serializationStream.Length];
            serializationStream.Read(bytes);
            String text = Encoding.UTF8.GetString(bytes);

            return null;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
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
                    StringBuilder.Append("\"" + name + "\": " + "{\"id\": \"" + m_idGenerator.GetId(obj, out bool firstTime) + "\", ");
                    StringBuilder.Append("\"typeName\": \"" + typeName + "\"},\n");

                    if (firstTime)
                    {
                        SerializationInfo serializationInfo = new SerializationInfo(serializable.GetType(), new FormatterConverter());
                        serializable.GetObjectData(serializationInfo, Context);
                        foreach (SerializationEntry serializationEntry in serializationInfo)
                        {
                            WriteMember(serializationEntry.Name, serializationEntry.Value);
                        }
                    }
                    StringBuilder.Append("}\n");
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
            StringBuilder.Append("\"" + name + "\": {\"value\": \"" + val + "\", \"type\": \"" + val.GetType().FullName + "\"}, \n");
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
            StringBuilder.Append("\"" + name + "\": {\"value\": \"" + val + "\", \"type\": \"" + val.GetType().FullName + "\"}, \n");
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            StringBuilder.Append("\"" + name + "\": {\"value\": \"" + val + "\", \"type\": \"" + val.GetType().FullName + "\"}, \n");
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
            StringBuilder.Append("\"" + name + "\": {\"value\": \"" + text + "\", \"type\": \"" + text.GetType().FullName + "\"}, \n");
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
