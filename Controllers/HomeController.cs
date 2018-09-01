using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proctors.Models;
using Microsoft.AspNetCore.Http;


namespace Proctors.Controllers
{
    public class HomeController : Controller
    {
        private ProctorsContext _context;

        public HomeController(ProctorsContext context){
            _context= context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
                public IActionResult isAuthorized(string Email, string Password)
        {
            var ReturnedValue = _context.Proctor.SingleOrDefault(user => user.Email == Email);
            if(ReturnedValue == null){
                ViewBag.emaildoesnotexist="The email used does not exist. Please contact the proctor administrator to set up your account.";
                return View("index");
            }
            else{
                if(ReturnedValue.Password == Password){
                    HttpContext.Session.SetString("username", ReturnedValue.FirstName);
                    HttpContext.Session.SetInt32("userid", ReturnedValue.proctorid);
                    int id= ReturnedValue.proctorid;
                    return RedirectToAction("allproctors", "Proctor", new {id= id});
                }
                else{
                    ViewBag.invalidpassword= "The password you entered does not match the email.";
                    return View("index");
                }
            }
        }   
        
    }
}







