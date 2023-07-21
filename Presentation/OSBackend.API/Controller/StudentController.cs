using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Domain.Entities;
using OSBackend.Domain.Entities.Common;
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
            return Ok(_studentReadRepository.GetAll());   //Bu fonksiyon ile Get()'e atılan istek ile studentRead'de ne kadar student varsa getAll ile hepsini clienta döndürüyor.

        }

        [HttpPost]

        public async Task<IActionResult> Post()   //Clienttan dönen veriler Entity ile karşılanmaz. ViewModella karşılanabilir, CQRS patternda request nesneleri vs ile karşılabilir. **Bu projede ViewModel ile karşılanacak.
        {
            return Ok();
        }

       
    }
}
