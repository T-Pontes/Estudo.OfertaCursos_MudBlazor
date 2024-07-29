using System.Text.Json.Serialization;

namespace Core.Entities;
public class Enrollment : Entity
{
    public int ClassId { get; set; }
    public int StudentId { get; set; }

    [JsonIgnore]
    public Class Class { get; set; } = null!;
    [JsonIgnore]
    public Student Student { get; set; } = null!;
}
