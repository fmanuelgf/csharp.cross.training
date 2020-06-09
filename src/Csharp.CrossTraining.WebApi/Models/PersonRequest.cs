namespace Csharp.CrossTraining.WebApi.Models
{
    using System.Collections.Generic;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public class PersonRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}