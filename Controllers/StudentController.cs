using Microsoft.AspNetCore.Mvc;
using PracticeMVC.Models;

namespace PracticeMVC.Controllers
{

    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        List<Student> allstudents = new()
        {
            new Student {FirstName= "Oluwa",Id = 1,LastName= "Wizzy",Age=25},
            new Student {FirstName = "Muhammad",Id = 2,LastName="Sobur",Age=19},
            new Student {FirstName = "Olarewaju",Id = 3,LastName = "Haleemah",Age=22},
            new Student {FirstName = "Oboh",Id = 4,LastName = "Effiong",Age=19},

        };
        public IActionResult Index()
        {
            return View(allstudents);
        }



        public IActionResult Details(int id)
        {
            ViewBag.Header = "StudentInfo";
            var student = (from std in allstudents where std.Id == id select std).FirstOrDefault();
            return View(student);
        }
        public IActionResult GetCourse(int id)
        {
            
            List<string> CourseList = new List<string>();
            if (id == 1)
                CourseList = new List<string>() { "ASP.NET", "C#.NET", "SQL Server" };
            else if (id == 2)
                CourseList = new List<string>() { "ASP.NET MVC", "C#.NET", "ADO.NET" };
            else if (id== 3)
                CourseList = new List<string>() { "ASP.NET WEB API", "C#.NET", "Entity Framework" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
            ViewBag.CourseList = CourseList;
                       return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}