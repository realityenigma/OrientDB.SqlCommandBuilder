﻿using OrientDB.Core.Exceptions;
using OrientDB.SqlCommandBuilder.Interfaces;
using OrientDB.SqlCommandBuilder.Protocol;

// syntax: 
// CREATE VERTEX [<class>] 
// [CLUSTER <cluster>] 
// [SET <field> = <expression>[,]*]

namespace OrientDB.SqlCommandBuilder
{
    public class OSqlCreateVertex : IOCreateVertex
    {
        private SqlQuery _sqlQuery;

        public OSqlCreateVertex()
        {
            _sqlQuery = new SqlQuery();
        }

        #region Vertex

        public IOCreateVertex Vertex(string className)
        {
            _sqlQuery.Vertex(className);

            return this;
        }

        public IOCreateVertex Vertex<T>(T obj)
        {
            ODocument document;

            if (obj is ODocument)
            {
                document = obj as ODocument;
            }
            else
            {
                document = ODocument.ToDocument(obj);
            }

            if (string.IsNullOrEmpty(document.OClassName))
            {
                throw new OrientDBException(OrientDBExceptionType.Query, "Document doesn't contain OClassName value.");
            }

            _sqlQuery.Vertex(document.OClassName);
            _sqlQuery.Set(document);

            return this;
        }

        public IOCreateVertex Vertex<T>()
        {
            return Vertex(typeof(T).Name);
        }

        #endregion

        #region Cluster

        public IOCreateVertex Cluster(string clusterName)
        {
            _sqlQuery.Cluster(clusterName);

            return this;
        }

        public IOCreateVertex Cluster<T>()
        {
            return Cluster(typeof(T).Name);
        }

        #endregion

        #region Set

        public IOCreateVertex Set<T>(string fieldName, T fieldValue)
        {
            _sqlQuery.Set<T>(fieldName, fieldValue);

            return this;
        }

        public IOCreateVertex Set<T>(T obj)
        {
            _sqlQuery.Set(obj);

            return this;
        }

        #endregion

        public override string ToString()
        {
            return _sqlQuery.ToString(QueryType.CreateVertex);
        }
    }
}
