using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ResumeBuilder.Models.CvModel;

namespace ResumeBuilder.Models.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsAnnonymus { get; set; }
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<CvInformation> CvInformations { get; set; }

    }
}
