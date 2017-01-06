using OrientDB.Core;
using OrientDB.Core.Models;

namespace OrientDB.SqlCommandBuilder
{
    public class ORecordMetadata
    {
        private ORID _orid;

        internal ORecordMetadata()
        {
            
        }

        public ORecordMetadata ORID(ORID orid)
        {
            _orid = orid;
            return this;
        }
    }
}
