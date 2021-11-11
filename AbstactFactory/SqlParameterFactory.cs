using System.Data.Common;
using System.Data.SqlClient;

namespace AbstactFactory
{
    class SqlParameterFactory:DbParameterFactory
    {
        public override DbParameter CreateDbParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }
    }
}
