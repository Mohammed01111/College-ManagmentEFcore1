using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses
                .Include(c => c.Students)
                .Include(c => c.Faculty)
                .ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses
                .Include(c => c.Students)
                .Include(c => c.Faculty)
                .FirstOrDefault(c => c.Id == id);
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCoursesByDepartment(int departmentId)
        {
            return _context.Courses
                .Where(c => c.DepartmentId == departmentId)
                .ToList();
        }

        public IEnumerable<Course> GetCoursesWithDuration(int duration)
        {
            return _context.Courses
                .Where(c => c.Duration == duration)
                .ToList();
        }

        public IEnumerable<Course> PaginateCourses(int pageNumber, int pageSize)
        {
            return _context.Courses
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
