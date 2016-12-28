using OrientDB.Core.Models;
using System.Collections.Generic;

namespace OrientDB.SqlCommandBuilder.Models
{
    internal class DictionaryOrientDBEntity : OrientDBEntity
    {
        private IDictionary<string, object> _fields = new Dictionary<string, object>();

        public T GetField<T>(string key) where T : class
        {
            return _fields[key] as T;
        }

        public void SetField<T>(string key, T obj)
        {
            if (_fields.ContainsKey(key))
                _fields[key] = obj;
            else
                _fields.Add(key, obj);
        }

        public DictionaryOrientDBEntity()
        {

        }

        public override void Hydrate(IDictionary<string, object> data)
        {
            foreach(var key in data.Keys)
            {
                if (_fields.ContainsKey(key))
                    _fields[key] = data[key];
                else                
                    _fields.Add(key, data[key]);
                
            }
        }
    }
}
