using System;

namespace Ch24._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //三个管理者
            Manager jingli = new Manager("金立");
            Manager zongjian = new Manager("重剑");
            Manager zongjingli = new Manager("钟井里");
            Request request = new Request
            {
                RequestType = "加薪",
                RequestContent = "小蔡请求加薪",
                Number = 1000
            };

            jingli.GetResult("经理",request);
            zongjian.GetResult("总监", request);
            zongjingli.GetResult("总经理", request);

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
    //管理者
    class Manager
    {
        protected string name;
        public Manager(string name)
        {
            this.name = name;
        }
        public void GetResult(string managerLevel, Request request)
        {
            if (managerLevel == "经理")
            {
                if (request.RequestType == "请假" && request.Number <= 2)
                {
                    Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
                }
                else
                {
                    Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}我无权处理");
                }
            }
            else if(managerLevel=="总监")
            {
                if (request.RequestType == "请假" && request.Number <= 5)
                {
                    Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
                }
                else
                {
                    Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}我无权处理");
                }
            }
            else if (managerLevel == "总经理")
            {
                if (request.RequestType == "请假")
                {
                    Console.WriteLine($"{name}:{request.RequestContent}，数量{request.Number}被批准");
                }
                else if(request.RequestType == "加薪" && request.Number<=500)
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
}
