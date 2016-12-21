using OrientDB.Core.Models;
using OrientDB.SqlCommandBuilder.Interfaces;
using OrientDB.SqlCommandBuilder.Protocol;
using OrientDB.SqlCommandBuilder.Protocol.Operations;
using OrientDB.SqlCommandBuilder.Protocol.Operations.Command;

// syntax:
// CREATE CLUSTER <name> <type> 
// [DATASEGMENT <data-segment>|default] 
// [LOCATION <path>|default] 
// [POSITION <position>|append]

namespace OrientDB.SqlCommandBuilder
{
    public class OSqlCreateCluster : IOCreateCluster
    {
        private SqlQuery _sqlQuery;
        private Connection _connection;

        public OSqlCreateCluster()
        {
            _sqlQuery = new SqlQuery(null);
        }
        internal OSqlCreateCluster(Connection connection)
        {
            _connection = connection;
            _sqlQuery = new SqlQuery(connection);
        }

        #region Cluster
    
        public IOCreateCluster Cluster(string clusterName, ClusterType clusterType)
        {
            _sqlQuery.Cluster(clusterName, clusterType);

            return this;
        }

        public IOCreateCluster Cluster<T>(ClusterType clusterType)
        {
            return Cluster(typeof(T).Name, clusterType);
        }

        #endregion
               

        public override string ToString()
        {
            return _sqlQuery.ToString(QueryType.CreateCluster);
        }
    }
}
