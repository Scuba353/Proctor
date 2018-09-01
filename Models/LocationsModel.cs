using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proctors.Models
{
    public class Location: BaseEntity {
        
        [Key]
        public int locationid { get; set; }

        [MinLength(2)]
        public string locationName { get; set; }
        
        [MinLength(2)]
        public string street { get; set; }

        [MinLength(2)]
        public string city { get; set; }

        [MinLength(2)]
        public string state { get; set; }

        [MinLength(5)]
        public int zip { get; set; }


        //[InverseProperty("Proctor")]
        public List<ProctorLocation> ProctorsAssignedHere { get; set; }

        public Location(){
            ProctorsAssignedHere= new List<ProctorLocation>();
        }

    }
}
