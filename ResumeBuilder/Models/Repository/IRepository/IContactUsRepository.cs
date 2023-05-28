using ResumeBuilder.Models.CvModel;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface IContactUsRepository : IRepository<ContactUs>
    {
        void Update(ContactUs obj);
    }
}
