using OrientDB.Core.Models;
using OrientDB.SqlCommandBuilder.Interfaces;
using OrientDB.SqlCommandBuilder.Protocol;

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

        public OSqlCreateCluster()
        {
            _sqlQuery = new SqlQuery();
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
