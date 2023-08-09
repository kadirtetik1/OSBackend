using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OSBackend.Application.Abstractions.Token;
using OSBackend.Application.DTOs;
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

        readonly ITokenHandler _tokenHandler;  //Normalde kendisi loginuserhandler diye bir class oluşturup orada çağırıyor. Sen controllerda yaptın, hata çıkarsa geriye dön!

        public StudentController(
            IStudentWriteRepository studentWriteRepository,
            IStudentReadRepository studentReadRepository,
            ITokenHandler tokenHandler)
        {
            _studentWriteRepository = studentWriteRepository;
            _studentReadRepository = studentReadRepository;
            _tokenHandler = tokenHandler;
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
            string success = "Kayıt Başarılı!";


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

            else   //Başarılı
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

                return Ok(success);

            }


        }

        [HttpPost("userControl")]
        public async Task<ActionResult<string>> userControl(VM_Control_Student model)
        {

            string success = "true";
            string error = "Kullanıcı adı veya şifre hatalı!";


            Student student2 = await _studentReadRepository.GetWhere(student => student.user_name.Equals(model.user_name)).FirstOrDefaultAsync(); //username'i eşit olan varsa getir
            if (student2  == null || student2.password != model.password)
            {
               
                return Ok(error);
            }

            else  //Başarılı
            {
                

                Token token = _tokenHandler.CreateAccessToken(30, student2.Id); // Parametre olarak " student2.Id" alsın ve fnc.da ona göre düzenle.

                return Ok(token);  //success dönüyordu!
            }
            

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Student model)
        {
            Student student = await _studentReadRepository.GetByIdAsync(model.Id);  //studentWrite olması gerekmiyor mu ? Test et!

            student.first_name = model.first_name;
            student.last_name = model.last_name;
            student.academic_role = model.academic_role;
            student.e_mail = model.e_mail;
            student.user_name = model.user_name;
            student.password = model.password;
            student.phone_number = model.phone_number;
            student.department = model.department;
            student.gender=model.gender;
            await _studentWriteRepository.SaveAsync();

            return Ok();    // success, error gönder ve frontta kaydet butonuyla bastığın güncellendi mesajı burdan dönen veriye göre bas!
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
