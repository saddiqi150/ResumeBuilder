using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.DomainModels;
using ResumeBuilder.Models.Repository.IRepository;

namespace ResumeBuilder.Models.Repository
{
    public class ResumeTemplateRepository : Repository<ResumeTemplate>, IResumeTemplateRepository
    {
        private  ResumeBuilderContext _db;
        public ResumeTemplateRepository(ResumeBuilderContext db) :base(db)
        {
            _db = db;
        }

        public void Update(ResumeTemplate obj)
        {
            _db.ResumeTemplate.Update(obj);
        }
    }
}
