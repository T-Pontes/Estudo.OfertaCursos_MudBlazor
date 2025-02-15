﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities;

public class Instructor : Entity
{
    [Required]
    [MaxLength(80)]
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Class> Turmas { get; set; } = null!;
}
