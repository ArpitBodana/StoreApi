using System.ComponentModel.DataAnnotations;

namespace StoreApi;

public class LoginDto
{
    [Required]
    public String Username { get; set; }
    [Required]
    public String Password { get; set;}
}
