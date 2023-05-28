using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace ResumeBuilder.Models.DomainModels
{
    public class ResumeTemplate 
    {
        public Guid Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
