using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            return Ok(await _studentReadRepository.GetByIdAsync(id, false));   //Performans için trackinglere false verdik, çünkü db'ye kayıt update falan işlemi yapmıyor. Diğeleri default true.
        }

        //[HttpPost("Post")]  // Eğer birden fazla post, delete vs methodu varsa parantez içinde aşağıdaki fnc.ismi verilir ve react tarafından bu isimle çağırılır.
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Student model)   //Clienttan dönen veriler Entity ile karşılanmaz. ViewModella karşılanabilir, CQRS patternda request nesneleri vs ile karşılabilir. **Bu projede ViewModel ile karşılanacak.
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

            return Ok();  //Ok'da dödürülebilirdi. Statuse direkt 200 basar.

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
