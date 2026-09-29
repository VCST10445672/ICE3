using System.ComponentModel.DataAnnotations;

namespace ProgApp1.Models
{
    public class Student
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 130)]
        public int Age { get; set; }

        public ICollection <StudentResult> Results { get; set; } = new List<StudentResult>();

    }
}
