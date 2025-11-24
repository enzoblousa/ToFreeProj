using Microsoft.AspNetCore.Mvc;
using FreelancerApp.Models;
using FreelancerApp.Services;

namespace FreelancerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreelancersController : ControllerBase
    {
        private readonly IFreelancerService _freelancerService;

        public FreelancersController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var freelancers = _freelancerService.GetAll();
            return Ok(freelancers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var freelancer = _freelancerService.GetById(id);
            if (freelancer == null) return NotFound();
            return Ok(freelancer);
        }

        [HttpPost]
        public IActionResult Create(Freelancer freelancer)
        {
            var created = _freelancerService.Create(freelancer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Freelancer freelancer)
        {
            var updated = _freelancerService.Update(id, freelancer);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _freelancerService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}