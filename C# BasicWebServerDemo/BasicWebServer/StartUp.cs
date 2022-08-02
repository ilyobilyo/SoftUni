using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using BasicWebServer.Server.Routing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace BasicWebServer
{

    class StratUp
    {

        public static async Task Main()
        {
            await new HttpServer(routes => routes
             .MapGet<HomeController>("/", c => c.Index())
             .MapGet<HomeController>("/Redirect", c => c.Redirect())
             .MapGet<HomeController>("/HTML", c => c.Html())
             .MapPost<HomeController>("/HTML", c => c.HtmlFromPost())
             .MapGet<HomeController>("/Content", c => c.Content())
             .MapPost<HomeController>("/Content", c => c.DownloadContent())
             .MapGet<HomeController>("/Cookies", c => c.Cookies())
             .MapGet<HomeController>("/Session", c => c.Session())
             .MapGet<UserController>("/Login", c => c.Login())
             .MapPost<UserController>("/Login", c => c.LogInUser()))
             .Start();

        }
    }
}
