using System.Collections.Generic;
using System.Linq;
using OrientDB.SqlCommandBuilder.Interfaces;
using OrientDB.Core;

namespace OrientDB.SqlCommandBuilder
{
    class ORecordCreateEdge : IOCreateEdge
    {
        private IDictionary<string, object> _document;
        private ORID _source;
        private ORID _dest;
        private string _edgeName;

        public ORecordCreateEdge()
        {
        }

        internal ORecordCreateEdge()
        {
        }

        #region Edge

        public IOCreateEdge Edge(string className)
        {
            _edgeName = className;

            return this;
        }

        public IOCreateEdge Edge<T>(T obj)
        {

            if (obj is ODocument)
            {
                _document = obj as ODocument;
            }
            else
            {
                _document = ODocument.ToDocument(obj);
            }

            if (string.IsNullOrEmpty(_document.OClassName))
            {
                throw new OException(OExceptionType.Query, "Document doesn't contain OClassName value.");
            }

            return this;
        }

        public IOCreateEdge Edge<T>()
        {
            return Edge(typeof(T).Name);
        }

        #endregion

        #region Cluster

        public IOCreateEdge Cluster(string clusterName)
        {
            if (_document.ORID == null)
                _document.ORID = new ORID();

            _document.ORID.ClusterId = _connection.Database.GetClusters().First(x => x.Name == clusterName).Id;

            return this;
        }

        public IOCreateEdge Cluster<T>()
        {
            return Cluster(typeof(T).Name);
        }

        #endregion

        #region Set

        public IOCreateEdge Set<T>(string fieldName, T fieldValue)
        {
            if (_document == null)
                _document = new ODocument();
            _document.SetField(fieldName, fieldValue);

            return this;
        }

        public IOCreateEdge Set<T>(T obj)
        {
            var document = obj is ODocument ? obj as ODocument : ODocument.ToDocument(obj);

            // TODO: go also through embedded fields
            foreach (KeyValuePair<string, object> field in document)
            {
                // set only fields which doesn't start with @ character
                if ((field.Key.Length > 0) && (field.Key[0] != '@'))
                {
                    Set(field.Key, field.Value);
                }
            }

            return this;
        }

        #endregion

        public IOCreateEdge From(ORID orid)
        {
            _source = orid;
            return this;
        }

        public IOCreateEdge From<T>(T obj)
        {
            _source = ToODocument(obj).ORID;
            return this;

        }

        public IOCreateEdge To(ORID orid)
        {
            _dest = orid;
            return this;
        }

        public IOCreateEdge To<T>(T obj)
        {
            _dest = ToODocument(obj).ORID;
            return this;
        }

        private static IDictionary<string, object> ToODocument<T>(T obj)
        {
            IDictionary<string, object> document;

            if (obj is IDictionary<string, object>)
            {
                document = obj as IDictionary<string, object>;
            }
            else
            {
                document = ODocument.ToDocument(obj);
            }

            if (document.ORID == null)
            {
                throw new OException(OExceptionType.Query, "Document doesn't contain ORID value.");
            }
            return document;
        }
    }
}
