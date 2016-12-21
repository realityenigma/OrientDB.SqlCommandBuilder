using OrientDB.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrientDB.SqlCommandBuilder
{
    public class OClusterQuery
    {
        private List<Cluster> _clusterIds = new List<Cluster>();      

        internal OClusterQuery()
        {
            this._connection = _connection;
        }

        internal void AddClusterId(Cluster cluster)
        {
            if (!_clusterIds.Contains(cluster))
                _clusterIds.Add(cluster);
        }

        public long Count()
        {
            var operation = new DataClusterCount(_connection.Database);
            operation.Clusters = _clusterIds.Select(c => c.Id).ToList();
            var document = _connection.ExecuteOperation(operation);
            return document.GetField<long>("count");
        }
        public ODocument Range()
        {
            var document = new ODocument();
            foreach (var cluster in _clusterIds)
            {
                var operation = new DataClusterDataRange(_connection.Database);
                operation.ClusterId = cluster.Id;
                var d = _connection.ExecuteOperation(operation);
                if (!string.IsNullOrEmpty(cluster.Name))
                    document.SetField<ODocument>(cluster.Name, d.GetField<ODocument>("Content"));
                else
                    document.SetField<ODocument>(cluster.Id.ToString(), d.GetField<ODocument>("Content"));
            }
            return document;
        }
    }
}
