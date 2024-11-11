using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Repositories
{
        public class FacultyRepository
        {
        private readonly ApplicationDbContext _context;

        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _context.Faculties
                .Include(f => f.Subjects)
                .Include(f => f.Courses)
                .ToList();
        }

        public Faculty GetFacultyById(int id)
        {
            return _context.Faculties
                .Include(f => f.Subjects)
                .Include(f => f.Courses)
                .FirstOrDefault(f => f.Id == id);
        }

        public void AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public void UpdateFaculty(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
        }

        public void DeleteFaculty(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Faculty> GetFacultyByDepartment(int departmentId)
        {
            return _context.Faculties
                .Where(f => f.DepartmentId == departmentId)
                .ToList();
        }

        public IEnumerable<Faculty> GetFacultyByMobileNumber(string mobileNumber)
        {
            return _context.Faculties
                .Where(f => f.MobileNumber == mobileNumber)
                .ToList();
        }

        public decimal CalculateAverageSalary()
        {
            return _context.Faculties.Average(f => f.Salary);
        }
    }

}
