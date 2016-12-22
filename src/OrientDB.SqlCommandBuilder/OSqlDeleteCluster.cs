namespace OrientDB.SqlCommandBuilder
{
    public class OSqlDeleteCluster
    {
        private short _clusterid;

        public OSqlDeleteCluster()
        {

        }

        internal OSqlDeleteCluster(short clusterid)
        {
            _clusterid = clusterid;
        }
    }
}
