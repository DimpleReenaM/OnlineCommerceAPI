namespace server.Dto.order
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductResDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPriceAfterDiscount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }



    }
}
