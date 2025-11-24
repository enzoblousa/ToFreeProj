using Xunit;
using FreelancerApp.Models;
using FreelancerApp.Services;

namespace FreelancerApp.Tests
{
    public class FreelancerServiceTests
    {
        private readonly IFreelancerService _service;

        public FreelancerServiceTests()
        {
            _service = new FreelancerService();
        }

        [Fact]
        public void GetAll_WhenNoFreelancers_ReturnsEmptyList()
        {
            // Act
            var result = _service.GetAll();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Create_ValidFreelancer_ReturnsFreelancerWithId()
        {
            // Arrange
            var freelancer = new Freelancer 
            { 
                Name = "John Doe", 
                Email = "john@email.com",
                Skills = "C#, .NET",
                HourlyRate = 50.0m
            };

            // Act
            var result = _service.Create(freelancer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("John Doe", result.Name);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsFreelancer()
        {
            // Arrange
            var freelancer = new Freelancer 
            { 
                Name = "Jane Doe", 
                Email = "jane@email.com" 
            };
            var created = _service.Create(freelancer);

            // Act
            var result = _service.GetById(created.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(created.Id, result.Id);
        }

        [Fact]
        public void Update_ExistingFreelancer_ReturnsUpdatedFreelancer()
        {
            // Arrange
            var freelancer = new Freelancer 
            { 
                Name = "Old Name", 
                Email = "old@email.com" 
            };
            var created = _service.Create(freelancer);
            
            var updatedFreelancer = new Freelancer 
            { 
                Name = "New Name", 
                Email = "new@email.com" 
            };

            // Act
            var result = _service.Update(created.Id, updatedFreelancer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Name", result.Name);
            Assert.Equal("new@email.com", result.Email);
        }

        [Fact]
        public void Delete_ExistingFreelancer_ReturnsTrue()
        {
            // Arrange
            var freelancer = new Freelancer 
            { 
                Name = "To Delete", 
                Email = "delete@email.com" 
            };
            var created = _service.Create(freelancer);

            // Act
            var result = _service.Delete(created.Id);

            // Assert
            Assert.True(result);
            Assert.Null(_service.GetById(created.Id));
        }
    }
}