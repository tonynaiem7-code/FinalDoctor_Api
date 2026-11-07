namespace FinalDoctor_Api.Models
{
    public class Devies
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int PatientId { get; set; }
        public Patient? patient { get; set; }
    }
}
