using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentsManagement.Entities
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }
        
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<StudentSubject> Subjects { get; set; } = new List<StudentSubject>();
    }
}
