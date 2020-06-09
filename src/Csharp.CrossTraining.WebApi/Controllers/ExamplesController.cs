namespace Csharp.CrossTraining.WebApi.Controllers
{
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class ExamplesController : ControllerBase
    {
        private readonly IGenericRepository<Person> personsRepository;
        private readonly IGenericRepository<Pet> petsRepository;
        private readonly ILogger<ExamplesController> logger;

        public ExamplesController(
            IGenericRepository<Person> personsRepository,
            IGenericRepository<Pet> petsRepository,
            ILogger<ExamplesController> logger)
        {
            this.personsRepository = personsRepository;
            this.petsRepository = petsRepository;
            this.logger = logger;
        }

        
        [HttpGet("linq-average")]
        public IActionResult GetAverage()
        {
            var result = this.personsRepository.GetQueryable()
                .Average(x => x.Age);
            
            return this.Ok($"Average age: {result}");
        }

        [HttpGet("linq-firstOrDefault")]
        public IActionResult GetFirstOrDefault()
        {
            // Without condition
            var result = this.personsRepository.GetQueryable()
                .FirstOrDefault(); // Just the first one or null if empty

            // // With condition
            // var result = this.personsRepository.GetQueryable()
            //     .FirstOrDefault(x => x.Age == 30); // Just the first one aged 30 or null if not found

            return this.Ok(result);
        }

        [HttpGet("linq-groupBy-toDictionary")]
        public IActionResult GetGroupBy()
        {
            var result = this.personsRepository.GetQueryable()
                .ToList() // Hack!!! EF Core do not support GroupBy for sqlite
                .GroupBy(x => x.Age) // Group persons by Age
                .ToDictionary(k => k.Key, v => v.ToArray()) // Key-Value Dictionary
                .OrderBy(x => x.Key);
                
            return this.Ok(result);
        }

        [HttpGet("linq-orderby")]
        public IActionResult GetOrderBy()
        {
            var result = this.personsRepository.GetQueryable()
                .OrderBy(x => x.Name)
                .ToList();

            return this.Ok(result);
        }

        [HttpGet("linq-select-anonymoustype")]
        public IActionResult GetSelectAnonymoustype()
        {
            var result = this.personsRepository.GetQueryable()
                .Where(x => x.Weight >= 70 && x.Weight <= 80)
                .ToList() // Hack!!! EF Core cannot translate Select calling a function
                .Select(x => new 
                {
                   Name = x.Name,
                   Descriptios = this.GetDescription(x),
                   Whatever = "foo"
                }) 
                .OrderBy(x => x.Name); // Order the resulting anonymous type accending by Name
                
            return this.Ok(result);
        }

        [HttpGet("linq-skip-take")]
        public IActionResult GetByAge()
        {
            var result = this.personsRepository.GetQueryable()
                .Skip(100) // Skip the first 100
                .Take(5) // Take only 5
                .OrderByDescending(x => x.Name) // Let's orderby descending
                .ToList(); // Materialize!
                
            return this.Ok(result);
        }

        [HttpGet("linq-union")]
        public IActionResult GetUnion()
        {
            var resultAsc = this.personsRepository.GetQueryable()
                .Where(x => x.Age < 30)
                .Take(5)
                .Select(x => x.Age);
                
            var resultDesc = this.personsRepository.GetQueryable()
                .Where(x => x.Age > 65)
                .Take(5)
                .Select(x => x.Age);

            var result = resultAsc
                .Union(resultDesc)
                .ToList();

            return this.Ok(result);
        }

        [HttpGet("linq-where")]
        public IActionResult GetWhere()
        {
            var result = this.personsRepository.GetQueryable()
                .Where(x => x.Age == 35) // Take only those aged 35
                .ToList(); // Materialize!
                
            return this.Ok(result);
        }

        private string GetDescription(Person person)
        {
            return $"Age {person.Age} and {person.Weight}cm height";
        }
    }
}
