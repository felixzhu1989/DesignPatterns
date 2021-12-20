using System;

namespace Ch21._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1=Singleton.GetInstance();
            Singleton s2=Singleton.GetInstance();
            if (s1 == s2)
            {
                Console.WriteLine("两个对象是相同的实例");
            }
            Console.ReadKey();
        }
    }
    /*
     //懒汉式
    class Singleton
    {
        private static Singleton instance;
        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();
        private Singleton(){}

        public static Singleton GetInstance()
        {
            //先判断实例是否存在，不存在再加锁（双锁）
            if (instance == null)
            {
                //在同一时刻加了锁的那部分程序只有一个线程可以进入
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
    */
    //饿汉式，阻止发生派生
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton GetInstance()
        {
            return instance;
        }
    }
}
