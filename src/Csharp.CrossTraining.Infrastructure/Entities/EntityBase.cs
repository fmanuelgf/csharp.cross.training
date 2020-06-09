using System;

namespace Csharp.CrossTraining.Infrastructure.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}