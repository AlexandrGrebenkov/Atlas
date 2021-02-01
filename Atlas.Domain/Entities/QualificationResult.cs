using System;
using Atlas.Domain.Entities.Base;

namespace Atlas.Domain.Entities
{
    public class QualificationResult : BaseEntity
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public TimeSpan? Best { get; set; }
        public TimeSpan? SecondBest { get; set; }
    }
}
