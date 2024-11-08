using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class TransactionHeadersRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();
        public static List<TransactionHeader> GetAllTransaction()
        {
            return (from x in db.TransactionHeaders select x).ToList();
        }

        public static List<TransactionHeader> GetTransactionsByUserID(int UserID)
        {
            return (from x in db.TransactionHeaders where x.UserID == UserID select x).ToList();
        }

        public static List<TransactionHeader> GetTransactionsByStatus(String status)
        {
            return (from x in db.TransactionHeaders where x.Status == status select x).ToList();
        }

        public static TransactionHeader GetLastTransactions()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }

        public static TransactionHeader GetTransactionByID(int ID)
        {
            return (from x in db.TransactionHeaders where x.TransactionID == ID select x).FirstOrDefault();
        }

        public static void AddUnhandledTransaction(int TransactionID, int UserID, DateTime TransactionDate)
        {
            TransactionHeader transactionHeader = TransactionHeadersFactory.Create(TransactionID, UserID, TransactionDate, "Unhandled");
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }

        public static void UpdateTransactionStatus(int TransactionID)
        {
            TransactionHeader transaction = GetTransactionByID(TransactionID);
            transaction.Status = "Handled";
            db.SaveChanges();
        }
    }
}