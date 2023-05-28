using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IResumeTemplateRepository ResumeTemplateRepository { get; }
        IResumeRepository ResumeRepository { get; }
        IContactUsRepository ContactUsRepository { get; }
        ICvInformationRepository CvInformationRepository { get; }
        void Save();
    }
}
