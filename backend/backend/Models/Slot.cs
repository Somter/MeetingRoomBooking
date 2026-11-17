using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public Resource? Resource { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? BookedByUserId { get; set; }
        public User? BookedByUser { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;



    }
}
