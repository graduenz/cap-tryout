namespace CapTryout.Domain.Dto;
public class MealDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Rating { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}