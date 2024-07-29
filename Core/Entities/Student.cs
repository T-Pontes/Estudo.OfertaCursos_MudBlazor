using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Student : Entity
{
    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(8)]
    public string StudentCode { get; set; } = string.Empty;

    public ICollection<Enrollment> Enrollments { get; set; } = null!;
}
