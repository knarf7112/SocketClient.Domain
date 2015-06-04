using System.Text;
//using System.IO;
//using System.Runtime.Serialization.Json;
//using System.Reflection;
using Newtonsoft.Json;

namespace SocketService.Utilities
{   
    public class JsonWorker<T> : ISerializer<T>
    {
        //DataContractJsonSerializer serializer = null;

        public JsonWorker()
        {
            //this.serializer = new DataContractJsonSerializer(typeof(T));
        }

        public byte[] Serialize2Bytes( T entity )
        {
            return Encoding.UTF8.GetBytes(this.Serialize(entity));
        }

        public string Serialize(T entity)
        {
            return JsonConvert.SerializeObject( entity );
        }

        public T Deserialize(byte[] serialized)
        {
            return this.Deserialize(Encoding.UTF8.GetString(serialized));
        }


        public T Deserialize( string serialized )
        {
            return JsonConvert.DeserializeObject<T>(serialized);        
        }
    }
}
