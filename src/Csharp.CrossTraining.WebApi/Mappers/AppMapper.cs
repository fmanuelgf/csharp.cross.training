namespace Csharp.CrossTraining.WebApi.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.WebApi.Dtos;

    public class AppMapper
    {
        public Person Map(PersonDto dto)
        {
            return new Person(dto.Name, dto.Age, dto.Weight);
        }

        public PersonDto Map(Person dto)
        {
            return new PersonDto 
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age,
                Weight = dto.Weight,
                Pets = this.Map(dto.Pets)
            };
        }

        public IEnumerable<PersonDto> Map(IEnumerable<Person> dtoList)
        {
            return dtoList?.ToList().Select(x => this.Map(x));
        }

        public void MapFromTo(PersonDto dto, Person entity)
        {
            entity.Name = dto.Name;
            entity.Age = dto.Age;
            entity.Weight = dto.Weight;
        }

        public PetDto Map(Pet dto)
        {
            return new PetDto 
            {
                Id = dto.Id,
                Name = dto.Name,
                Specie = dto.Specie,
                PersonId = dto.PersonId
            };
        }

        public IEnumerable<PetDto> Map(IEnumerable<Pet> dtoList)
        {
            return dtoList?.ToList().Select(x => this.Map(x));
        }

        public Pet Map(PetDto dto)
        {
            return new Pet(dto.Name, dto.Specie, dto.PersonId);
        }

        public void MapFromTo(PetDto dto, Pet entity)
        {
            entity.Name = dto.Name;
            entity.Specie = dto.Specie;
            entity.PersonId = dto.PersonId;
        }
    }
}