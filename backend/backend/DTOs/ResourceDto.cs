namespace backend.DTOs
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CreateResourceDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
