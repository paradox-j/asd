using System.Net;
using System.Text.Json.Serialization;
using TestApi.Entities;
using TestWebApp.Models;

namespace TestWebApp.AppData
{
    public class Connect
    {
        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:2904/api/")
        };
        public async static Task<List<VisitorsModel>?> GetVisitors() => await client.GetFromJsonAsync<List<VisitorsModel>>("Visitors");
        public static VisitorsModel? curUser;
        public static void Autorization(string? login, string? password) => 
            curUser = GetVisitors().Result?.FirstOrDefault(x => x.VisitorLogin == login && x.VisitorPassword == password);
    }
}
