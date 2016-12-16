using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrientDB.SqlCommandBuilder.Interfaces
{
    public interface IOCreateVertex
    {
        IOCreateVertex Vertex(string className);
        IOCreateVertex Vertex<T>(T obj);
        IOCreateVertex Vertex<T>();
        IOCreateVertex Cluster(string clusterName);
        IOCreateVertex Cluster<T>();
        IOCreateVertex Set<T>(string fieldName, T fieldValue);
        IOCreateVertex Set<T>(T obj);
        OVertex Run();
        T Run<T>() where T : class, new();
        string ToString();
    }
}
