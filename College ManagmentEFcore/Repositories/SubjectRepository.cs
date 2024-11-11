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

        // 1. GetAllSubjects: Retrieve all subjects and include the faculty members associated with each subject.
        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects
                .Include(s => s.Teacher)  // Include the teacher (faculty) associated with the subject
                .ToListAsync();
        }

        // 2. GetSubjectById: Fetch a specific subject by ID with navigational properties.
        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            return await _context.Subjects
                .Include(s => s.Teacher)  // Include the teacher (faculty) associated with the subject
                .FirstOrDefaultAsync(s => s.Subject_Id == subjectId);
        }

        // 3. AddSubject: Add a new subject to the database.
        public async Task AddSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        // 4. UpdateSubject: Update details of an existing subject.
        public async Task UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        // 5. DeleteSubject: Delete a subject by ID.
        public async Task DeleteSubjectAsync(int subjectId)
        {
            var subject = await _context.Subjects
                .Include(s => s.Teacher)  // Optionally include the teacher information, in case you need it
                .FirstOrDefaultAsync(s => s.Subject_Id == subjectId);

            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }

        // 6. GetSubjectsTaughtByFaculty: List subjects taught by a specific faculty member using LINQ.
        public async Task<List<Subject>> GetSubjectsTaughtByFacultyAsync(int facultyId)
        {
            return await _context.Subjects
                .Where(s => s.Teacher_Id == facultyId)  // Filter by faculty ID (teacher)
                .Include(s => s.Teacher)  // Include the faculty details
                .ToListAsync();
        }

        // 7. CountSubjects: Use LINQ to get the total number of subjects offered.
        public async Task<int> CountSubjectsAsync()
        {
            return await _context.Subjects.CountAsync();
        }
    }
}
