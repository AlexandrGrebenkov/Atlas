namespace Atlas.Domain.Entities
{
    public class SegmentDriver
    {
        public int SegmentId { get; set; }
        public Segment Segment { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
