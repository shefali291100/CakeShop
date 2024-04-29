using System.ComponentModel.DataAnnotations;

namespace Test.BLL.DTOs.Request
{
    public class LoginRequestDTO
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
