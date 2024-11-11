using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Repositories
{
    public class ExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. GetAllExams: List all exams, including the department and students taking the exam.
        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _context.Exams
                .Include(e => e.Department)  // Include the department that is conducting the exam
                .Include(e => e.Students)    // Include students who are taking the exam (assuming Students is a navigation property)
                .ToListAsync();
        }

        // 2. GetExamById: Fetch exam details by ID with navigational properties.
        public async Task<Exam> GetExamByIdAsync(int examCode)
        {
            return await _context.Exams
                .Include(e => e.Department)  // Include the department conducting the exam
                .Include(e => e.Students)    // Include the students who are taking the exam
                .FirstOrDefaultAsync(e => e.Exam_Code == examCode);
        }

        // 3. AddExam: Add a new exam.
        public async Task AddExamAsync(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        // 4. UpdateExam: Modify the details of an existing exam.
        public async Task UpdateExamAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }

        // 5. DeleteExam: Delete an exam by ID.
        public async Task DeleteExamAsync(int examCode)
        {
            var exam = await _context.Exams
                .Include(e => e.Students) // Include students to handle relationships when deleting
                .FirstOrDefaultAsync(e => e.Exam_Code == examCode);

            if (exam != null)
            {
                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();
            }
        }

        // 6. GetExamsByDate: Filter exams by a specific date or date range using LINQ.
        public async Task<List<Exam>> GetExamsByDateAsync(DateOnly startDate, DateOnly endDate)
        {
            return await _context.Exams
                .Where(e => e.Date >= startDate && e.Date <= endDate)  // Filter exams between start and end date
                .Include(e => e.Department) // Include the department conducting the exam
                .Include(e => e.Students)   // Include the students taking the exam
                .ToListAsync();
        }

        // 7. GetExamsByStudent: List exams taken by a specific student.
        public async Task<List<Exam>> GetExamsByStudentAsync(int studentId)
        {
            return _context.studentCourses.Where(st => st.SID == studentId)
                                          .Include(c => c.Course)
                                          .ThenInclude(d => d.Department)
                                          .ThenInclude(e => e.Exams)
                                          .SelectMany(st => st.Course.Department.Exams)
                                          .ToList();
        }
        //{
        //    return await _context.Exams
        //        .Where(e => e.Students.Any(s => s.StudentId == studentId))  // Find exams for this student
        //        .Include(e => e.Department) // Include the department conducting the exam
        //        .Include(e => e.Students)   // Include the students in the exam
        //        .ToListAsync();
        //}

        // 8. CountExamsByDepartment: Count the number of exams conducted by a specific department.
        public async Task<int> CountExamsByDepartmentAsync(int departmentId)
        {
            return await _context.Exams
                .Where(e => e.Dept_Id == departmentId) // Filter exams by department
                .CountAsync();  // Count the exams in that department
        }
    }
}
