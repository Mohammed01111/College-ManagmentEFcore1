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

        // 1. GetAllCourses: Retrieve all courses, including students enrolled and faculty handling the course.
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.StudentsInCourse) // Include students enrolled in the course
                .Include(c => c.Department)       // Include the department offering the course
                .ToListAsync();
        }

        // 2. GetCourseById: Fetch course details by ID, with related students and faculties.
        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _context.Courses
                .Include(c => c.StudentsInCourse)  // Include students enrolled in the course
                .Include(c => c.Department)        // Include the department offering the course
                .FirstOrDefaultAsync(c => c.CourseID == courseId);
        }

        // 3. AddCourse: Add a new course to the database.
        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        // 4. UpdateCourse: Update existing course details.
        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        // 5. DeleteCourse: Delete a course by ID.
        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _context.Courses
                .Include(c => c.StudentsInCourse) // Include students in the course (if needed)
                .Include(c => c.Department)       // Include department details (if needed)
                .FirstOrDefaultAsync(c => c.CourseID == courseId);

            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        // 6. GetCoursesByDepartment: List courses offered by a specific department.
        public async Task<List<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            return await _context.Courses
                .Where(c => c.Dept_Id == departmentId)  // Filter courses by department ID
                .Include(c => c.Department)              // Include department details
                .ToListAsync();
        }

        // 7. GetCoursesWithDuration: Filter courses by their duration using LINQ.
        public async Task<List<Course>> GetCoursesWithDurationAsync(decimal minDuration, decimal maxDuration)
        {
            return await _context.Courses
                .Where(c => c.Duration >= minDuration && c.Duration <= maxDuration)  // Filter by duration
                .Include(c => c.Department)  // Optionally include department
                .ToListAsync();
        }

        // 8. PaginateCourses: Implement pagination to handle a large number of courses.
        public async Task<List<Course>> PaginateCoursesAsync(int pageIndex, int pageSize)
        {
            return await _context.Courses
                .Skip((pageIndex - 1) * pageSize)   // Skip the appropriate number of records for pagination
                .Take(pageSize)                     // Take the specified number of records per page
                .Include(c => c.Department)         // Optionally include department details
                .ToListAsync();
        }
    }
}
