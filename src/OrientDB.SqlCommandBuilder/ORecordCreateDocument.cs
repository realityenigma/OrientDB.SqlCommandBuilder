using System;
using System.Collections.Generic;
using OrientDB.SqlCommandBuilder.Interfaces;

namespace OrientDB.SqlCommandBuilder
{
    public class ORecordCreateDocument : IOCreateDocument
    {
        private IDictionary<string, object> _document;

        public ORecordCreateDocument()
        {
        }

        internal ORecordCreateDocument()
        {
            _document = new Dictionary<string, object>();
        }

        public IOCreateDocument Cluster(string clusterName)
        {
            throw new NotImplementedException();
        }

        public IOCreateDocument Cluster<T>()
        {
            throw new NotImplementedException();
        }

        public IOCreateDocument Document(string className)
        {
            _document.OClassName = className;
            return this;
        }

        public IOCreateDocument Document<T>()
        {
            return Document(typeof(T).Name);
        }

        public IOCreateDocument Document<T>(T obj)
        {
            if (obj is IDictionary<string, object>)
            {
                _document = obj as IDictionary<string, object>;
            }
            else
            {
                _document = IDictionary<string, object>.ToDocument(obj);
            }
            return this;
        }

        public IOCreateDocument Set<T>(string fieldName, T fieldValue)
        {
            _document.SetField<T>(fieldName, fieldValue);

            return this;
        }

        public IOCreateDocument Set<T>(T obj)
        {
            if (obj is IDictionary<string, object>)
            {
                _document = obj as IDictionary<string, object>;
            }
            else
            {
                _document = IDictionary<string, object>.ToDocument(obj);
            }

            return this;
        }
    }
}
