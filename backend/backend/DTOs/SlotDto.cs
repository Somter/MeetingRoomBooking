namespace backend.DTOs
{
    public class SlotDto
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? BookedByUserId { get; set; }
        public bool IsBooked => BookedByUserId.HasValue;
    }
}
