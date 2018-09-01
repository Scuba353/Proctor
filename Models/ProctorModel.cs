using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proctors.Models
{
    public class Proctor: BaseEntity {
        
        [Key]
        public int proctorid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //list of locations
        public List<ProctorLocation> assignedLocations { get; set; }

        public Proctor(){
            assignedLocations= new List<ProctorLocation>();
        }

    }
}