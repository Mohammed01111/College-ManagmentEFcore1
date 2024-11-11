using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Repositories
{
    public class SubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects
                .Include(s => s.Faculty)
                .ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return _context.Subjects
                .Include(s => s.Faculty)
                .FirstOrDefault(s => s.Id == id);
        }

        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void DeleteSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Subject> GetSubjectsTaughtByFaculty(int facultyId)
        {
            return _context.Subjects
                .Where(s => s.FacultyId == facultyId)
                .ToList();
        }

        public int CountSubjects()
        {
            return _context.Subjects.Count();
        }
    }
}

