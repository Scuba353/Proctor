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
        //List of all proctors displayed
        [HttpGet]
        [Route("allproctors")]
        public IActionResult AllProctors()
        {
           List<Proctor> allproctors= _context.Proctor.Include(l => l.assignedLocations).ThenInclude(x => x.Location).ToList();
            ViewBag.listofproctors= allproctors;
            return View("Proctor");
        }

        //DELETE selected proctor
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
             Proctor remove = _context.Proctor.SingleOrDefault(b => b.proctorid == id);
            _context.Proctor.Remove(remove);
            _context.SaveChanges();  

            return RedirectToAction("AllProctors");
        }

        //return a form to create new proctor
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        //Create Proctor
        [HttpPost]
        [Route("createproctor")]
        public IActionResult CreateProctor(Proctor model)
        {
            if(ModelState.IsValid)
                {
                    Proctor NewProctor = new Proctor
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password, 
                    };
                    _context.Proctor.Add(NewProctor);
                    _context.SaveChanges();
                    return RedirectToAction("AllProctors");
                }
            return View("create", model);
        }

        //Display all locations
        [HttpGet]
        [Route("addlocation/{id}")]
        public IActionResult AddLocation(int id)
        {
            //System.Console.WriteLine("*******" +id+ "********");
            HttpContext.Session.SetInt32("proctorid", id);
            //System.Console.WriteLine((int)HttpContext.Session.GetInt32("proctorid"));
            List<Location> alllocations= _context.Location.ToList();
            ViewBag.listoflocations= alllocations;
            return View("addlocation");
        }

        //Add a location to existing proctor
        [HttpGet]
        [Route("addlocation/addproctorlocation/{id}")]
        public IActionResult AddProctorLocation(int id){
            System.Console.WriteLine("made it to the addproctorlocation");
            ProctorLocation NewMatch = new ProctorLocation
                    {
                        proctorid = (int)HttpContext.Session.GetInt32("proctorid"),
                        locationid = id,
                    };
                    _context.ProctorLocation.Add(NewMatch);
                    _context.SaveChanges();
            return RedirectToAction("AllProctors");
        } 

        //UPDATE Proctor
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult EditProctor(int id, Proctor model){
            Proctor Retrievedproctor = _context.Proctor.SingleOrDefault(p => p.proctorid == id);
            ViewBag.thisproctor= Retrievedproctor;
            return View("update");
        }

        [HttpPost]
        [Route("edit/updateproctor/{id}")]
        public IActionResult UpdateProctor(int id, Proctor model)
        {
            Proctor Retrievedproctor = _context.Proctor.SingleOrDefault(p => p.proctorid == id);
            Retrievedproctor.FirstName = model.FirstName;
            Retrievedproctor.LastName= model.LastName;
            Retrievedproctor.Email= model.Email;
            Retrievedproctor.Password= model.Password;
            _context.SaveChanges();
            return RedirectToAction("AllProctors");
        }
    }
}







    
