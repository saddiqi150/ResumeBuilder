using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using ResumeBuilder.CvLogic;

namespace ResumeBuilder.Models.CvModel
{
    [Serializable]
    public class CvEducation : IToHtml
    {
        public Guid Id { get; set; }
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }

        [Display(Name = "End Year")]
        public int? EndYear { get; set; }
        public string Title { get; set; }
        public string University { get; set; }

        [Display(Name = "Still Studying Here")]
        public bool StillStudying { get; set; }

        public string ToHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(StartYear).Append(" - ");
            if (StillStudying)
                sb.Append("Present");
            else
                sb.Append(EndYear);
            sb.Append("<br/>").Append(HttpUtility.HtmlEncode(Title)).Append("<br/>").Append(University);
            return sb.ToString();
        }
    }
}
