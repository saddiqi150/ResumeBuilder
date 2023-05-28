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
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private  ResumeBuilderContext _db;
        public ContactUsRepository(ResumeBuilderContext db) :base(db)
        {
            _db = db;
        }

        public void Update(ContactUs obj)
        {
            _db.ContactUs.Update(obj);
        }
    }
}
