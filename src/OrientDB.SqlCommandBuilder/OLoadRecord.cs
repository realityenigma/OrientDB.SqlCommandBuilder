using OrientDB.Core;
using OrientDB.Core.Models;

namespace OrientDB.SqlCommandBuilder
{
    public class OLoadRecord
    {
        private ORID _orid;
        private string _fetchPlan = string.Empty;

        internal OLoadRecord()
        {
            
        }

        public OLoadRecord ORID(ORID orid)
        {
            _orid = orid;
            return this;
        }

        public OLoadRecord FetchPlan(string plan)
        {
            _fetchPlan = plan;
            return this;
        }
    }
}
