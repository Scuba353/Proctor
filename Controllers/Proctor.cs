using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proctors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Proctors.Controllers
{
    public class ProctorController : Controller
    {
        private ProctorsContext _context;

        public ProctorController(ProctorsContext context){
            _context= context;
        }

        [HttpGet]
        [Route("allproctors")]
        public IActionResult AllProctors()
        {
            // List<Playit> allgames= _context.Activities.Include(x => x.Coordinator).Include(p => p.Participants).ToList();
            // ViewBag.allofthegames= allgames;
            // ViewBag.user= (int)HttpContext.Session.GetInt32("userid");
            // System.Console.WriteLine(ViewBag.user);

            return View("Proctor");
        }
    }
}