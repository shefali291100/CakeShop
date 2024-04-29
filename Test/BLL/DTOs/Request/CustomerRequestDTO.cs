using System.ComponentModel.DataAnnotations;

namespace Test.BLL.DTOs.Request
{
    public class CustomerRequestDTO
    {

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
