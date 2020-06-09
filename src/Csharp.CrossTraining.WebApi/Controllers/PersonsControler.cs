namespace Csharp.CrossTraining.WebApi.Controllers
{
    using System;
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.Infrastructure.Repositories;
    using Csharp.CrossTraining.WebApi.Mappers;
    using Csharp.CrossTraining.WebApi.Dtos;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/persons")]
    public class PersonsControler : ControllerBase
    {
        private readonly IGenericRepository<Person> personsRepository;
        private readonly IGenericRepository<Pet> petsRepository;
        private readonly AppMapper mapper;
        private readonly ILogger<PersonsControler> logger;

        public PersonsControler(
            IGenericRepository<Person> personsRepository,
            IGenericRepository<Pet> petsRepository,
            AppMapper mapper,
            ILogger<PersonsControler> logger)
        {
            this.personsRepository = personsRepository;
            this.petsRepository = petsRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = this.personsRepository
                .GetQueryable()
                .OrderBy(x => x.Name);

            if (!entities.Any())
            {
                return this.NoContent();
            }

            var result = this.mapper.Map(entities);
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var personEntity = this.personsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id); 

            if (personEntity == null)
            {
                return this.NotFound();
            }

            personEntity.Pets = this.petsRepository
                .GetQueryable()
                .Where(x => x.PersonId == personEntity.Id)
                .ToList();

            var result = this.mapper.Map(personEntity);
            return this.Ok(result);
        }

        [HttpPost]
        public IActionResult Save([FromBody] PersonDto dto)
        {
            var entity = this.mapper.Map(dto);
            this.personsRepository.AddAsync(entity);

            var result = this.mapper.Map(entity);
            return this.Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PersonDto dto)
        {
            var entity = this.personsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return this.NotFound();
            }

            this.mapper.MapFromTo(dto, entity);
            this.personsRepository.UpdateAsync(entity);

            var result = this.mapper.Map(entity);
            return this.Ok(result);
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
