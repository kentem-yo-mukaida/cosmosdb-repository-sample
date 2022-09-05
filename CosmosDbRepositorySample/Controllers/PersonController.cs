using CosmosDbRepositorySample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.CosmosRepository;

namespace CosmosDbRepositorySample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IRepository<Person> _repository;

        public PersonController(ILogger<PersonController> logger,
            IRepository<Person> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _repository.GetAsync(q => true);
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public async Task<Person> Add()
        {
            return await _repository.CreateAsync(new Person
            {
                FirstName = "‚½‚ë‚¤",
                LastName = "‚³‚ñ‚Õ‚é",
                Customer = new Person.CustomerObject
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "‚³‚ñ‚Õ‚é‚©‚¢‚µ‚á",
                },
            });
        }
    }
}