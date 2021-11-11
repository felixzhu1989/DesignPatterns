using System;

namespace DesignPrinciple
{
    public class Graphics
    {
        //依赖倒置原则：高层模块（调用者）不应该依赖于低层模块（被调用者），二者都应该依赖于抽象（继承是一种依赖，调用也是一种依赖，就是调用基类）。
        private Shape _shape;//字段,迪米特原则

        public Graphics(Shape shape)//构造函数，将形状传参给字段
        {
            this._shape = shape;
        }

        public void SetShape(Shape shape)//随时替换字段中的形状
        {
            this._shape = shape;
        }
        public void Stroke()//单一职责原则，只负责描边，不管是什么形状
        {
            string path = _shape.GetPath();
            Console.WriteLine($"描边{path}");
        }
        public void Fill()//只负责填充，不管是什么形状
        {
            string path = _shape.GetPath();
            Console.WriteLine($"填充{path}");
        }
    }
}
