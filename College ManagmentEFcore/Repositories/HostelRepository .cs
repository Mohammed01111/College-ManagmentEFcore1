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

        public IEnumerable<hostel> GetAllHostels()
        {
            return _context.hostels.Include(h => h.Students).ToList();
        }

        public hostel GetHostelById(int id)
        {
            return _context.hostels
                .Include(h => h.Students)
                .FirstOrDefault(h => h.Id == id);
        }

        public void AddHostel(hostel hostel)
        {
            _context.hostels.Add(hostel);
            _context.SaveChanges();
        }

        public void UpdateHostel(hostel hostel)
        {
            _context.hostels.Update(hostel);
            _context.SaveChanges();
        }

        public void DeleteHostel(int id)
        {
            var hostel = _context.hostels.Find(id);
            if (hostel != null)
            {
                _context.hostels.Remove(hostel);
                _context.SaveChanges();
            }
        }

        public IEnumerable<hostel> GetHostelsByCity(string city)
        {
            return _context.hostels
                .Where(h => h.City == city)
                .ToList();
        }

        public int CountHostelsWithAvailableSeats()
        {
            return _context.hostels
                .Where(h => h.AvailableSeats > 0)
                .Count();
        }
    }
}
