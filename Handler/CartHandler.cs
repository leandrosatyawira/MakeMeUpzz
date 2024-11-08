using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Handler
{
    public class CartHandler
    {
        public static int GenerateCartId()
        {
            Cart cart = CartRepository.GetLastCart();
            if (cart == null)
            {
                return 1;
            }
            else
            {
                int cartID = cart.CartID + 1;
                return cartID;
            }
        }
        public static List<Cart> GetCartByUserID(int UserID)
        {
            return CartRepository.GetCartByUserID(UserID);
        }

        public static Response<Cart> UpdateCart(int MakeupID, int Quantity, int UserID)
        {
            if (CartRepository.GetCartByMakeupIDandUserID(UserID, MakeupID) != null)
            {
                CartRepository.UpdateCartQuantityByMakeupIDandUserID(UserID, MakeupID, Quantity);
            }
            else
            {
                CartRepository.AddCart(GenerateCartId(), UserID, MakeupID, Quantity);
            }
            return new Response<Cart>()
            {
                Success = true,
                Payload = null
            };
        }

        public static void DeleteCartByUserID(int UserID)
        {
            CartRepository.DeleteCartByUserID(UserID);
        }
    }
}