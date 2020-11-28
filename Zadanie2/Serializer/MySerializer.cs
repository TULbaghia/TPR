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
            throw new NotImplementedException();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if(graph is ISerializable serializable)
            {
                SerializationInfo serializationInfo = new SerializationInfo(serializable.GetType(), new FormatterConverter());

                WriteObjectRef(serializable, "", graph.GetType());

                serializable.GetObjectData(serializationInfo, Context);
                foreach (SerializationEntry serializationEntry in serializationInfo)
                {
                    WriteMember(serializationEntry.Name, serializationEntry.Value);
                }
                StringBuilder.Append("}");
                serializationStream.Write(Encoding.UTF8.GetBytes(StringBuilder.ToString()));
                serializationStream.Flush();
                StringBuilder.Clear();
            } else
            {
                throw new SerializationException("Object does not implement ISerializable");
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
            throw new NotImplementedException();
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

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (obj is String) {
                WriteString((String) obj, name);
                return;
            }
            Binder.BindToName(obj.GetType(), out string assemblyInfo, out string typeName);

            StringBuilder.Append("{\n" + "\"id\": \"" + m_idGenerator.GetId(obj, out bool firstTime) + "\", \n");
            StringBuilder.Append("\"typeName\": \"" + typeName + "\", \n");
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
