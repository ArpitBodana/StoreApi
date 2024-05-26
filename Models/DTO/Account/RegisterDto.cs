using System.ComponentModel.DataAnnotations;

namespace StoreApi;

public class RegisterDto
{
    [Required]
    public String? Username { get; set; }
    [Required]
    [EmailAddress]
    public String? Email { get; set; }
    [Required]
    public String? Password { get; set; }
}
