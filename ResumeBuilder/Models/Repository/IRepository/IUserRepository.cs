using ResumeBuilder.Models.DomainModels;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser obj);
        ApplicationUser GetUserByEmail(string userEmail);

    }
}

