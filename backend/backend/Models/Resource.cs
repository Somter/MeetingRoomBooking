namespace backend.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Slot> Slots { get; set; } = new();
    }
}
