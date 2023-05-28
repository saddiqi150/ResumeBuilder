using ResumeBuilder.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface IResumeTemplateRepository : IRepository<ResumeTemplate>
    {
        void Update(ResumeTemplate obj);
        
    }
}
