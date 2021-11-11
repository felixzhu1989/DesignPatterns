using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //泛型基类
   public class SingletonBase<T> where T:class
   {
       private static readonly Lazy<T> _instance = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T),true));//通过反射的方式创建
       protected SingletonBase() { }
        public static T Instance
        {
            get { return _instance.Value; }
        }
   }
}
