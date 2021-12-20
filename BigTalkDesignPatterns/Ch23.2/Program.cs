using System;
using System.Collections.Generic;

namespace Ch23._2
{
    //尝试用门店的方式来实现它。
    class Program
    {
        static void Main(string[] args)
        {
            //开店前的准备，烧烤师傅，烤肉菜单，服务员
            Barbecuer boy = new Barbecuer();
            Command bakeMuttonCommand = new BakeMuttonCommand(boy);//菜单
            Command bakeChickenWingCommand = new BakeChickenWingCommand(boy);
            Waiter girl = new Waiter();
            //开门营业，服务员根据客户要求通知厨房开始制作
            /*
            girl.SetOrder(bakeChickenWingCommand);
            girl.Notify();
            girl.SetOrder(bakeMuttonCommand);
            girl.Notify();
            */
            girl.SetOrder(bakeChickenWingCommand);
            girl.SetOrder(bakeMuttonCommand);
            girl.SetOrder(bakeMuttonCommand);
            girl.CancelOrder(bakeMuttonCommand);
            //点完餐后一次性通知厨房
            girl.Notify();

            Console.ReadKey();
        }
    }
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("靠羊肉串");
        }
        public void BakeChickenWing()
        {
            Console.WriteLine("靠鸡翅");
        }
    }
    //抽象命令
    public abstract class Command
    {
        protected Barbecuer receiver;
        //确定烤串者是谁
        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }
        //执行命令
        public abstract void ExecuteCommand();
    }
    //烤羊肉串命令和烤鸡翅命令
    class BakeMuttonCommand:Command
    {
        public BakeMuttonCommand(Barbecuer receiver) : base(receiver) { }
        public override void ExecuteCommand()
        {
            receiver.BakeMutton();
        }
    }
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver) : base(receiver) { }
        public override void ExecuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }
    //服务员类
    public class Waiter
    {
        /* 第一，真实的情况其实并不是用户点一个菜，服务员就通知厨房去做一个，
         * 那样不科学，应该是点完烧烤后，服务员一次通知制作；
         * 第二，如果此时鸡翅没了，不应该是客户来判断是否还有，
         * 客户哪知道有没有呀，应该是服务员或烤肉串者来否决这个请求；
         * 第三，客户到底点了哪些烧烤或饮料，
         * 这是需要记录日志的，以备收费，也包括后期的统计；
         * 第四，客户完全有可能因为点的肉串太多而考虑取消一些还没有制作的肉串。
         */
        /*
        private Command command;
        //不管客户需要什么烤串，反正都是命令，只管记录订单
        public void SetOrder(Command command)
        {
            this.command = command;
        }
        //然后通知烤串者执行烤串
        public void Notify()
        {
            command.ExecuteCommand();
        }
        */
        private List<Command> orders = new List<Command>();//订单，存放命令的容器
        //设置订单
        public void SetOrder(Command command)
        {
            if (command.ToString() == "Ch23._2.BakeChickenWingCommand")
            {
                //没货进行回绝
                Console.WriteLine("服务员：鸡翅没了，请点别的烧烤");
            }
            else
            {
                //记录客户所点的烧烤日志，以备结账收钱
                orders.Add(command);
                Console.WriteLine($"订单增加：{command} 时间：{DateTime.Now}");
            }
        }

        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine($"取消订单：{command} 时间：{DateTime.Now}");
        }
        //通知全部执行
        public void Notify()
        {
            foreach (Command cmd in orders)
            {
                cmd.ExecuteCommand();
            }
        }
    }
}
