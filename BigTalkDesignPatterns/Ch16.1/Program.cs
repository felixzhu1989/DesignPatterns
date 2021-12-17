using System;

namespace Ch16._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //紧急项目
            Work emergencyProjects = new Work();
            emergencyProjects.Hour = 9;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 10;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 12;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 14;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 17;
            emergencyProjects.TaskFinished = false;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 19;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 22;
            emergencyProjects.WriteProgram();
            Console.ReadKey();
        }
    }
    //面向对象设计其实就是希望做到代码的责任分解。这个类违背了‘单一职责原则’。
    class Work
    {
        public int Hour { get; set; }
        public bool TaskFinished { get; set; }
        //Long Method方法过长是坏味道
        public void WriteProgram()
        {
            if (Hour < 12)
            {
                Console.WriteLine($"当前时间{Hour}，上午工作，精神百倍");
            }
            else if (Hour < 13)
            {
                Console.WriteLine($"当前时间{Hour}，饿了，午饭；犯困，午休");
            }
            else if (Hour < 17)
            {
                Console.WriteLine($"当前时间{Hour}，下午状态还不错，继续努力");
            }
            else
            {
                if (TaskFinished)
                {
                    Console.WriteLine($"当前时间{Hour}，下班回家了");
                }
                else
                {
                    if (Hour < 21)
                    {
                        Console.WriteLine($"当前时间{Hour}，加班哦，疲惫至极");
                    }
                    else
                    {
                        Console.WriteLine($"当前时间{Hour}，不行了，睡着了");
                    }
                }
            }
        }
    }
}
