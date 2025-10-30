namespace Users.Domain.Dtos;
public class ProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsAvalable { get; set; }
}
