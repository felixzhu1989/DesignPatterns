using System;

namespace Ch24._3
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonManager jinli = new CommonManager("金立");
            MajorManager zongjian = new MajorManager("重剑");
            GeneralManager zongjingli = new GeneralManager("钟井里");
            jinli.SetSuperior(zongjian);//设置上级
            zongjian.SetSuperior(zongjingli);

            Request request = new Request
            {
                RequestType = "加薪",
                RequestContent = "小蔡请求加薪",
                Number = 1000
            };
            jinli.RequestApplication(request);

            Console.ReadKey();
        }
    }
    //申请
    class Request
    {
        public string RequestType { get; set; }
        public string RequestContent { get; set; }
        public int Number { get; set; }
    }

    abstract class Manager
    {
        protected string name;
        //管理者的上级
        protected Manager superior;
        public Manager(string name)
        {
            this.name = name;
        }
        //设置管理者的上级
        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }
        public abstract void RequestApplication(Request request);
    }
    class CommonManager:Manager
    {
        public CommonManager(string name) : base(name) { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
            }
            else
            {
                if(superior!=null)superior.RequestApplication(request);
            }
        }
    }
    class MajorManager : Manager
    {
        public MajorManager(string name) : base(name) { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
            }
            else
            {
                if (superior != null) superior.RequestApplication(request);
            }
        }
    }
    class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name) { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假")
            {
                Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
            }
            else if (request.RequestType == "加薪" && request.Number<=500)
            {
                Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
            }
            else if (request.RequestType == "加薪" && request.Number > 500)
            {
                Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}再说吧");
            }
        }
    }
}
