using System.Data.Common;

namespace AbstactFactory
{
   public abstract class DbParameterFactory
   {
       public abstract DbParameter CreateDbParameter(string parameterName, object value);
   }
}
