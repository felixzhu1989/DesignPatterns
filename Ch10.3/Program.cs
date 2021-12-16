using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("学生甲抄写的试卷");
            TestPaper studentA = new TestPaperA();
            studentA.TestQuestion1();
            studentA.TestQuestion2();
            studentA.TestQuestion3();
            Console.WriteLine("学生乙抄写的试卷");
            TestPaper studentB = new TestPaperB();
            studentB.TestQuestion1();
            studentB.TestQuestion2();
            studentB.TestQuestion3();
        }
    }
    class TestPaper
    {
        public void TestQuestion1()
        {
            Console.WriteLine("Question1:xxxx");
            Console.WriteLine($"Answer:{Answer1()}");
            //将只有这个变化的地方,可以提取变化封装成方法
        }
        public void TestQuestion2()
        {
            Console.WriteLine("Question1:yyyy");
            Console.WriteLine($"Answer:{Answer2()}");
        }
        public void TestQuestion3()
        {
            Console.WriteLine("Question1:zzzz");
            Console.WriteLine($"Answer:{Answer3()}");
        }

        protected virtual string Answer1()
        {
            return "";//默认交了白卷
        }
        protected virtual string Answer2()
        {
            return "";
        }
        protected virtual string Answer3()
        {
            return "";
        }
    }
    //学生甲抄写的试卷
    class TestPaperA : TestPaper
    {
        protected override string Answer1()
        {
            return "ax";
        }
        protected override string Answer2()
        {
            return "ay";
        }
        protected override string Answer3()
        {
            return "az";
        }
    }
    //学生甲抄写的试卷
    class TestPaperB : TestPaper
    {
        protected override string Answer1()
        {
            return "bx";
        }
        protected override string Answer2()
        {
            return "by";
        }
        protected override string Answer3()
        {
            return "bz";
        }
    }
}
