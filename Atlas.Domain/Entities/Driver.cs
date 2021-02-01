using System;
using Atlas.Domain.Entities.Base;

namespace Atlas.Domain.Entities
{
    public class Driver : NamedEntity
    {
        public DateTime? BirthDate { get; set; }
    }
}
