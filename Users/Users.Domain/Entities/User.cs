using System.ComponentModel.DataAnnotations;

namespace Users.Domain.Entities;
public class User
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    [RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\.\,]+$",
        ErrorMessage = "El nombre solo puede contener letras, números, espacios, puntos o comas")]
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;
}
