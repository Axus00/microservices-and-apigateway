namespace Users.Domain.Entities;
public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}
