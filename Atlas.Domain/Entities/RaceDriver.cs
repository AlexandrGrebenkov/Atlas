namespace Atlas.Domain.Entities
{
    public class RaceDriver
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
