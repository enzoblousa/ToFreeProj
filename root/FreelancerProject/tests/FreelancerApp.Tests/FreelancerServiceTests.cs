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
        public void ObterTodos_QuandoNaoHaFreelancers_RetornaListaVazia()
        {
            // ACT (ação)
            var result = _service.GetAll();

            // ASSERT (verificação)
            Assert.Empty(result);
        }

        [Fact]
        public void Criar_FreelancerValido_RetornaFreelancerComId(){
            // ARRANGE/arranjo (preparar)
            var freelancer = new Freelancer 
            { 
                Name = "Enzo Spíndola", 
                Email = "enzoblousa@gmail.com",
                Skills = "Forte com cargas, descarregamento e organização de estoque",
                HourlyRate = 50.0m
            };


            // ACT/agir (ação) 
            var result = _service.Create(freelancer);

            // ASSERT/afirmar (verificação)
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Enzo Spíndola", result.Name);
        }
        [Fact]
        public void ObterPorId_IdExistente_RetornaFreelancer(){
            // ARRANGE (cria um freelancer primeiro)
            var freelancer = new Freelancer 
            { 
                Name = "Carlinhos da dona Dalva", 
                Email = "milcavalos@hotmail.com",
                Skills = "Conhece todos os atalhos da cidade, ótimo motorista e excelente em negociações",
                HourlyRate = 40.0m
            };
            var created = _service.Create(freelancer);

            // ACT 
            var result = _service.GetById(created.Id);

            // ASSERT (verifica nao nulo e id correto)
            Assert.NotNull(result);
            Assert.Equal(created.Id, result.Id);
        }

        [Fact]
        public void Atualizar_FreelancerExistente_RetornaFreelancerAtualizado(){
            // ARRANGE
            var freelancer = new Freelancer 
            { 
                Name = "Nome antigo", 
                Email = "oldemailexample@gmail.com" 
            };
            var created = _service.Create(freelancer);
            
            var updatedFreelancer = new Freelancer 
            { 
                Name = "Nome novo", 
                Email = "newemailexample@gmail.com" 
            };

            // ACT
            var result = _service.Update(created.Id, updatedFreelancer);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal("Nome novo", result.Name);
            Assert.Equal("newemailexample@gmail.com", result.Email);
        }

        [Fact]
        public void Excluir_FreelancerExistente_RetornaVerdadeiro()
        {
            // ARRANGE
            var freelancer = new Freelancer 
            { 
                Name = "To Delete", 
                Email = "delete@email.com" 
            };
            var created = _service.Create(freelancer);

            // ACT
            var result = _service.Delete(created.Id);

            // ASSERT
            Assert.True(result);
            Assert.Null(_service.GetById(created.Id));
        }
    }
}