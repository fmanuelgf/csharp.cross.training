namespace Csharp.CrossTraining.Infrastructure.Entities
{
    using System;

    public class Pet : EntityBase
    {
        public Pet() : base()
        {
        }

        public Pet(string name, string specie)
            : base()
        {
            this.Name = name;
            this.Specie = specie;
        }

        public string Name { get; set; }
        public string Specie { get; set; } 
        public Guid PersonId { get; set; }
    }
}