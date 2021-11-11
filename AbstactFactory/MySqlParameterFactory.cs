using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AbstactFactory
{
    class MySqlParameterFactory:DbParameterFactory
    {
        public override DbParameter CreateDbParameter(string parameterName, object value)
        {
            return new MySqlParameter(parameterName,value);
        }
    }
}
