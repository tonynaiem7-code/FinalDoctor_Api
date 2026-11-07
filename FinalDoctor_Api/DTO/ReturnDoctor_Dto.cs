using FinalDoctor_Api.Models;

namespace FinalDoctor_Api.DTO
{
    public class ReturnDoctor_Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<ReturnPatient_Dto>? patients { get; set; }
        public ReturnDepartment_Dto? department { get; set; } 
    }

    public class ReturnPatient_Dto
    {
        public string Name { get; set; }
        public string Email { get; set; }
       
    }

    public class ReturnDepartment_Dto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
