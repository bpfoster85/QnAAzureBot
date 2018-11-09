using Newtonsoft.Json;
using SpazBot.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpazBot
{
    class Program
    {

        public const string exitVal = "exit";

        // NOTE: Replace this with a valid host name.
        static string host = "";


        // NOTE: Replace this with a valid endpoint key.
        // This is not your subscription key.
        // To get your endpoint keys, call the GET /endpointkeys method.
        static string endpoint_key = "";

        // NOTE: Replace this with a valid knowledge base ID.
        // Make sure you have published the knowledge base with the
        // POST /knowledgebases/{knowledge base ID} method.
        static string kb = "";

        static string service = "/qnamaker";
        static string method = "/knowledgebases/" + kb + "/generateAnswer/";


        async static Task<string> Post(string uri, string body)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                client.DefaultRequestHeaders
                         .Accept
                         .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", endpoint_key);

                var response = await client.SendAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }

        static void DisplayResponse(string turnResponse)
        {
            Turn aStruct = JsonConvert.DeserializeObject<Turn>(turnResponse);
            foreach (var a in aStruct.Answers)
            {
                Console.WriteLine("Answer: " + a.Answer);
            }
            Console.WriteLine("Turn Stats:");
            Console.WriteLine(turnResponse);
            Console.WriteLine("-----------------------");
        }

        async static Task<string> GenerateTurn(string question)
        {
            var uri = host + service + method;
            var qStruct = JsonConvert.SerializeObject(new Turn(question));
            var turnResponse = await Post(uri, qStruct);
            return turnResponse;
        }

        async static Task Main(string[] args)
        {

            var input = "Hello";
            while (input != exitVal)
            {
                Console.WriteLine("What is your Question?");
                input = Console.ReadLine();
                if (input != exitVal)
                {
                    var turnResponse = await GenerateTurn(input);
                    DisplayResponse(turnResponse);
                }
            }
        }
    }
}