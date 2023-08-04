using System.ComponentModel.DataAnnotations;

namespace practic.STUDENT_INFORMATION_MODELS
{

    public class Student 
    {

        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
    
    }
}
