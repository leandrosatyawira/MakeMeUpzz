using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class TransactionDetailsRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();
        public static List<TransactionDetail> GetAllTransactionDetails()
        {
            return (from x in db.TransactionDetails select x).ToList();
        }

        public static List<TransactionDetail> GetTransactionsDetailsByTranID(int TransactionID)
        {
            return (from x in db.TransactionDetails where x.TransactionID == TransactionID select x).ToList();
        }

        public static void AddNewTransactionDetails(int TransactionID, List<Cart> TransactionCart)
        {
            foreach (Cart cart in TransactionCart)
            {
                TransactionDetail transactionDetail = TransactionDetailsFactory.Create(TransactionID, cart.MakeupID, cart.Quantity);
                db.TransactionDetails.Add(transactionDetail);
            }
            db.SaveChanges();
        }

        public static TransactionDetail GetTransactionDetailByID(int TransactionID, int MakeupID)
        {
            return (from x in db.TransactionDetails where x.TransactionID == TransactionID && x.MakeupID == MakeupID select x).FirstOrDefault();
        }

        public static List<TransactionDetail> GetTransactionDetailsByMakeupID(int MakeupID)
        {
            return (from x in db.TransactionDetails where x.MakeupID == MakeupID select x).ToList();
        }

        public static void DeleteTransactionDetailsByMakeupID(int MakeupID)
        {
            List<TransactionDetail> deleteDetails = GetTransactionDetailsByMakeupID(MakeupID);
            if(deleteDetails == null)
            {
                return;
            }
            foreach (TransactionDetail transactionDetail in deleteDetails)
            {
                db.TransactionDetails.Remove(transactionDetail);
            }
            db.SaveChanges();
        }
    }
}