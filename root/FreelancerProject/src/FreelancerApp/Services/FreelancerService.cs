using FreelancerApp.Models;

namespace FreelancerApp.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly List<Freelancer> _freelancers = new();
        private int _nextId = 1;

        public List<Freelancer> GetAll()
        {
            return _freelancers;
        }

        public Freelancer? GetById(int id)
        {
            return _freelancers.FirstOrDefault(f => f.Id == id);
        }

        public Freelancer Create(Freelancer freelancer)
        {
            freelancer.Id = _nextId++;
            freelancer.CreatedAt = DateTime.UtcNow;
            _freelancers.Add(freelancer);
            return freelancer;
        }

        public Freelancer? Update(int id, Freelancer freelancer)
        {
            var existingFreelancer = GetById(id);
            if (existingFreelancer == null) return null;

            existingFreelancer.Name = freelancer.Name;
            existingFreelancer.Email = freelancer.Email;
            existingFreelancer.Skills = freelancer.Skills;
            existingFreelancer.HourlyRate = freelancer.HourlyRate;

            return existingFreelancer;
        }

        public bool Delete(int id)
        {
            var freelancer = GetById(id);
            if (freelancer == null) return false;

            return _freelancers.Remove(freelancer);
        }
    }
}