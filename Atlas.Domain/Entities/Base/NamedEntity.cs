using System.ComponentModel.DataAnnotations;

namespace Atlas.Domain.Entities.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        [MaxLength(512)]
        public string Name { get; set; }
    }
}
