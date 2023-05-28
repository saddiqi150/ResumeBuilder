using System;
using ResumeBuilder.Models.DomainModels;

namespace ResumeBuilder.Models.ViewModel
{
    public class DonationProjVM
	{
        public string ProjectName { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string ImageURL { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ProjectCategory { get; set; }
        public Guid ProjectId { get; set; }
        public Guid DonationId { get; set; }
        public bool IsDonationComplate { get; set; }

	}
}
