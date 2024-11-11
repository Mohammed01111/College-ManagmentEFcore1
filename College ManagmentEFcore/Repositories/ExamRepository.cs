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

        public IEnumerable<Exam> GetAllExams()
        {
            return _context.Exams
                .Include(e => e.Department)
                .Include(e => e.Students)
                .ToList();
        }

        public Exam GetExamById(int id)
        {
            return _context.Exams
                .Include(e => e.Department)
                .Include(e => e.Students)
                .FirstOrDefault(e => e.Id == id);
        }

        public void AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void UpdateExam(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
        }

        public void DeleteExam(int id)
        {
            var exam = _context.Exams.Find(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Exam> GetExamsByDate(DateTime date)
        {
            return _context.Exams
                .Where(e => e.Date.Date == date.Date)
                .ToList();
        }

        public IEnumerable<Exam> GetExamsByStudent(int studentId)
        {
            return _context.Exams
                .Where(e => e.Students.Any(s => s.SID == studentId))
                .ToList();
        }

        public int CountExamsByDepartment(int departmentId)
        {
            return _context.Exams
                .Count(e => e.DepartmentId == departmentId);
        }
    }
}
