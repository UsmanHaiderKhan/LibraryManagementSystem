using System;
using LibraryManagementSystem.Data.Handlers;
using LibraryManagementSystem.Data.Models;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            //HttpCookie myCookie = Request.Cookies["logsec"];
            //if (myCookie != null)
            //{
            //    User user = new UserHandler().GetUser(myCookie.Values["logid"], myCookie.Values["psd"]);
            //    if (user != null)
            //    {
            //        myCookie.Expires = DateTime.Now.AddDays(7);
            //       ISession(Webutils.Current_User, user);
            //    }
            //}
            //ViewBag.Controller = Request.QueryString["ctl"];
            //ViewBag.Action = Request.QueryString["act"];
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel lvm)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            return View();

        }
    }
}