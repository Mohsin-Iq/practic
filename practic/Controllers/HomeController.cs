using Microsoft.AspNetCore.Mvc;
using practic.Models;
using System.Diagnostics;
using practic.STUDENT_INFORMATION_MODELS;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using practic.DAL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;

namespace practic.Controllers
{
    public class HomeController : Controller
    {
         private readonly IConfiguration Configuration;
        private readonly ISQL_Connection _sqlCon;
        public HomeController(IConfiguration Configuration, ISQL_Connection sqlCon)
        {
            this.Configuration = Configuration;
            _sqlCon = sqlCon;
        }

        public IActionResult Index1()
        {
            /*  var StudentID     =logger.Value.StudentID;
              var StudentName   =logger.Value.StudentName;
              var Email         =logger.Value.Email;
              var Password      =logger.Value.Password;
              var Phone         =logger.Value.Phone;*/
            //  var student = Configuration.Student.ToList();
            var con = _sqlCon.DataSet("SELECT * FROM Student", System.Data.CommandType.Text, Configuration?.GetSection("ConnectionStrings")["DefaultConnection"]);
            List<Student> sts = new List<Student>();
            foreach (DataRow item in con.Tables[0].Rows)
            {
                sts.Add(new Student { 
                    StudentName = $"{item["StudentName"]}".Trim()
                });
            }
            return View(sts);
        }
        [HttpGet]
        public IActionResult Create()
        { 
                return View();    
        }
        [HttpPost]
        public IActionResult Create(Student st)
        {

            if (ModelState.IsValid)
            {
                //context.Student.Add(st);
                //context.SaveChanges();
                return RedirectToAction("Index1");
            }

            return View("Thanks",st);

        }
        public IActionResult Delete(int id)
        {
            //var student = context.Student.Find(id);
            //if (student != null)
            //{
            //    context.Student.Remove(student);
            //    context.SaveChanges();
            //}

            return RedirectToAction("Index1");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var student = context.Student.Find(id);
            return View();
         }

        public IActionResult Details(int id)
        {
            //var student = context.Student.Find(id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


     /*   public List<Students> GetStudents()
        {
            List<Students> students = new List<Students>();
            try
            {
               
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Students d = new Students();
                                d.StudentID = Convert.ToInt32(dr["StudentID"]);
                                d.StudentName = dr["StudentName"].ToString();
                                d.Email = dr["Email"].ToString();
                                d.Password = dr["Password"].ToString();
                                d.Phone = dr["Phone"].ToString();
                                students.Add(d);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return students;
        }
    }*/


     /*    var config = _Configuration.GetSection("Logging").GetSection("LogLevel").GetChildren()
                 .ToDictionary(x => x.Key, x => x.Value);
            ViewBag.config = config;*/
