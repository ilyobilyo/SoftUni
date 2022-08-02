using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Routing
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable rountingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
            => rountingTable.MapGet(path, request => controllerFunction(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable rountingTable,
            string path,
            Func<TController, Response> controllerFunction) where TController : Controller
            => rountingTable.MapPost(path, request => controllerFunction(CreateController<TController>(request)));

        private static TController CreateController<TController>(Request request)
            => (TController)Activator.CreateInstance(typeof(TController), new[] {request});
    }
}
