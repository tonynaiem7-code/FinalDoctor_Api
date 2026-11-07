namespace FinalDoctor_Api.Models
{
    public class Doctor
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<Patient>? patients { get; set; } = new List<Patient>();
        public int DepartmentId { get; set; }
        public Department? department { get; set; }=new Department();
    }
}
