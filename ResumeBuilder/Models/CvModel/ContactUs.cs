using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ResumeBuilder.Models.DomainModels;

namespace ResumeBuilder.Models.CvModel
{
    public class ContactUs
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Your first name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your last name is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Your  Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Your Message is required!")]
        public string Message { get; set; }
    }
}
