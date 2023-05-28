using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Models
{
    public class ProjFundModel
    {
        public string ProjectName { get; set; }
        public decimal GoalAmt { get; set; }
        public string Location { get; set; }
        public string projCategory { get; set; }
        public string CreatedBy { get; set; }

        public DateTime StartDate { get; set; }
        public decimal AddedAmt { get; set; }

        public decimal UpdateGoalAmt()
        {
            decimal newGaolAmt = 0;

            newGaolAmt = GoalAmt - AddedAmt;

            return newGaolAmt;
        }




    }
}
