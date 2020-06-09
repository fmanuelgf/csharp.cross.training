namespace Csharp.CrossTraining.WebApi.Controllers
{
    using System;
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.Infrastructure.Repositories;
    using Csharp.CrossTraining.WebApi.Mappers;
    using Csharp.CrossTraining.WebApi.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/persons")]
    public class PersonsControler : ControllerBase
    {
        private readonly IGenericRepository<Person> personsRepository;
        private readonly PersonMapper mapper;
        private readonly ILogger<PersonsControler> logger;

        public PersonsControler(
            IGenericRepository<Person> personsRepository,
            PersonMapper mapper,
            ILogger<PersonsControler> logger)
        {
            this.personsRepository = personsRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this.personsRepository
                .GetQueryable()
                .OrderBy(x => x.Name);
                
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = this.personsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id); 

            return this.Ok(result);
        }

        [HttpPost]
        public IActionResult Save([FromBody] PersonRequest model)
        {
            var entity = this.mapper.Map(model);
            this.personsRepository.AddAsync(entity);

            return this.Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PersonRequest model)
        {
            var entity = this.personsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return this.NotFound();
            }

            this.mapper.MapFromTo(model, entity);
            this.personsRepository.UpdateAsync(entity);

            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = this.personsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return this.NotFound();
            }

            this.personsRepository.DeleteAsync(entity);

            return this.Ok();
        }
    }
}
