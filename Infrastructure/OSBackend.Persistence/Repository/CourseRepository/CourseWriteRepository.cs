﻿using OSBackend.Application.Repository.CourseRepository;
using OSBackend.Domain.Entities;
using OSBackend.Persistence.Contexts;

namespace OSBackend.Persistence.Repository.CourseRepository
{
    public class CourseWriteRepository : WriteRepository<Course>, ICourseWriteRepository
    {
        public CourseWriteRepository(OsBackendDbContext context) : base(context)
        {
        }
    }
}
