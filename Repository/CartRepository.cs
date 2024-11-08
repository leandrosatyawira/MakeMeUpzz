using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class CartRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetCartByUserID(int id)
        {
            return (from x in db.Carts where x.UserID == id select x).ToList();
        }

        public static Cart GetLastCart()
        {
            return db.Carts.ToList().LastOrDefault();
        }
        public static void AddCart(int CartID, int UserID, int MakeupID, int Quantity)
        {
            Cart cart = CartsFactory.Create(CartID, UserID, MakeupID, Quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }


        public static List<Cart> GetCartsByMakeupID(int MakeupID)
        {
            return (from x in db.Carts where x.MakeupID == MakeupID select x).ToList();
        }

        public static Cart GetCartByMakeupIDandUserID(int userID, int MakeupID)
        {
            return (from x in db.Carts where x.MakeupID == MakeupID && x.UserID == userID select x).FirstOrDefault();
        }

        public static void UpdateCartQuantityByMakeupIDandUserID(int userID, int MakeupID, int quantity)
        {
            Cart updateCart = GetCartByMakeupIDandUserID(userID, MakeupID);
            updateCart.Quantity = updateCart.Quantity + quantity;
            db.SaveChanges();
        }
        
        public static void DeleteCartByUserID(int userID)
        {
            List<Cart> deleteCarts = GetCartByUserID(userID);
            foreach (Cart cart in deleteCarts)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static void DeleteCartByMakeupID(int MakeupID)
        {
            List<Cart> deleteCarts = GetCartsByMakeupID(MakeupID);
            if(deleteCarts == null)
            {
                return;
            }
            foreach (Cart cart in deleteCarts)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }
    }
}