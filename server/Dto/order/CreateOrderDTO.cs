using server.DTOs;

namespace server.Dto.order
{
    public class CreateOrderDTO
    {
        public int CartId { get; set; }
        public AddressDto ShipToAddress { get; set; }
    }
}
