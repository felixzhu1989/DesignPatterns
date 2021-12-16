using System;

namespace Ch10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("学生甲抄写的试卷");
            TestPaperA studentA = new TestPaperA();
            studentA.TestQuestion1();
            studentA.TestQuestion2();
            studentA.TestQuestion3();
            Console.WriteLine("学生乙抄写的试卷");
            TestPaperB studentB = new TestPaperB();
            studentB.TestQuestion1();
            studentB.TestQuestion2();
            studentB.TestQuestion3();
        }
    }
    //学生甲抄写的试卷
    class TestPaperA
    {
        public void TestQuestion1()
        {
            Console.WriteLine("Question1:xxxx");
            Console.WriteLine("Answer:ax");//不同的学生会有不同的结果
        }
        public void TestQuestion2()
        {
            Console.WriteLine("Question1:yyyy");
            Console.WriteLine("Answer:ay");
        }
        public void TestQuestion3()
        {
            Console.WriteLine("Question1:zzzz");
            Console.WriteLine("Answer:az");
        }
    }
    //学生乙抄写的试卷，大量的重复代码
    //如果老师突然要改题目，那两个人就都需要改代码，如果某人抄错了，那真是糟糕之极。
    class TestPaperB
    {
        public void TestQuestion1()
        {
            Console.WriteLine("Question1:xxxx");
            Console.WriteLine("Answer:bx");
        }
        public void TestQuestion2()
        {
            Console.WriteLine("Question1:yyyy");
            Console.WriteLine("Answer:by");
        }
        public void TestQuestion3()
        {
            Console.WriteLine("Question1:zzzz");
            Console.WriteLine("Answer:bz");
        }
    }
}
