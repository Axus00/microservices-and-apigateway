namespace Users.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsAvalable { get; set; }
    public DateTime Created_At { get; set; } = DateTime.UtcNow;
    public DateTime Updated_At { get; set; }
}