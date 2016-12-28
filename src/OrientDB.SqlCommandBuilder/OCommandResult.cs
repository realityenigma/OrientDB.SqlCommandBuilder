using OrientDB.Core.Models;
using OrientDB.SqlCommandBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrientDB.SqlCommandBuilder
{
    public class OCommandResult
    {
        private OrientDBEntity _document;

        internal OCommandResult(OrientDBEntity document)
        {
            _document = document;
        }

        public int GetModifiedCount()
        {
            switch (_document.GetField<PayloadStatus>("PayloadStatus"))
            {
                case PayloadStatus.SingleRecord:
                    return 1;
                case PayloadStatus.RecordCollection:
                    return _document.GetField<List<ODocument>>("Content").Count;
                case PayloadStatus.SerializedResult:
                    return Convert.ToInt32(_document.GetField<object>("Content"));
            }

            return 0;
        }

        public OrientDBEntity ToSingle()
        {
            DictionaryOrientDBEntity document = null;

            switch (_document.GetField<PayloadStatus>("PayloadStatus"))
            {
                case PayloadStatus.SingleRecord:
                    document = _document.GetField<IDictionary<string, object>>("Content");
                    break;
                case PayloadStatus.RecordCollection:
                    document = _document.GetField<List<ODocument>>("Content").FirstOrDefault();
                    break;
                case PayloadStatus.SerializedResult:
                    document = new ODocument();
                    document.SetField<object>("value",_document.GetField<object>("Content"));
                    break;
                default:
                    break;
            }

            return document;
        }

        public List<OrientDBEntity> ToList()
        {
            return _document.GetField<List<IDictionary<string, object>>("Content");
        }

        public OrientDBEntity ToDocument()
        {
            return _document;
        }
    }
}
