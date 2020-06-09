namespace Csharp.CrossTraining.WebApi.Mappers
{
    using System.Collections.Generic;
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.WebApi.Models;

    public class PersonMapper
    {
        public Person Map(PersonRequest model)
        {
            var personEntity = new Person(model.Name, model.Age, model.Weight);
            this.SetPets(model.Pets, personEntity);
            return personEntity;
        }

        public void MapFromTo(PersonRequest model, Person entity)
        {
            entity.Name = model.Name;
            entity.Age = model.Age;
            entity.Weight = model.Weight;
            this.SetPets(model.Pets, entity);
        }

        private void SetPets(IEnumerable<Pet> origin, Person personEntity)
        {
            origin?.ToList().ForEach(pet => personEntity.AddPet(pet));
        }
    }
}