using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Bank.Utilities
{
    public class XmlWorker<T> : ISerializer<T>
    {
        XmlSerializer xs = null;
        public XmlWorker()
        {
            this.xs = new XmlSerializer(typeof(T));
        }
        public string Serialize(T entity)
        {
            return Encoding.UTF8.GetString(this.Serialize2Bytes(entity));
        }

        public byte[] Serialize2Bytes(T entity)
        {
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(new MemoryStream(), Encoding.UTF8))
            {
                //Serailize entity in the xmlTextWriter
                this.xs.Serialize(xmlTextWriter, entity);
                xmlTextWriter.Flush();
                return ((MemoryStream)xmlTextWriter.BaseStream).ToArray();
            }
        }

        public T Deserialize(string serialized)
        {
            return this.Deserialize(Encoding.UTF8.GetBytes(serialized));
        }

        public T Deserialize(byte[] serialized)
        {
            using (MemoryStream ms = new MemoryStream(serialized))
            {
                return (T)this.xs.Deserialize(ms);
            }
        }
    }
}
