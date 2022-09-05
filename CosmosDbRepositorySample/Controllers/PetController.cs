using CosmosDbRepositorySample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;

namespace CosmosDbRepositorySample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly ILogger<PetController> _logger;
        private readonly IRepository<Pet> _repository;

        public PetController(ILogger<PetController> logger,
            IRepository<Pet> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pet>> Get()
        {
            return await _repository.GetAsync(q => true);
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<Pet> Add()
        {
            return await _repository.CreateAsync(new Pet
            {
                Name = "‚Û‚¿",
                AnimalType = "dog",
                Owner = new Pet.OwnerObject
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "‚½‚ë‚¤",
                },
            });
        }
    }
}