namespace FinalDoctor_Api.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Doctor>? doctors { get; set; } = new List<Doctor>();
    }
}
