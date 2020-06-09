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
    [Route("api/pets")]
    public class PetsControler : ControllerBase
    {
        private readonly IGenericRepository<Pet> petsRepository;
        private readonly AppMapper mapper;
        private readonly ILogger<PetsControler> logger;

        public PetsControler(
            IGenericRepository<Pet> petsRepository,
            AppMapper mapper,
            ILogger<PetsControler> logger)
        {
            this.petsRepository = petsRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = this.petsRepository
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
            var entity = this.petsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id); 

            if (entity == null)
            {
                return this.NotFound();
            }

            var result = this.mapper.Map(entity);
            return this.Ok(result);
        }

        [HttpPost]
        public IActionResult Save([FromBody] PetDto dto)
        {
            var entity = this.mapper.Map(dto);
            this.petsRepository.AddAsync(entity);

            return this.Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PetDto dto)
        {
            var entity = this.petsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return this.NotFound();
            }

            this.mapper.MapFromTo(dto, entity);
            this.petsRepository.UpdateAsync(entity);

            return this.Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = this.petsRepository
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return this.NotFound();
            }

            this.petsRepository.DeleteAsync(entity);

            return this.Ok();
        }
    }
}
