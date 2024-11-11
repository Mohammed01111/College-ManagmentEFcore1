using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Repositories
{
    public class DepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments
                .Include(d => d.Courses)
                .Include(d => d.Exams)
                .ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments
                .Include(d => d.Courses)
                .Include(d => d.Exams)
                .FirstOrDefault(d => d.Id == id);
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartmentsWithCourses()
        {
            return _context.Departments
                .Where(d => d.Courses.Any())
                .ToList();
        }

        public IEnumerable<string> GetDepartmentNames()
        {
            return _context.Departments
                .Select(d => d.DName)
                .ToList();
        }
    }
}
