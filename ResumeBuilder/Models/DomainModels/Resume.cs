using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace ResumeBuilder.Models.DomainModels
{
    public class Resume //mapping table
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public string Summary { get; set; }
        //
        public string Language { get; set; }
        //
        public string WorkExperience { get; set; }
        //
        public string Qualification { get; set; }
        //
        public string Skills { get; set; }
        //
        public string Certificates { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [Required]
        public Guid ResumeTemplateId { get; set; } 
        [ForeignKey("ResumeTemplateId")]
        [ValidateNever]
        public  ResumeTemplate ResumeTemplate {get; set;} //navigation property
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string ImageURL { get; set; }
	}
}
