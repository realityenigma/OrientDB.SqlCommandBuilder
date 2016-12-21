using OrientDB.Core.Models;
using OrientDB.SqlCommandBuilder.Interfaces;

namespace OrientDB.SqlCommandBuilder
{
    public class ODataClasterAdd : IOCreateCluster
    {
        public string ClusterName { get; set; }
        public ClusterType ClusterType { get; set; }

        public ODataClasterAdd()
        {

        }

        public IOCreateCluster Cluster(string clusterName, ClusterType clusterType)
        {
            ClusterName = clusterName;
            ClusterType = clusterType;
            return this;
        }

        public IOCreateCluster Cluster<T>(ClusterType clusterType)
        {
            return Cluster(typeof(T).Name, clusterType);
        }
    }
}
