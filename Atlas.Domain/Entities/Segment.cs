using System.Collections.Generic;
using Atlas.Domain.Entities.Base;

namespace Atlas.Domain.Entities
{
    public class Segment : BaseEntity
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int SegmentNumber { get; set; }
        public ICollection<SegmentDriver> SegmentDrivers { get; } = new List<SegmentDriver>();
    }
}
