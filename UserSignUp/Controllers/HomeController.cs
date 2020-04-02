using System.Web.Mvc;
using UserSignUp.BusinessServices.Inteface;
using UserSignUp.Domain;

namespace UserSignUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegistrationService _regService;

        public HomeController(IRegistrationService regService) =>
            _regService = regService;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User login)
        {
            var userInfo = _regService.LoginUser(login.EmailAddress, login.Password);
            if (userInfo == null)
            {
                ViewBag.Message = "Invalid user credentials";
                return View();
            }
            else if (userInfo.IsActive == false)
            {
                ViewBag.Message = "User is not active";
                return View();
            }
            TempData["UserInfo"] = userInfo;
            return RedirectToAction("UserInfo");
        }

        public ActionResult SignUp()
        {
            ViewBag.Title = "SignUp";
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User register)
        {
            var message = string.Empty;
            var status = false;

            if (ModelState.IsValid)
            {
                var userExists = _regService.IsUserSignedUp(register);
                if (userExists)
                {
                    ViewBag.Message = "User has already registered with this Email Address";
                    return View(register);
                }
                _regService.RegisterUser(register);
                message = "User Registration Successful. Please check your email for account activation.";
                status = true;
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Status = status;
            ViewBag.Message = message;
            return View(register);
        }

        [HttpGet]
        public ActionResult Activate(string code)
        {
            var message = string.Empty;
            var status = false;

            if (!string.IsNullOrEmpty(code) && _regService.UpdateActivation(code))
            {
                status = true;
                message = "User account activation successful!";
            }
            else
            {
                message = "User account could not be activated";
            }
            ViewBag.Status = status;
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View("SignUp");
        }

        public ActionResult UserInfo()
        {
            var model = TempData["UserInfo"] as User;
            return View(model);
        }
    }
}