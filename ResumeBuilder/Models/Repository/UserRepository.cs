using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.DomainModels;
using ResumeBuilder.Models.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Models.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private  ResumeBuilderContext _db;
        public UserRepository(ResumeBuilderContext db) :base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser obj)
        {
			_db.Users.Update(obj);
		}

        public ApplicationUser GetUserByEmail(string userEmail)
        {
	        var user= _db.ApplicationUsers.FirstOrDefault(x => x.Email == userEmail);
	        return user;
        }
    }
}
