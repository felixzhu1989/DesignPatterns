using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10._2
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
        }
        public void TestQuestion2()
        {
            Console.WriteLine("Question1:yyyy");
        }
        public void TestQuestion3()
        {
            Console.WriteLine("Question1:zzzz");
        }
    }
    //学生甲抄写的试卷
    class TestPaperA:TestPaper
    {
        public new void TestQuestion1()
        {
            base.TestQuestion1();
            Console.WriteLine("Answer:ax");
        }
        public new void TestQuestion2()
        {
            base.TestQuestion3();
            Console.WriteLine("Answer:ay");
        }
        public new void TestQuestion3()
        {
            base.TestQuestion3();
            Console.WriteLine("Answer:az");
        }
    }
    //学生乙抄写的试卷，还是有很多重复代码
    class TestPaperB:TestPaper
    {
        public new void TestQuestion1()
        {
            base.TestQuestion1();
            Console.WriteLine("Answer:bx");
        }
        public new void TestQuestion2()
        {
            base.TestQuestion2();
            Console.WriteLine("Answer:by");
        }
        public new void TestQuestion3()
        {
            base.TestQuestion3();
            Console.WriteLine("Answer:bz");
        }
    }
}
