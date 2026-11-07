namespace FinalDoctor_Api.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Doctor>? doctors { get; set; } = new List<Doctor>();
        public Devies? dvies { get; set; }
    }
}
