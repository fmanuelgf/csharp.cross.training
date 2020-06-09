namespace Csharp.CrossTraining.WebApi.Dtos
{
    using System;
    using System.Collections.Generic;

    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public IEnumerable<PetDto> Pets { get; set; }
    }
}