using AutoMapper;
using FinalDoctor_Api.D_TO;

using FinalDoctor_Api.Models;

namespace FinalDoctor_Api.Helper
{
    public class Profilemapping:Profile
    {
        public Profilemapping()
        {
            CreateMap<Doctor, ReturnDoctor_Dto>();
            CreateMap<Patient, ReturnPatient_Dto>();
            CreateMap<Department, ReturnDepartment_Dto>();

            //addupdate Doctor

            CreateMap<AddUpdateDoctor_Dto, Doctor>();
            CreateMap<AddUpdateDepart_Dto, Department>();

        }
    }
}
