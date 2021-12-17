using System;

namespace Ch16._3
{
    class Program
    {
        //客户端代码，没有任何改动。但我们的程序却更加灵活易变了。
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
    //抽象状态
    abstract class State
    {
        public abstract void WriteProgram(Work w);
    }
    //上午工作状态
    class ForenoonState:State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 12)
            {
                Console.WriteLine($"当前时间{w.Hour}，上午工作，精神百倍");
            }
            else
            {
                w.SetState(new NoonState());//超过12点，转入中午工作状态
                w.WriteProgram();
            }   
        }
    }
    //中午工作状态
    class NoonState:State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 13)
            {
                Console.WriteLine($"当前时间{w.Hour}，饿了，午饭；犯困，午休");
            }
            else
            {
                w.SetState(new AfternoonState());
                w.WriteProgram();
            }
        }
    }
    //下午工作状态
    class AfternoonState:State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 17)
            {
                Console.WriteLine($"当前时间{w.Hour}，下午状态还不错，继续努力");
            }
            else
            {
                w.SetState(new EveningState());
                w.WriteProgram();
            }
        }
    }
    //老板要求：员工必须在20点之前离开公司
    //增加一个‘强制下班状态’，并改动一下‘傍晚工作状态’类的判断就可以了。
    //晚间工作状态
    class EveningState :State
    {
        public override void WriteProgram(Work w)
        {
            if (w.TaskFinished)
            {
                w.SetState(new RestState());//完成任务转下班状态
                w.WriteProgram();
            }
            else
            {
                if (w.Hour < 21)
                {
                    Console.WriteLine($"当前时间{w.Hour}，加班哦，疲惫至极");
                }
                else
                {
                    w.SetState(new SleepingState());//超过21点转睡眠状态
                    w.WriteProgram();
                }
            }
        }
    }
    //睡眠状态
    class SleepingState:State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间{w.Hour}，不行了，睡着了");
        }
    }
    //下班休息状态
    class RestState:State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间{w.Hour}，下班回家了");
        }
    }
    //工作类，此时没有了过长的分支判断语句。
    class Work
    {
        public int Hour { get; set; }//钟点属性，状态转换的依据
        public bool TaskFinished { get; set; }//任务完成属性，是否能下班的依据
        private State current;
        public Work()
        {
            //工作初始化为上午工作状态，9点上班
            current = new ForenoonState();
        }
        public void SetState(State s)
        {
            current = s;
        }
        public void WriteProgram()
        {
            current.WriteProgram(this);
        }
    }
}
