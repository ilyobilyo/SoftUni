using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [Method.GET] = new(),
                [Method.POST] = new(),
                [Method.PUT] = new(),
                [Method.DELETE] = new(),
            };


        }

        public IRoutingTable Map(Method method, string path, Func<Request, Response> responseFuntion)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFuntion, nameof(responseFuntion));

            this.routes[method][path] = responseFuntion;

            return this;
        }


        public IRoutingTable MapGet(string path, Func<Request, Response> responseFuntion)
            => Map(Method.GET, path, responseFuntion);

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFuntion)
            => Map(Method.POST, path, responseFuntion);

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;

            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
