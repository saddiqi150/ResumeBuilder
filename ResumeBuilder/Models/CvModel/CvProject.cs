using System;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Models.CvModel
{
    public class CvProject
    {
        public Guid Id { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Name { get; set; }
        public string Role { get; set; }
        [Required]
        public string Description { get; set; }
        public string Link { get; set; }

        [Display(Name = "Tech Stack")]
        public string TechStack { get; set; }
    }
}
