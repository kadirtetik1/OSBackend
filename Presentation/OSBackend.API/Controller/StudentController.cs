﻿using Microsoft.AspNetCore.Mvc;
using OSBackend.Application.Repository.StudentRepository;
using OSBackend.Domain.Entities;
using System.Net.Http.Headers;

namespace OSBackend.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {

        readonly private IStudentWriteRepository _studentWriteRepository;
        readonly private IStudentReadRepository _studentReadRepository;

        public StudentController(IStudentWriteRepository studentWriteRepository, IStudentReadRepository studentReadRepository)
        {
            _studentWriteRepository = studentWriteRepository;
            _studentReadRepository = studentReadRepository;
        }

        [HttpGet]
        public async Task Get() 
        {
            await _studentWriteRepository.AddRangeAsync(new()
            {
                new()
                { Id=Guid.NewGuid(), first_name="mehmet", last_name="şahin", age=25, address="Ankara", department="MECE",  e_mail="tetik.kadir@hotmail.com", gender="M", grade_year=2021,
                 user_name="kadir.tetik", password="1234", phone_number=03438483, profile_picture="www.dsad.com"
                },
                new()
                { Id=Guid.NewGuid(), first_name="oğuz", last_name="yılmaz", age=25, address="Ankara", department="EE",  e_mail="tetik.kadir@hotmail.com", gender="M", grade_year=2021,
                 user_name="ahmet.yilmaz", password="1234", phone_number=03438483, profile_picture="www.dsad.com"
                },

            });

            await _studentWriteRepository.SaveAsync();


        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            Student student = await _studentReadRepository.GetByIdAsync(id);
            return Ok(student);
        }
    }
}