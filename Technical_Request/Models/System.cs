namespace Technical_Request.Models
{
    public class System
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Parent { get; set; } = null!;
    }
}
