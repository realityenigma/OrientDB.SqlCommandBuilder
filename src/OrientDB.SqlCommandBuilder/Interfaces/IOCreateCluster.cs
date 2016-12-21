using OrientDB.Core.Models;

namespace OrientDB.SqlCommandBuilder.Interfaces
{
    public interface IOCreateCluster
    {
        IOCreateCluster Cluster(string clusterName, ClusterType clusterType);
        IOCreateCluster Cluster<T>(ClusterType clusterType);   
        string ToString();
    }
}
