using System.ComponentModel.DataAnnotations;

namespace CapTryout.Domain.Models;
public class Meal
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int Rating { get; set; }
    [Required]
    public DateTimeOffset CreatedAt { get; set; }
}