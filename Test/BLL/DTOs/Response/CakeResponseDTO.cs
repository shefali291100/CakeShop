namespace Test.BLL.DTOs.Response
{
    public class CakeResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string? ImageURL { get; set; }
    }
}
