namespace Csharp.CrossTraining.Infrastructure.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Person : EntityBase
    {
        public Person() : base()
        {
        }

        public Person(string name, int age, int height)
            : base()
        {
            this.Name = name;
            this.Age = age;
            this.Weight = height;
            this.Pets = new List<Pet>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }
        
        public ICollection<Pet> Pets { get; set; }

        public void AddPet(Pet petEntity)
        {
            if (this.Pets.Any(x => x.Id == petEntity.Id))
            {
                return;
            }

            this.Pets.Append(petEntity);
        }
    }
}