namespace Csharp.CrossTraining.WebApi.Dtos
{
    using System;
    
    public class PetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specie { get; set; }
        public Guid PersonId { get; set; }
    }
}