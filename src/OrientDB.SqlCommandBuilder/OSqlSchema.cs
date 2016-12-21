﻿using System.Collections.Generic;
using System.Linq;
using OrientDB.SqlCommandBuilder.Protocol;
using OrientDB.SqlCommandBuilder.Protocol.Operations;
using OrientDB.SqlCommandBuilder.Protocol.Operations.Command;

namespace OrientDB.SqlCommandBuilder
{
    public class OSqlSchema
    {
        private string query = "select expand(classes) from metadata:schema";
        private IEnumerable<ODocument> _schema;

        internal OSqlSchema()
        {
           
        }

        public IEnumerable<string> Classes()
        {
            return _schema.Select(d => d.GetField<string>("name"));
        }

        public IEnumerable<ODocument> Properties(string @class)
        {
            var pDocument = _schema.FirstOrDefault(d => d.GetField<string>("name") == @class);
            return pDocument != null ? pDocument.GetField<HashSet<ODocument>>("properties") : null;
        }

        public bool IsClassExist(string @class)
        {
            var pDocument = _schema.FirstOrDefault(d => d.GetField<string>("name") == @class);
            return (pDocument != null);
        }

        public bool IsClassExist<T>()
        {
            var @class = typeof(T).Name;
            return IsClassExist(@class);
        }

        public IEnumerable<ODocument> Properties<T>()
        {
            var @class = typeof(T).Name;
            return Properties(@class);
        }

        public short GetDefaultClusterForClass(string @class)
        {
            var pDocument = _schema.FirstOrDefault(d => d.GetField<string>("name") == @class);
            return pDocument != null ? (short)pDocument.GetField<int>("defaultClusterId") : (short)-1;
        }

        public short GetDefaultClusterForClass<T>()
        {
            var @class = typeof(T).Name;
            return GetDefaultClusterForClass(@class);
        }

        public IEnumerable<int> GetClustersForClass(string @class)
        {
            var pDocument = _schema.FirstOrDefault(d => d.GetField<string>("name") == @class);
            return pDocument != null ? pDocument.GetField<List<int>>("clusterIds") : null;
        }

        public IEnumerable<int> GetClustersForClass<T>()
        {
            var @class = typeof(T).Name;
            return GetClustersForClass(@class);
        }
    }
}
