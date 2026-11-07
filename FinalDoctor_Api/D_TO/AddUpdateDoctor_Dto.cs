using FinalDoctor_Api.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalDoctor_Api.D_TO
{
    public class AddUpdateDoctor_Dto
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public List<int>? PatientId { get; set; }

        public AddUpdateDepart_Dto? department { get; set; }
    }

    public class AddUpdateDepart_Dto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
