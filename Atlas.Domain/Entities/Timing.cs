using System;
using System.Collections.Generic;
using Atlas.Domain.Entities.Base;

namespace Atlas.Domain.Entities
{
    public class Timing : BaseEntity
    {
        public TimeSpan Qualification { get; set; }
        public TimeSpan QualificationTransition { get; set; }
        public TimeSpan Race { get; set; }
        public TimeSpan RaceTransition { get; set; }

        public ICollection<Race> Races { get; } = new List<Race>();
    }
}
