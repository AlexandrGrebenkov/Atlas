using System;
using System.Collections.Generic;
using Atlas.Domain.Entities.Base;

namespace Atlas.Domain.Entities
{
    public class Race : BaseEntity
    {
        public int RacingClassId { get; set; }
        public RacingClass RacingClass { get; set; }
        public int TimingId { get; set; }
        public Timing Timing { get; set; }
        public ICollection<QualificationResult> QualificationResults { get; } = new List<QualificationResult>();
        public ICollection<Segment> Segments { get; } = new List<Segment>();
        public DateTime? StartAt { get; set; }
        public DateTime? FinishAt { get; set; }
    }
}
