using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_ManagmentEFcore.Repositories
{
    public class HostelRepository
    {
        private readonly ApplicationDbContext _context;

        public HostelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. GetAllHostels: Retrieve all hostels with the list of students associated with each hostel
        public async Task<List<hostel>> GetAllHostelsAsync()
        {
            return await _context.hostels
                .Include(h => h.Students)  // Include students associated with each hostel
                .ToListAsync();
        }

        // 2. GetHostelById: Fetch details of a specific hostel, including students
        public async Task<hostel> GetHostelByIdAsync(int hostelId)
        {
            return await _context.hostels
                .Include(h => h.Students)  // Include students in the specific hostel
                .FirstOrDefaultAsync(h => h.hostel_id == hostelId);
        }

        // 3. AddHostel: Add a new hostel to the database
        public async Task AddHostelAsync(hostel hostel)
        {
            _context.hostels.Add(hostel);
            await _context.SaveChangesAsync();
        }

        // 4. UpdateHostel: Modify an existing hostel's details
        public async Task UpdateHostelAsync(hostel hostel)
        {
            _context.hostels.Update(hostel);
            await _context.SaveChangesAsync();
        }

        // 5. DeleteHostel: Remove a hostel by ID and ensure no orphaned student data
        public async Task DeleteHostelAsync(int hostelId)
        {
            var hostel = await _context.hostels
                .Include(h => h.Students)  // Include students to check if any are assigned
                .FirstOrDefaultAsync(h => h.hostel_id == hostelId);

            if (hostel != null)
            {
                // Remove the hostel from the students' assignments
                foreach (var student in hostel.Students)
                {
                    student.Hostel_Id = null; // Disassociate students from this hostel
                }

                _context.hostels.Remove(hostel);
                await _context.SaveChangesAsync();
            }
        }

        // 6. GetHostelsByCity: List hostels in a specific city
        public async Task<List<hostel>> GetHostelsByCityAsync(string city)
        {
            return await _context.hostels
                .Where(h => h.hostel_name.Contains(city)) // Filter by city (hostel name here)
                .Include(h => h.Students)                 // Include students in each hostel
                .ToListAsync();
        }

        // 7. CountHostelsWithAvailableSeats: Count hostels with available seats
        public async Task<int> CountHostelsWithAvailableSeatsAsync()
        {
            return await _context.hostels
                .Where(h => h.no_of_seats > 0)   // Filter hostels with available seats
                .CountAsync();
        }
    }
}
