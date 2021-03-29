using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RedditBot
{
    public class RedditResponse
    {
        public string Kind { get; set; }
        public Listing Data { get; set; }
    }

    public class PostData
    {
        public string SubReddit { get; set; }
        public string SelfText { get; set; }
        public string LinkFlairText { get; set; }
    }

    public class Post
    {
        public string Kind { get; set; }
        public PostData Data { get; set; }
    }

    public class Listing
    {
        public string Kind { get; set; }
        public IEnumerable<Post> Data { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var client = new HttpClient();
            var username = "blah";
            var password = "blah2";
            var encodedCredentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", $"Basic {encodedCredentials}");

            var url = "https://reddit.com/r/kombucha/new.json";

            var response = await client.GetFromJsonAsync<RedditTypes.Root>(url);

            Console.WriteLine(response);
        }
    }
}
