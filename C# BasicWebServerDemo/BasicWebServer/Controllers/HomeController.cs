using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BasicWebServer.Server.Controllers
{
    public class HomeController : Controller
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
Name: <input type='text' name='Name'/>
Age: <input type='number' name='Age'/>
<input type='submit' value ='Save'/>
</form>";
        private const string DownloadForm = @"<form action='/Content' method='POST'>
<input type='submit' value='Download Sites Content' />
</form>";
        private const string FileName = "content.txt";


        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index() => Text("Hello from the server!");

        public Response Redirect() => Redirect("https://softuni.org/");

        public Response Html() => View();

        public Response HtmlFromPost()
        {
            string formData = "";

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => View();

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName,
                new string[] { "https://softuni.org/", "https://judge.softuni.org/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            if (this.Request.Cookies.Any(x => x.Name != BasicWebServer.Server.HTTP.Session.SessionCookieName))
            {
                var sb = new StringBuilder();

                sb.AppendLine("<h1>Cookies</h1>");

                sb.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in this.Request.Cookies)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    sb.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");

                return Html(sb.ToString());
            }

            var coockies = new CookieCollection();
            coockies.Add("My-Cookie", "Value-Nqkavo");
            coockies.Add("My-Cookie2", "Value2-Nqkavo2");

            return Html("<h1>Coockies set!</h1>", coockies);
        }

        public Response Session()
        {
            var currentDateKey = "CurrentDate";
            var sessionExists = this.Request.Session.ContainsKey(currentDateKey);

            var body = "";

            if (sessionExists)
            {
                var currentDate = this.Request.Session[currentDateKey];

                return Text($"Stored date: {currentDate}!");
            }

            return Text("Current date stored!");
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var response = await Task.WhenAll(downloads);

            var responseString = string.Join(Environment.NewLine + new String('-', 100), response);

        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }
    }
}
