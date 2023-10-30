using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
     [Required]
    public string  Password { get; set; }
}
