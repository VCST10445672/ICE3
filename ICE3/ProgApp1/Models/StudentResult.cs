using System.ComponentModel.DataAnnotations;

namespace ProgApp1.Models
{
    public class StudentResult
    {

        public int ID { get; set; }

        public int StudentID { get; set; }

        [Required]
        public string Subject { get; set; }

        [Range (0, 100)]
        public double Mark {  get; set; }

        public Student Student { get; set; }

    }
}
