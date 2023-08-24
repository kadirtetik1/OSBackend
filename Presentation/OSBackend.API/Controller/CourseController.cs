using Microsoft.AspNetCore.Mvc;
using OSBackend.Application.Repository.CourseRepository;
using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Application.Repository.TeacherRepository;
using OSBackend.Application.ViewModels.Courses;
using OSBackend.Application.ViewModels.Students;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Repository.StudentRepository;

namespace OSBackend.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly private ICourseReadRepository _courseReadRepository;
        readonly private ICourseWriteRepository _courseWriteRepository;

        public CourseController(ICourseReadRepository courseReadRepository, ICourseWriteRepository courseWriteRepository)
        {
            _courseReadRepository = courseReadRepository;
            _courseWriteRepository = courseWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_courseReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _courseReadRepository.GetByIdAsync(id, false));
        }

        //[HttpGet("getByTeacherId")]
        //public async Task<IActionResult> Get(VM_Create_Course model)
        //{

        //    //Course _course = await _courseReadRepository.GetWhere(course => course.TeacherId.Equals(course.TeacherId));

        //    //await _courseReadRepository.GetByIdAsync(TeacherId.ToString, false);

        //    return Ok();

        //}

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Course model)
        {
            Course course = new()
            {
                course_name = model.course_name,
                course_code = model.course_code,
                faculty = model.faculty,
                semester = model.semester,
                weeklyHours = model.weeklyHours,
                department = model.department,
                capacity = model.capacity,
                TeacherId = model.TeacherId

            };
            await _courseWriteRepository.AddAsync(course);

            await _courseWriteRepository.SaveAsync();

            return Ok(course);

        }


        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Course model)
        {
            string success = "Güncellendi";
            Course course = await _courseReadRepository.GetByIdAsync(model.Id);

            course.course_name = model.course_name;
            course.course_code = model.course_code;
            course.faculty = model.faculty;
            course.semester = model.semester;
            course.weeklyHours = model.weeklyHours;
            course.department = model.department;
            course.capacity = model.capacity;
            course.days = model.days;
            course.endHours = model.endHours;
            course.startHours = model.startHours;

            await _courseWriteRepository.SaveAsync();

            return Ok(success);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _courseWriteRepository.RemoveAsync(id);
            await _courseWriteRepository.SaveAsync();
            return Ok();
        }


    }
}
