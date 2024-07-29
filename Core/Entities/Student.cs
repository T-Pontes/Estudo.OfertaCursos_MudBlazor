using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Student : Entity
{
    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(8)]
    public string Enrollment { get; set; } = string.Empty;


    public ICollection<Class> Turmas { get; set; } = null!;
}
