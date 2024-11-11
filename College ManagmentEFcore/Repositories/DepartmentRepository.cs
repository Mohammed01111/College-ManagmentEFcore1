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

        // 1. GetAllDepartments: Retrieve all departments, including the courses they handle and exams conducted.
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Include(d => d.Courses)  // Include courses offered by the department
                .Include(d => d.Exams)    // Include exams associated with the department
                .Include(d => d.Faculties) // Include faculties in the department
                .ToListAsync();
        }

        // 2. GetDepartmentById: Fetch department details by ID with navigational properties.
        public async Task<Department> GetDepartmentByIdAsync(int deptId)
        {
            return await _context.Departments
                .Include(d => d.Courses)   // Include courses in the department
                .Include(d => d.Exams)     // Include exams in the department
                .Include(d => d.Faculties) // Include faculties in the department
                .FirstOrDefaultAsync(d => d.DeptId == deptId);
        }

        // 3. AddDepartment: Add a new department.
        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        // 4. UpdateDepartment: Update details of an existing department.
        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        // 5. DeleteDepartment: Delete a department by ID.
        public async Task DeleteDepartmentAsync(int deptId)
        {
            var department = await _context.Departments
                .Include(d => d.Courses)  // Include courses to check if any courses need to be handled
                .Include(d => d.Exams)    // Include exams to check if any exams are associated
                .Include(d => d.Faculties) // Include faculties to ensure integrity
                .FirstOrDefaultAsync(d => d.DeptId == deptId);

            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }

        // 6. GetDepartmentsWithCourses: List departments that offer courses using LINQ Join or Include.
        public async Task<List<Department>> GetDepartmentsWithCoursesAsync()
        {
            return await _context.Departments
                .Where(d => d.Courses.Any())  // Filter departments that offer at least one course
                .Include(d => d.Courses)      // Include the courses in the department
                .ToListAsync();
        }

        // 7. GetDepartmentNames: Retrieve just the names of all departments using projection in LINQ.
        public async Task<List<string>> GetDepartmentNamesAsync()
        {
            return await _context.Departments
                .Select(d => d.DeptName)  // Select only the department names
                .ToListAsync();
        }
    }
}
