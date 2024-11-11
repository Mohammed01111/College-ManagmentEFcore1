using College_ManagmentEFcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace College_ManagmentEFcore
{

    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(" Data Source=DESKTOP-VFQRVL8\\MSSQLSERVER02; Initial Catalog=OutsystemCompany; Integrated Security=true; TrustServerCertificate=True ");
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<hostel> hostels { get; set; }

        public DbSet<student> students { get; set; }
        //public DbSet<studentCourse> studentCourses { get; set; }
        //public DbSet<studentphone> studentphones { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentCourse> studentCourses { get; set; }
    }
    
}
