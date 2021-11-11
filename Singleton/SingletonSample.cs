using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    #region 实现方式1，静态类，静态方法
    //public static class SingletonSample
    //{
    //    private static int _counter = 0;
    //    public static int IncreaseCount()
    //    {
    //        return ++_counter;
    //    }
    //} 
    #endregion

    #region 实现方式2：私有构造函数，公开静态属性中的get方法创建实例
    //public class SingletonSample
    //{
    //    private static readonly SingletonSample _instance = new SingletonSample();//私有字段
    //    private int _counter = 0;
    //    private SingletonSample() { }//私有化构造方法，外部不能随意创建实例
    //    public static SingletonSample Instance//公开静态属性，创建实例
    //    {
    //        get { return _instance; }//只能get，不能随便设值更改实例
    //    }
    //    public int IncreaseCount()
    //    {
    //        return ++_counter;
    //    }
    //} 
    #endregion

    #region 实现方式3：改进静态属性
    //public class SingletonSample
    //{
    //    private static SingletonSample _instance;//私有字段,不赋值
    //    private int _counter = 0;
    //    private SingletonSample() { }
    //    public static SingletonSample Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = new SingletonSample();//线判断是否为空再创建
    //            }
    //            return _instance;
    //        }
    //    }

    //    public int IncreaseCount()
    //    {
    //        return ++_counter;
    //    }
    //}
    #endregion

    #region 实现方式4：加锁
    //public class SingletonSample
    //{
    //    private static SingletonSample _instance;
    //    private static readonly object _locker = new object();//加锁
    //    private int _counter = 0;
    //    private SingletonSample() { }
    //    public static SingletonSample Instance
    //    {
    //        get
    //        {
    //            lock (_locker)//所有的请求都通过锁挡在外面排队进来
    //            {
    //                if (_instance == null)
    //                {
    //                    _instance = new SingletonSample();
    //                }
    //                return _instance;
    //            }
    //        }
    //    }
    //    public int IncreaseCount()
    //    {
    //        return ++_counter;
    //    }
    //}
    #endregion

    #region 实现方式5：双锁
    //public class SingletonSample
    //{
    //    private static volatile SingletonSample _instance;//volatile,标识这个字段让系统不做优化，按照正常顺序处理
    //    private static readonly object _locker = new object();//加锁
    //    private int _counter = 0;
    //    private SingletonSample() { }
    //    public static SingletonSample Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)//先判断再加锁
    //            {
    //                lock (_locker)
    //                {
    //                    if (_instance == null)
    //                    {
    //                        _instance = new SingletonSample();
    //                    }
    //                }
    //            }
    //            return _instance;
    //        }
    //    }
    //    public int IncreaseCount()
    //    {
    //        return ++_counter;
    //    }
    //}
    #endregion

    #region 实现方式6：Lazy懒加载，延时加载
    //public class SingletonSample
    //{
    //    private static readonly Lazy<SingletonSample> _instance = new Lazy<SingletonSample>(() => new SingletonSample());//懒加载
    //    private int _counter = 0;
    //    private SingletonSample() { }
    //    public static SingletonSample Instance
    //    {
    //        get { return _instance.Value; }
    //    }
    //    public int IncreaseCount()
    //    {
    //        return ++_counter;
    //    }
    //}

    #endregion

    #region 实现方式7：继承自单例泛型基类，封装了重复代码
    public class SingletonSample:SingletonBase<SingletonSample>
    {
        private int _counter = 0;
        private SingletonSample() { }
        public int IncreaseCount()
        {
            return ++_counter;
        }
    }
    #endregion
}
