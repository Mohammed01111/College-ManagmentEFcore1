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

            // 1. GetAllFaculties: List all faculty members, including subjects and courses associated with them
            public async Task<List<Faculty>> GetAllFacultiesAsync()
            {
                return await _context.Faculties
                    .Include(f => f.Subjects)   // Include subjects associated with faculty
                    .Include(f => f.Department) // Include department information
                    .ToListAsync();
            }

            // 2. GetFacultyById: Fetch a faculty member's complete details by ID, with navigational properties
            public async Task<Faculty> GetFacultyByIdAsync(int facultyId)
            {
                return await _context.Faculties
                    .Include(f => f.Subjects)   // Include subjects for the faculty
                    .Include(f => f.Department) // Include department information
                    .Include(f => f.Students)   // Include students under this faculty (if applicable)
                    .FirstOrDefaultAsync(f => f.FID == facultyId);
            }

            // 3. AddFaculty: Add a new faculty member to the database
            public async Task AddFacultyAsync(Faculty faculty)
            {
                _context.Faculties.Add(faculty);
                await _context.SaveChangesAsync();
            }

            // 4. UpdateFaculty: Update the details of an existing faculty member
            public async Task UpdateFacultyAsync(Faculty faculty)
            {
                _context.Faculties.Update(faculty);
                await _context.SaveChangesAsync();
            }

            // 5. DeleteFaculty: Delete a faculty member by ID
            public async Task DeleteFacultyAsync(int facultyId)
            {
                var faculty = await _context.Faculties
                    .Include(f => f.Subjects) // Optionally, include subjects and students if needed
                    .FirstOrDefaultAsync(f => f.FID == facultyId);

                if (faculty != null)
                {
                    _context.Faculties.Remove(faculty);
                    await _context.SaveChangesAsync();
                }
            }

            // 6. GetFacultyByDepartment: List faculty members based on their department
            public async Task<List<Faculty>> GetFacultyByDepartmentAsync(string department)
            {
                return await _context.Faculties
                    .Include(f => f.Department) // Include department info
                    .Where(f => f.FDepartment.Contains(department)) // Filter by department name
                    .ToListAsync();
            }

            // 7. GetFacultyByMobileNumber: Search for faculty members by their mobile number
            public async Task<List<Faculty>> GetFacultyByMobileNumberAsync(string mobileNumber)
            {
                // Assuming there's a property for mobile number in Faculty class
                return await _context.Faculties
                    .Where(f => f.Students.Any(s => s.StudentPhones
                        .Any(p => p.Phone_no == mobileNumber))) // Searching in students' phones (if mobile is associated with students)
                    .ToListAsync();
            }

            // 8. CalculateAverageSalary: Use LINQ to calculate the average salary of faculty members
            public async Task<double> CalculateAverageSalaryAsync()
            {
                var averageSalary = await _context.Faculties
                    .AverageAsync(f => f.Salary);
                return averageSalary;
            }
        }
    
}
