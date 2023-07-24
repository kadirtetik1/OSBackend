using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using OSBackend.Application.Repository.TeacherRepository;
using OSBackend.Application.ViewModels.Teachers;
using OSBackend.Domain.Entities;
using OSBackend.Domain.Entities.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace OSBackend.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {

        readonly private ITeacherWriteRepository _teacherWriteRepository;
        readonly private ITeacherReadRepository _teacherReadRepository;



        public TeacherController(
            ITeacherWriteRepository teacherWriteRepository,
            ITeacherReadRepository teacherReadRepository)
        {
            _teacherWriteRepository = teacherWriteRepository;
            _teacherReadRepository = teacherReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()  
        {
            return Ok(_teacherReadRepository.GetAll(false));   

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _teacherReadRepository.GetByIdAsync(id, false));   //Performans için trackinglere false verdik, çünkü db'ye kayıt update falan işlemi yapmıyor. Diğeleri default true.
        }

        //[HttpPost("Post")]  // Eğer birden fazla post, delete vs methodu varsa parantez içinde aşağıdaki fnc.ismi verilir ve react tarafından bu isimle çağırılır.
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Teacher model)   
        {
            await _teacherWriteRepository.AddAsync(new()
            {
                first_name = model.first_name,
                last_name = model.last_name,
                academic_role = model.academic_role,
                e_mail = model.e_mail,
                user_name = model.user_name,
                password = model.password,

            });
            await _teacherWriteRepository.SaveAsync();

            return Ok();

        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_Update_Teacher model)   //Teacher VM oluştur !!
        {
            Teacher teacher = await _teacherReadRepository.GetByIdAsync(model.Id);

            teacher.first_name = model.first_name;
            teacher.last_name = model.last_name;
            teacher.academic_role = model.academic_role;
            teacher.e_mail = model.e_mail;
            teacher.user_name = model.user_name;
            teacher.password = model.password;
            await _teacherWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _teacherWriteRepository.RemoveAsync(id);
            await _teacherWriteRepository.SaveAsync();
            return Ok();
        }


    }
}