using FreelancerApp.Models;

namespace FreelancerApp.Services
{
    public interface IFreelancerService
    {
        List<Freelancer> GetAll();
        Freelancer? GetById(int id);
        Freelancer Create(Freelancer freelancer);
        Freelancer? Update(int id, Freelancer freelancer);
        bool Delete(int id);
    }
}