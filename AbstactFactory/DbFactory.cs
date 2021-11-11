using System.Data.Common;

namespace AbstactFactory
{
  public abstract  class DbFactory//将连接和参数组合起来成一个类,保证类之间相互依赖，类的数量相对减少
    {
        public abstract DbConnection CreateDbConnection();
        public abstract DbParameter CreateDbParameter(string parameterName, object value);
    }
}
