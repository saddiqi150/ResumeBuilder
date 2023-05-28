using Microsoft.AspNetCore.Mvc.Infrastructure;
using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.Repository.IRepository;

namespace ResumeBuilder.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ResumeBuilderContext _db;
        public UnitOfWork(ResumeBuilderContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            ResumeTemplateRepository = new ResumeTemplateRepository(_db);
            ResumeRepository = new ResumeRepository(_db);
            CvInformationRepository = new CvInformationRepository(_db);
            ContactUsRepository = new ContactUsRepository(_db);
        }
        public IUserRepository User { get; private set; }
        public IResumeTemplateRepository ResumeTemplateRepository { get; private set; }
        public ICvInformationRepository CvInformationRepository { get; private set; }
        public IContactUsRepository ContactUsRepository { get; private set; }
        public IResumeRepository ResumeRepository { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
