using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace College_ManagmentEFcore.Repositories
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<student>> GetStudentsByCourseAsync1(int courseId)
        {
            return await _context.studentCourses
                .Where(sc => sc.Course_id == courseId)
                .Include(sc => sc.Student)      // Include the Student entity
                .ThenInclude(s => s.StudentCourses) // Include the student's enrolled courses (if needed)
                .Include(sc => sc.Course)       // Include the Course entity
                .Select(sc => sc.Student)       // Return the student from the join
                .ToListAsync();
        }


        // 2. GetStudentById: Retrieve a student by SID with all related data
        public async Task<student> GetStudentByIdAsync(int studentId)
        {
            return await _context.students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Hostel)
                .Include(s => s.Teacher)
                .Include(s => s.StudentPhones)
                .FirstOrDefaultAsync(s => s.SID == studentId);
        }

        // 3. AddStudent: Add a new student
        public async Task AddStudentAsync(student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();
        }

        // 4. UpdateStudent: Update existing student information
        public async Task UpdateStudentAsync(student student)
        {
            _context.students.Update(student);
            await _context.SaveChangesAsync();
        }

        // 5. DeleteStudent: Delete a student by SID and handle related data integrity
        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await _context.students.FindAsync(studentId);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        // 6. GetStudentsByCourse: Retrieve all students enrolled in a specific course
        public async Task<List<student>> GetStudentsByCourseAsync(int courseId)
        {
            return await _context.students
                .Where(s => s.StudentCourses.Any(sc => sc.Course_id == courseId))
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Hostel)
                .Include(s => s.Teacher)
                .Include(s => s.StudentPhones)
                .ToListAsync();
        }

        // 7. GetStudentsInHostel: List all students residing in a specific hostel
        public async Task<List<student>> GetStudentsInHostelAsync(int hostelId)
        {
            return await _context.students
                .Where(s => s.Hostel_Id == hostelId)
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Hostel)
                .Include(s => s.Teacher)
                .Include(s => s.StudentPhones)
                .ToListAsync();
        }

        // 8. SearchStudents: Search students by name, phone number, or other criteria
        public async Task<List<student>> SearchStudentsAsync(string searchTerm)
        {
            return await _context.students
                .Where(s => s.FName.Contains(searchTerm) || s.LName.Contains(searchTerm) || s.StudentPhones.Any(sp => sp.Phone_no.Contains(searchTerm)))
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Hostel)
                .Include(s => s.Teacher)
                .Include(s => s.StudentPhones)
                .ToListAsync();
        }

        // 9. GetStudentsWithAgeAbove: Filter students by age
        public async Task<List<student>> GetStudentsWithAgeAboveAsync(int age)
        {
            var today = DateTime.Today;
            return await _context.students
                .Where(s => today.Year - s.DOB.Year > age)
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Hostel)
                .Include(s => s.Teacher)
                .Include(s => s.StudentPhones)
                .ToListAsync();
        }

        // 10. PaginateStudents: Implement pagination for students
        public async Task<List<student>> PaginateStudentsAsync(int pageNumber, int pageSize)
        {
            return await _context.students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.Hostel)
                .Include(s => s.Teacher)
                .Include(s => s.StudentPhones)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}


