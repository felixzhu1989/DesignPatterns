using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ch01._1
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonInput();
            //JsonOutput();
            Console.Read();
        }

        private static void JsonInput()
        {
            //deserialize Json directly from a file
            string strJson = File.ReadAllText("plays.json");
            Dictionary<string, Play> playDic = JsonConvert.DeserializeObject<Dictionary<string, Play>>(strJson);
            List<Play> plays = new List<Play>();
            if (playDic?.Values != null) plays.AddRange(playDic.Values);
            foreach (var item in plays)
            {
                Console.WriteLine(item);
            }
        }

        private static void JsonOutput()
        {
            //output json file
            Play p2 = new Play() { Name = "A", Type = "tragedy" };
            string outputJson = JsonConvert.SerializeObject(p2);
            File.WriteAllText("output.json", outputJson);
        }
    }

    class Play
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return $"name:{Name},type:{Type}";
        }
    }
}
