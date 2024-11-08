using MakeMeUpzz_UAS.Handler;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Controller
{
    public class CartController
    {
        public static List<Cart> GetCartByUserID(int UserID)
        {
            return CartHandler.GetCartByUserID(UserID);
        }

        public static Response<Cart> UpdateCart(String quantityTB, String makeupIDlbl, int UserID)
        {
            if (quantityTB == "")
            {
                return new Response<Cart>()
                {
                    Success = false,
                    Message = "quantity cannot be empty",
                    Payload = null
                };
            }
            int MakeupID = Convert.ToInt32(makeupIDlbl);
            int Quantity = Convert.ToInt32(quantityTB);
            if (Quantity <= 0)
            {
                return new Response<Cart>()
                {
                    Success = false,
                    Message = "Item Quantity must be bigger than 0",
                    Payload = null
                };
            }
            return CartHandler.UpdateCart(MakeupID, Quantity, UserID);

            
        }

        public static void DeleteCartByUserID(int UserID)
        {
            CartHandler.DeleteCartByUserID(UserID);
        }
    }
}