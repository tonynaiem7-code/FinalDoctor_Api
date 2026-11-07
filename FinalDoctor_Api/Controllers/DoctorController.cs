using AutoMapper;
using FinalDoctor_Api.D_TO;
using FinalDoctor_Api.Models;
using FinalDoctor_Api.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDoctor_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly Doctor_Repo _dotor_repo;
        private readonly IMapper _mapper;
        private readonly IGeneric<Patient> _Patientgeneric;

        public DoctorController(Doctor_Repo dotor_repo, IMapper mapper, IGeneric<Patient> patientgeneric)
        {
            _dotor_repo = dotor_repo;
            _mapper = mapper;
            _Patientgeneric = patientgeneric;
        }

        //GetAll Doctor

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnDoctor_Dto>>> GetallDoctor()
        {
            var x = await _dotor_repo.Getall();
            var y =  _mapper.Map<IEnumerable<ReturnDoctor_Dto>>(x);
            return Ok(y);


        }
        [HttpGet("{id}")]

        public async Task<ActionResult<ReturnDoctor_Dto?>> GetById(int id)
        {
            var Doctor= await _dotor_repo.GetById(id);
            if(Doctor == null) 
                return NotFound();

            var DoctorData=_mapper.Map<ReturnDoctor_Dto>(Doctor);
            return Ok(DoctorData);


        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dotor_repo.Delete(id);
            if (result == false)
                return NotFound();

            return Ok();

        }
        [HttpPost]
        public async Task<ActionResult> Add(AddUpdateDoctor_Dto doctorDto)
        {
            //mappp

           var doctordata=_mapper.Map<Doctor>(doctorDto);

            // doctor-patient 
            if(doctorDto.PatientId!=null)
            {
                foreach(int patientId in  doctorDto.PatientId)
                {
                    var Patientdata= await _Patientgeneric.GetById(patientId);
                    if (Patientdata == null)
                        return NotFound();

                    doctordata.patients.Add(Patientdata);
                }
            }

          await  _dotor_repo.Add(doctordata);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AddUpdateDoctor_Dto doctordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var doctorobj=await _dotor_repo.GetById(id);

            if(doctorobj== null)
                return NotFound();

            doctorobj.Name=doctordto.Name;
            doctorobj.Email=doctordto.Email;

            //update Department

            if (doctordto.department != null)
            {
                doctorobj.department.Name = doctordto.department.Name;
                doctorobj.department.Description = doctordto.department.Description;

            }

            if(doctordto.PatientId!=null)
            {
                doctorobj.patients.Clear();
                foreach(int patientId in doctordto.PatientId)
                {
                    var patientdata= await _Patientgeneric.GetById(patientId);
                    if(patientdata==null)
                        return NotFound();

                    doctorobj.patients.Add(patientdata);

                }
            }

          await  _dotor_repo.Update(doctorobj);
            return Ok();



        }

    }
}
