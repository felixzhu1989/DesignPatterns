using System;

namespace Ch27._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayContext context = new PlayContext();
            Console.WriteLine("上海滩：");
            context.PlayText = "T 500 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 ";
            Expression expression = null;
            try
            {
                while (context.PlayText.Length > 0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    switch (str)
                    {
                        case "O"://音阶
                            expression = new Scale();
                            break;
                        case "T":
                            expression = new Speed();
                            break;
                        case "C"://音符
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "A":
                        case "B":
                        case "P"://休止符
                            expression = new Note();
                            break;
                    }

                    expression.Interpret(context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
    //演奏内容
    class PlayContext
    {
        public string PlayText { get; set; }
    }
    //表达式
    abstract class Expression
    {
        //解释器
        public void Interpret(PlayContext context)
        {
            if (context.PlayText.Length == 0) return;
            else
            {
                //将当前的演奏文本第一条命令获得命令字母额其他数值
                //如“O 3 E 0.5 G 0.5 A 3”则playKey为O，而playValue为3
                string playKey = context.PlayText.Substring(0, 1);
                context.PlayText = context.PlayText.Substring(2);
                double playValue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                //获得playKey和playValue后将其从演奏文本中移除，如“O 3 E 0.5 G 0.5 A 3”变成“E 0.5 G 0.5 A 3”
                context.PlayText = context.PlayText.Substring(context.PlayText.IndexOf(" ") + 1);
                Execute(playKey,playValue);
            }
        }
        //执行
        public abstract void Execute(string key, double value);
    }
    //音符类
    class Note: Expression
    {
        public override void Execute(string key, double value)
        {
            string note = "";
            switch (key)
            {
                case "C":
                    note = "1";
                    break;
                case "D":
                    note = "2";
                    break;
                case "E":
                    note = "3";
                    break;
                case "F":
                    note = "4";
                    break;
                case "G":
                    note = "5";
                    break;
                case "A":
                    note = "6";
                    break;
                case "B":
                    note = "7";
                    break;
            }
            Console.Write($"{note} ");
        }
    }
    //音阶
    class Scale:Expression
    {
        public override void Execute(string key, double value)
        {
            string scale = "";
            switch (Convert.ToInt32(value))
            {
                case 1:
                    scale = "低音";
                    break;
                case 2:
                    scale = "中音";
                    break;
                case 3:
                    scale = "高音";
                    break;
            }
            Console.Write($"{scale} ");
        }
    }
    //演奏速度
    class Speed:Expression
    {
        public override void Execute(string key, double value)
        {
            string speed = "";
            if (value < 500)
                speed = "快速";
            else if(value>=1000)
            {
                speed = "慢速";
            }
            else
            {
                speed = "中速";
            }
            Console.Write($"{speed} ");
        }
    }
}
