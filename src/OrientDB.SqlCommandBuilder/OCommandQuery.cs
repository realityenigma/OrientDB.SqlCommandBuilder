using System.Collections.Generic;

namespace OrientDB.SqlCommandBuilder
{
    public class OCommandQuery
    {
        private CommandPayloadBase _payload;
        private Dictionary<string, object> _simpleParams;

        internal OCommandQuery(CommandPayloadBase payload)
        {
            _payload = payload;
        }

        public OCommandQuery Set(string parameter, object value)
        {
            if (!(_payload is CommandPayloadCommand))
                throw new OException(OExceptionType.Query, "A command not support simple parameters");

            if (_simpleParams == null)
                _simpleParams = new Dictionary<string, object>();

            _simpleParams.Add(parameter, value);

            return this;
        }
    }
}
