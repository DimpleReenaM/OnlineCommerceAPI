using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Entities;
using server.Dto;

namespace server.Interface.Service
{
    public interface ICartService
    {
        //Task<CartDto> AddToCart(AddToCartDto request);
        //Task<CartDto> UpdateCartItemQuantity(UpdateCartItemDto request);
        //Task<CartDto> RemoveFromCart(int cartItemId);
        //Task<CartDto> GetUserCartAsync(int userId);
        //Task<CartDto> GetCartByIdAsync(int cartId);
        //Task<CartDto> GetCartByUserIdAsync(int userId);
        //Task<decimal> GetCartTotalAsync(int userId);
        //Task<bool> IsCartEmptyAsync(int userId);
        //Task<int> GetCartItemCountAsync(int userId);
        //Task<CartDto> ClearCartAsync(int userId);
        Task<ShoppingCart?> FindUserCart(int userId);
        Task AddItemToCart(int userId, int productId, int quantity);
        Task DeleteCart(int cartId);

        Task<ShoppingCartItem?> FindCartItemById(int cartItemId);
        Task RemoveCartItem(int userId, int cartItemId);
        Task UpdateCartItem(int userId, int cartItemId, int quantity);
    }
}