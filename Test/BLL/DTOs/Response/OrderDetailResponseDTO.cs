namespace Test.BLL.DTOs.Response
{
    public class OrderDetailResponseDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CakeId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
