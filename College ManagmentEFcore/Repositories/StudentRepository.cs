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
        public readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<student> GetAllStudents()
        {
            return _context.students
                           .Include(s => s.Courses)
                           .Include(s => s.Hostel)
                           .Include(s => s.Exams)
                           .ToList();
        }
        public student GetStudentById(int id)
        {
            return _context.students
                           .Include(s => s.Courses)
                           .Include(s => s.Hostel)
                           .Include(s => s.Exams)
                           .FirstOrDefault(s => s.SID == id);
        }
        public void AddStudent(student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(student student)
        {
            _context.students.Update(student);
            _context.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                _context.students.Remove(student);
                _context.SaveChanges();
            }
        }
        public IEnumerable<student> GetStudentsByCourse(int courseId)
        {
            return _context.students
                           .Where(s => s.Courses.Any(c => c.Id == courseId))
                           .ToList();
        }
        public IEnumerable<student> GetStudentsInHostel(int hostelId)
        {
            return _context.students
                           .Where(s => s.HostelId == hostelId)
                           .ToList();
        }
        public IEnumerable<student> SearchStudents(string searchTerm)
        {
            return _context.students
                           .Where(s => s.SName.Contains(searchTerm) || s.Phone.Contains(searchTerm))
                           .ToList();
        }
        public IEnumerable<student> GetStudentsWithAgeAbove(int age)
        {
            return _context.students
                           .Where(s => s.Age > age)
                           .ToList();
        }
        public IEnumerable<student> PaginateStudents(int pageNumber, int pageSize)
        {
            return _context.students
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }
    }
}


