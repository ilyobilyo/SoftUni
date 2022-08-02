using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Controllers
{
    public class UserController : Controller
    {
        private const string Username = "user";
        private const string Password = "user123";

        public UserController(Request request)
            : base(request)
        {
        }

        public Response Login() => View();

        public Response LogInUser()
        {
            this.Request.Session.Clear();

            var body = "";

            var usernameMatches = this.Request.Form["Username"] == Username;

            var passwordMatches = this.Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                if (!this.Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();

                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

                    return Html("<h3>Logged successfully!</h3>", cookies);
                }

                return Html("<h3>Logged successfully!</h3>");
            }

            return Redirect("/Login");
        }
    }
}
