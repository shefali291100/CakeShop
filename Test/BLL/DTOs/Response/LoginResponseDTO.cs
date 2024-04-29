namespace Test.BLL.DTOs.Response
{
    public class LoginResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
