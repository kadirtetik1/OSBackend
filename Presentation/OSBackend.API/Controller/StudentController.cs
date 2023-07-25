using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Application.ViewModels.Students;
using OSBackend.Domain.Entities;
using OSBackend.Domain.Entities.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace OSBackend.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {

        readonly private IStudentWriteRepository _studentWriteRepository;
        readonly private IStudentReadRepository _studentReadRepository;



        public StudentController(
            IStudentWriteRepository studentWriteRepository,
            IStudentReadRepository studentReadRepository)
        {
            _studentWriteRepository = studentWriteRepository;
            _studentReadRepository = studentReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()  //Get fonksiyonun adı değiştirilebilir.
        {
            return Ok(_studentReadRepository.GetAll(false));   //Bu fonksiyon ile Get()'e atılan istek ile studentRead'de ne kadar student varsa getAll ile hepsini clienta döndürüyor.

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _studentReadRepository.GetByIdAsync(id, false));   //Performans için trackinglere false verdik, çünkü db'ye kayıt update işlemi yapmıyor. Diğeleri default true.
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Student model)   
        {
            string same_username = "Bu kullanıcı adı daha önce alınmış. Başka bir kullanıcı adı seçiniz.";
            string same_mail = "Bu mail adresiyle kayıtlı bir üyelik bulunmakta. Şifrenizi mi unuttunuz ?";


            Student checkUser = await _studentReadRepository.GetWhere(student => student.user_name.Equals(model.user_name)).FirstOrDefaultAsync();

            Student checkMail = await _studentReadRepository.GetWhere(student => student.e_mail.Equals(model.e_mail)).FirstOrDefaultAsync();

            if (checkUser?.user_name == model.user_name)
            {
                return Ok(same_username);
            }

            else if (checkMail?.e_mail == model.e_mail)
            {
                return Ok(same_mail);
            }

            else
            {
                await _studentWriteRepository.AddAsync(new()
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    academic_role = model.academic_role,
                    e_mail = model.e_mail,
                    user_name = model.user_name,
                    password = model.password,

                });

                await _studentWriteRepository.SaveAsync();

                return Ok("Kullanıcı Oluşturuldu!");

            }


        }

        [HttpPost("userControl")]

        public async Task<ActionResult<string>> userControl(VM_Control_Student model)
        {

            string success = "Giriş Başarılı";
            string error = "";


            Student student2 = await _studentReadRepository.GetWhere(student => student.user_name.Equals(model.user_name)).FirstOrDefaultAsync(); //username'i eşit olan varsa getir
            if (student2  == null || student2.password != model.password)
            {
                error = "Kullanıcı adı veya şifre hatalı!";
                return Ok(error);
            }
            
            return Ok(success);


        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_Update_Student model)
        {
            Student student = await _studentReadRepository.GetByIdAsync(model.Id);

            student.first_name = model.first_name;
            student.last_name = model.last_name;
            student.academic_role = model.academic_role;
            student.e_mail = model.e_mail;
            student.user_name = model.user_name;
            student.password = model.password;
            await _studentWriteRepository.SaveAsync();

            return Ok();
        }



        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _studentWriteRepository.RemoveAsync(id);
            await _studentWriteRepository.SaveAsync();
            return Ok();
        }


    }
}
