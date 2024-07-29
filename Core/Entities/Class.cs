using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Class : Entity
{
    [Required]
    [MaxLength(15)]
    public string ClassCode { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }


    public Instructor Instructor { get; set; } = null!;
    public int InstructorId { get; set; }

    public Course Course { get; set; } = null!;
    public int CourseId { get; set; }

    public ICollection<Student> Students { get; set; } = null!;
}
