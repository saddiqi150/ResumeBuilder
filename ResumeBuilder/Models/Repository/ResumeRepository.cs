using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.DomainModels;
using ResumeBuilder.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace ResumeBuilder.Models.Repository
{
    public class ResumeRepository : Repository<Resume>, IResumeRepository
    {
        private  ResumeBuilderContext _db;
        public ResumeRepository(ResumeBuilderContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Resume obj)
        {
            _db.Resume.Update(obj);
        }

        public async Task<List<Resume>> GetAllUserResume(string userId)
        {
            return await _db.Resume
                .Include(x => x.ResumeTemplate)
                .Where(x => x.UserId == userId && x.IsDelete==false)
                .ToListAsync();
        }
    }
}
