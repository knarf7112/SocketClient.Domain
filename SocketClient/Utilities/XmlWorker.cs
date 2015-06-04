using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SocketService.Utilities
{   
    public class XmlWorker<T> : ISerializer<T>
    {
        XmlSerializer xs = null;
        public XmlWorker()
        {
            this.xs = new XmlSerializer(typeof(T));
        }

        public T Deserialize( string serialized )
        {
            return this.Deserialize(Encoding.UTF8.GetBytes(serialized));        
        }

        public T Deserialize(byte[] serialized)
        {
            using (MemoryStream memoryStream = new MemoryStream(serialized))
            {               
                return (T)this.xs.Deserialize(memoryStream);
            }
        }

        public byte[] Serialize2Bytes(T entity)
        {
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(new MemoryStream(), Encoding.UTF8))
            {
                //Serialize entity in the xmlTextWriter
                this.xs.Serialize(xmlTextWriter, entity);
                xmlTextWriter.Flush();
                return ((MemoryStream)(xmlTextWriter.BaseStream)).ToArray();
            }   
        }

        public String Serialize(T entity)
        {
            return Encoding.UTF8.GetString(this.Serialize2Bytes(entity));
        }
    }
}