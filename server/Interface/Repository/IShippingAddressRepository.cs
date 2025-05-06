using server.Entities;

namespace server.Interface.Repository
{
    public interface IShippingAddressRepository: IGenericRepository<ShippingAddress>
    {
        Task<ShippingAddress?> GetShippingAddressByOrderId(int orderId);
    }
}
