using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace JsonCompatibilityParsing
{
    class Program
    {
        static string[] JsonBlobs => new[] {
            JArray.FromObject(new [] {
                "Hello",
                "World",
            }).ToString(),
            JObject.FromObject(new
            {
                StringValue = "Hello",
                PrivateValue = "World"
            }).ToString(),
            JObject.FromObject(new
            {
                String = "Hello",
                Private = "World"
            }).ToString(),
        };

        static void Main(string[] args)
        {
            JsonBlobs
                .Select(s => new
                {
                    Json = s,
                    Object = JToken.Parse(s).ToObject<Data>()
                })
                .ToList()
                .ForEach(obj =>
                {
                    Console.WriteLine(obj.Json);
                    Console.WriteLine(obj.Object);
                    Console.WriteLine(JToken.FromObject(obj.Object).ToString());
                });
                Console.ReadKey();
        }
    }
}