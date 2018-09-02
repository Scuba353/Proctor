using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proctors.Models
{
    public class ProctorLocation: BaseEntity {
        
        [Key]
        public int proctorlocationid { get; set; }
        
        [ForeignKey("proctorid")] 
        public int proctorid { get; set; }
        public Proctor Proctor { get; set; }
        
        [ForeignKey("locationid")]
        public int locationid { get; set; }
        public Location Location { get; set; }
        

    }
}