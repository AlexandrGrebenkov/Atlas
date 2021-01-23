using System.ComponentModel.DataAnnotations;
using Atlas.Domain.Entities.Base;

namespace Atlas.Domain.Entities
{
    /// <summary>
    /// Гоночный класс (PROD-24, ES-32, F-1...)
    /// </summary>
    public class RacingClass : NamedEntity
    {
        [MaxLength(2048)]
        public string Description { get; set; }
    }
}
