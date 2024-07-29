using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}
