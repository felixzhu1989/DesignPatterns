using System;

namespace DesignPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphics g = new Graphics(new Rectangle());
            g.Stroke();//里氏替换原则，子类可以赋值给基类（父类）
            g.Fill();
            g.SetShape(new Circle());
            g.Stroke();
            g.Fill();

            Console.ReadKey();
        }
    }
}
