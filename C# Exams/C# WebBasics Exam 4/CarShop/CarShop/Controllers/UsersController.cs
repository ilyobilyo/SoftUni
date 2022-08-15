using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;
using CarShop.ViewModels.User;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService userService) 
            : base(request)
        {
            this.userService = userService;
        }

        public Response Register()
        {
            return View(new { IsAuthenticated = false });
        }

        public Response Login()
        {
            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isRegistered, errorMessages) = userService.Register(model);

            if (!isRegistered)
            {
                return View(errorMessages, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            string userId = userService.Login(model);

            if (userId == null)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel() { ErrorMessage = "Username or Password is not valid."} }, "/Error");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/Cars/All");
        }

        [Authorize]
        public Response Logout()
		{
            SignOut();

            return Redirect("/");
		}
    }
}
