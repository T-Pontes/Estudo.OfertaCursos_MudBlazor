using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Course : Entity
{
    [Required]
    [MaxLength(100)]
    public string NameCourse { get; set; } = string.Empty;

    [Required]
    public int Workload { get; set; }


    public ICollection<Class> Turmas { get; set; } = null!;
}
