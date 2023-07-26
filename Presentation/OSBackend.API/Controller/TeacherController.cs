using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OSBackend.Application.Repository.TeacherRepository;
using OSBackend.Application.ViewModels.Students;
using OSBackend.Application.ViewModels.Teachers;
using OSBackend.Domain.Entities;
using OSBackend.Domain.Entities.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Teacher model)   
        {
            string same_username = "Bu kullanıcı adı daha önce alınmış. Başka bir kullanıcı adı seçiniz.";
            string same_mail = "Bu mail adresiyle kayıtlı bir üyelik bulunmakta. Şifrenizi mi unuttunuz ?";
            string success = "Kayıt Başarılı!";



            Teacher checkUser = await _teacherReadRepository.GetWhere(teacher => teacher.user_name.Equals(model.user_name)).FirstOrDefaultAsync(); 

            Teacher checkMail = await _teacherReadRepository.GetWhere(teacher => teacher.e_mail.Equals(model.e_mail)).FirstOrDefaultAsync();

            if (checkUser?.user_name == model.user_name)
            {
                return Ok(same_username);
            }

            else if(checkMail?.e_mail == model.e_mail) 
            {
                return Ok(same_mail);
            }

            else
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

                return Ok(success);

            }
           

        }

        [HttpPost("userControl")]

        public async Task<ActionResult<string>> userControl(VM_Control_Teacher model)
        {

            string success = "true";
            string error = "";


            Teacher teacher2 = await _teacherReadRepository.GetWhere(teacher => teacher.user_name.Equals(model.user_name)).FirstOrDefaultAsync(); //username'i eşit olan varsa getir
            if (teacher2 == null || teacher2.password != model.password)
            {
                error = "Kullanıcı adı veya şifre hatalı!";
                return Ok(error);
            }

            return Ok(success);


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