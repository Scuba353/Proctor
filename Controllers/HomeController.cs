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
        private ProctorContext _context;

        public HomeController(ProctorContext context){
            _context= context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}



