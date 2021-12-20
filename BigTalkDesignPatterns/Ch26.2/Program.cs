using System;
using System.Collections;

namespace Ch26._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //尽管给4个不同用户使用网站，但实际上只有两个网站实例。
            WebSiteFactory f = new WebSiteFactory();
            WebSite fx = f.GetWebSiteCategory("产品展示");
            fx.Use(new User("小蔡"));
            WebSite fy = f.GetWebSiteCategory("博客");
            fy.Use(new User("大鸟"));
            WebSite fz = f.GetWebSiteCategory("产品展示");
            fz.Use(new User("老顽童"));
            WebSite fi = f.GetWebSiteCategory("产品展示");
            fi.Use(new User("乔峰"));
            Console.WriteLine($"网站分类总数为：{f.GetWebSiteCont()}");
            Console.ReadKey();
        }
    }
    public class User
    {
        public string Name { get; }
        public User(string name)
        {
            Name = name;
        }
    }
    //网站抽象
    abstract class WebSite
    {
        public abstract void Use(User user);//传递用户对象
    }
    //具体网站
    class ConcreteWebSite:WebSite
    {
        private string name = "";
        public ConcreteWebSite(string name)
        {
            this.name = name;
        }
        public override void Use(User user)
        {
            Console.WriteLine($"网站分类{name}，用户：{user.Name}");
        }
    }
    //网站工厂
    class WebSiteFactory
    {
        private Hashtable flyweights = new Hashtable();
        //获得网站分类
        public WebSite GetWebSiteCategory(string key)
        {
            if(!flyweights.ContainsKey(key))
                flyweights.Add(key,new ConcreteWebSite(key));
            return (WebSite)flyweights[key];
        }
        //获得网站分类总数
        public int GetWebSiteCont()
        {
            return flyweights.Count;
        }
    }
}
