using System;
using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.DomainModels;
using ResumeBuilder.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ResumeBuilder.Models.CvModel;

namespace ResumeBuilder.Models.Repository
{
    public class CvInformationRepository : Repository<CvInformation>, ICvInformationRepository
    {
        private  ResumeBuilderContext _db;
        public CvInformationRepository(ResumeBuilderContext db) :base(db)
        {
            _db = db;
        }

        public void Update(CvInformation obj)
        {
            _db.CvInformation.Update(obj);
        }

        public CvInformation GetCv(Guid id)
        {
          return  _db.CvInformation
              .Include(x => x.Educations)
              .Include(x => x.Employments)
              .Include(x => x.Languages)
              .Include(x => x.Projects)
              .Include(x => x.SkillSets)
              .FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<CvInformation>> GetAllUserResume(string userId)
        {
            return await _db.CvInformation
                .Include(x => x.Educations)
                .Include(x => x.Employments)
                .Include(x => x.Languages)
                .Include(x => x.SkillSets)
                .Where(x => x.UserId == userId && x.IsDelete==false)
                .ToListAsync();
        }
    }
}
