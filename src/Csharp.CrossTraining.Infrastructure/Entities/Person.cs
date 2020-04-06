namespace Csharp.CrossTraining.Infrastructure.Entities
{
    using System.Collections.Generic;

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
            this.Height = height;
            this.Pets = new List<Pet>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}