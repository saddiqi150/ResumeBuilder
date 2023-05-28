using ResumeBuilder.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ResumeBuilder.Models.ViewModel
{
    public class ResumeViewModel
    {
        public Resume Resume { get; set; }
        public IEnumerable<SelectListItem> ResumeTemplates { get; set; }
    }
}
