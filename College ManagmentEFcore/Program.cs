using College_ManagmentEFcore.Models;
using College_ManagmentEFcore.Repositories;
namespace College_ManagmentEFcore
{

    public class Program
    {
        static void Main(string[] args)
        {
            // Directly instantiate ApplicationDbContext
            using var dbContext = new ApplicationDbContext();
            // Create repositories
            var studentRepository = new StudentRepository(dbContext);
            var hostelRepository = new HostelRepository(dbContext);
            var facultyRepository = new FacultyRepository(dbContext);
            var subjectRepository = new SubjectRepository(dbContext);
            var courseRepository = new CourseRepository(dbContext);
            var departmentRepository = new DepartmentRepository(dbContext);
            var examRepository = new ExamRepository(dbContext);
            // User interaction loop
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("University Management System");
                Console.WriteLine("1. Display all students");
                Console.WriteLine("2. Add new student");
                Console.WriteLine("3. Display all hostels");
                Console.WriteLine("4. Add new hostel");
                Console.WriteLine("5. Display all faculties");
                Console.WriteLine("6. Add new faculty");
                Console.WriteLine("7. Display all courses");
                Console.WriteLine("8. Add new course");
                Console.WriteLine("9. Display all departments");
                Console.WriteLine("10. Add new department");
                Console.WriteLine("11. Display all exams");
                Console.WriteLine("12. Add new exam");
                Console.WriteLine("13. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayAllStudents(studentRepository);
                        break;
                    case "2":
                        AddNewStudent(studentRepository);
                        break;
                    case "3":
                        DisplayAllHostels(hostelRepository);
                        break;
                    case "4":
                        AddNewHostel(hostelRepository);
                        break;
                    case "5":
                        DisplayAllFaculties(facultyRepository);
                        break;
                    case "6":
                        AddNewFaculty(facultyRepository);
                        break;
                    case "7":
                        DisplayAllCourses(courseRepository);
                        break;
                    case "8":
                        AddNewCourse(courseRepository);
                        break;
                    case "9":
                        DisplayAllDepartments(departmentRepository);
                        break;
                    case "10":
                        AddNewDepartment(departmentRepository);
                        break;
                    case "11":
                        DisplayAllExams(examRepository);
                        break;
                    case "12":
                        AddNewExam(examRepository);
                        break;
                    case "13":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void DisplayAllStudents(StudentRepository repository)
        {
            var students = repository.GetStudentByIdAsync();
            Console.WriteLine("\nStudents:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.SID}, Name: {student.SName}, Age: {student.Age}, Phone: {student.Phone}");
            }
        }
        static void AddNewStudent(StudentRepository repository)
        {
            Console.Write("\nEnter student name: ");
            var name = Console.ReadLine();
            Console.Write("Enter student age: ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Enter student phone: ");
            var phone = Console.ReadLine();
            Console.Write("Enter department ID: ");
            var departmentId = int.Parse(Console.ReadLine());
            Console.Write("Enter hostel ID: ");
            var hostelId = int.Parse(Console.ReadLine());
            var student = new Student { SName = name, Age = age, Phone = phone, DepartmentId = departmentId, HostelId = hostelId };
            repository.AddStudent(student);
            Console.WriteLine("Student added successfully!");
        }
        static void DisplayAllHostels(HostelRepository repository)
        {
            var hostels = repository.GetAllHostels();
            Console.WriteLine("\nHostels:");
            foreach (var hostel in hostels)
            {
                Console.WriteLine($"ID: {hostel.Id}, Name: {hostel.Name}, City: {hostel.City}, Available Seats: {hostel.AvailableSeats}");
            }
        }
        static void AddNewHostel(HostelRepository repository)
        {
            Console.Write("\nEnter hostel name: ");
            var name = Console.ReadLine();
            Console.Write("Enter hostel city: ");
            var city = Console.ReadLine();
            Console.Write("Enter available seats: ");
            var availableSeats = int.Parse(Console.ReadLine());
            var hostel = new Hostel { Name = name, City = city, AvailableSeats = availableSeats };
            repository.AddHostel(hostel);
            Console.WriteLine("Hostel added successfully!");
        }
        static void DisplayAllFaculties(FacultyRepository repository)
        {
            var faculties = repository.GetAllFaculties();
            Console.WriteLine("\nFaculties:");
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"ID: {faculty.Id}, Name: {faculty.Name}, Mobile: {faculty.MobileNumber}");
            }
        }
        static void AddNewFaculty(FacultyRepository repository)
        {
            Console.Write("\nEnter faculty name: ");
            var name = Console.ReadLine();
            Console.Write("Enter faculty mobile number: ");
            var mobileNumber = Console.ReadLine();
            Console.Write("Enter faculty department ID: ");
            var departmentId = int.Parse(Console.ReadLine());
            var faculty = new Faculty { Name = name, MobileNumber = mobileNumber, DepartmentId = departmentId };
            repository.AddFaculty(faculty);
            Console.WriteLine("Faculty added successfully!");
        }
        static void DisplayAllCourses(CourseRepository repository)
        {
            var courses = repository.GetAllCourses();
            Console.WriteLine("\nCourses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Duration: {course.Duration} months");
            }
        }
        static void AddNewCourse(CourseRepository repository)
        {
            Console.Write("\nEnter course name: ");
            var name = Console.ReadLine();
            Console.Write("Enter course duration (months): ");
            var duration = int.Parse(Console.ReadLine());
            Console.Write("Enter department ID: ");
            var departmentId = int.Parse(Console.ReadLine());
            var course = new Course { Name = name, Duration = duration, DepartmentId = departmentId };
            repository.AddCourse(course);
            Console.WriteLine("Course added successfully!");
        }
        static void DisplayAllDepartments(DepartmentRepository repository)
        {
            var departments = repository.GetAllDepartments();
            Console.WriteLine("\nDepartments:");
            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}");
            }
        }
        static void AddNewDepartment(DepartmentRepository repository)
        {
            Console.Write("\nEnter department name: ");
            var name = Console.ReadLine();
            var department = new Department { Name = name };
            repository.AddDepartment(department);
            Console.WriteLine("Department added successfully!");
        }
        static void DisplayAllExams(ExamRepository repository)
        {
            var exams = repository.GetAllExams();
            Console.WriteLine("\nExams:");
            foreach (var exam in exams)
            {
                Console.WriteLine($"ID: {exam.Id}, Title: {exam.Title}, Date: {exam.Date.ToShortDateString()}");
            }
        }
        static void AddNewExam(ExamRepository repository)
        {
            Console.Write("\nEnter exam title: ");
            var title = Console.ReadLine();
            Console.Write("Enter exam date (YYYY-MM-DD): ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter department ID: ");
            var departmentId = int.Parse(Console.ReadLine());
            var exam = new Exam { Title = title, Date = date, DepartmentId = departmentId };
            repository.AddExam(exam);
            Console.WriteLine("Exam added successfully!");
        }
    }
}









