using ResumeBuilder.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface IResumeRepository : IRepository<Resume>
    {
        void Update(Resume obj);
        Task<List<Resume>> GetAllUserResume(string userId);
    }
}
