using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practic.STUDENT_INFORMATION_MODELS
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string? BookName { get; set; }
    }
}
