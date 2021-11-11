
using System.Data.Common;

namespace AbstactFactory
{
    #region 工厂方法，对简单工厂的改进，面向抽象编程，抽象类
    public abstract class DbConnectionFactory
    {
        public abstract DbConnection CreateDbConnection();
    } 
    #endregion


}
