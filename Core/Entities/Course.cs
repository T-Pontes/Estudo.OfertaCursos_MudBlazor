using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities;

public class Course : Entity
{
    [Required]
    [MaxLength(100)]
    public string NameCourse { get; set; } = string.Empty;

    [Required]
    public int Workload { get; set; }

    [JsonIgnore]
    public ICollection<Class> Classes { get; set; } = null!;
}
