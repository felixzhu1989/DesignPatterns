using System;
using System.Collections.Generic;

namespace Ch19._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //根节点，两个分叶
            Composite root = new Composite("root");
            root.Add(new Leaf("leaf a"));
            root.Add(new Leaf("leaf b"));
            //分支，下有两个分叶
            Composite comp = new Composite("comp x");
            comp.Add(new Leaf("leaf xa"));
            comp.Add(new Leaf("leaf xb"));
            //将分支附加到根节点下
            root.Add(comp);
            Composite comp2 = new Composite("comp xy");
            comp2.Add(new Leaf("leaf xya"));
            comp2.Add(new Leaf("leaf xyb"));
            comp.Add(comp2);
            root.Add(new Leaf("leaf c"));
            Leaf leaf = new Leaf("leaf d");
            root.Add(leaf);
            root.Remove(leaf);//没长牢固，被风吹走了
            root.Display(1);
            Console.ReadKey();
        }
    }
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        //增加和删除树叶或树枝的功能
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    class Leaf:Component
    {
        public Leaf(string name) : base(name)
        {
        }
        public override void Add(Component c)
        {
            //由于叶子没有再增加分支和树枝，因此实现增加和删除没有意义
            Console.WriteLine("Can not add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Can not remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-',depth)}{name}");
        }
    }
    class Composite : Component
    {
        //子对象集合，存储下属的支节点和叶节点
        private List<Component> children = new List<Component>();
        public Composite(string name) : base(name)
        {
        }
        public override void Add(Component c)
        {
            children.Add(c);
        }
        public override void Remove(Component c)
        {
            children.Remove(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-', depth)}{name}");
            foreach (Component c in children)
            {
                c.Display(depth+1);
            }
        }
    }
}
