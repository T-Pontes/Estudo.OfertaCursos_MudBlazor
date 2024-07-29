using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Instructor : Entity
{
    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;


    public ICollection<Class> Turmas { get; set; } = null!;
}
