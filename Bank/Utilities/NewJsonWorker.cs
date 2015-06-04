//
using Newtonsoft.Json;
using System.Text;
namespace Bank.Utilities
{
    public class NewJsonWorker<T> : ISerializer<T>
    {
        public string Serialize(T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        public byte[] Serialize2Bytes(T entity)
        {
            return Encoding.UTF8.GetBytes(this.Serialize(entity));
        }

        public T Deserialize(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public T Deserialize(byte[] serialized)
        {
           return this.Deserialize(Encoding.UTF8.GetString(serialized));
        }
    }
}
