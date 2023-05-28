using ResumeBuilder.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using ResumeBuilder.Models.CvModel;
using System;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface ICvInformationRepository : IRepository<CvInformation>
    {
        void Update(CvInformation obj);
        CvInformation GetCv(Guid id);
        Task<List<CvInformation>> GetAllUserResume(string userId);
    }
}
