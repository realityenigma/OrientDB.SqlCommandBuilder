namespace OrientDB.SqlCommandBuilder
{
    public class OSqlDeleteCluster
    {
        private Connection _connection;
        private short _clusterid;

        public OSqlDeleteCluster()
        {

        }

        internal OSqlDeleteCluster(Connection connection, short clusterid)
        {
            _connection = connection;
            _clusterid = clusterid;
        }
    }
}
