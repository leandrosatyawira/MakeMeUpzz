using MakeMeUpzz_UAS.Handler;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Controller
{
    public class TransactionsController
    {
        public static List<TransactionHeader> GetAllTransaction()
        {
            return TransactionsHandler.GetAllTransaction();
        }

        public static List<TransactionHeader> GetTransactionsByUserID(int UserID)
        {
            return TransactionsHandler.GetTransactionsByUserID(UserID);
        }

        public static void AddUnhandledTransaction(int UserID)
        {
            TransactionsHandler.AddUnhandledTransaction(UserID);
        }

        public static List<TransactionDetail> GetTransactionsDetailsByTranID(int TransactionID)
        {
            return TransactionsHandler.GetTransactionsDetailsByTranID(TransactionID);
        }

        public static List<TransactionHeader> GetTransactionsByStatus(String status)
        {
            return TransactionsHandler.GetTransactionsByStatus(status);
        }

        public static void UpdateTransactionStatus(int TransactionID)
        {
            TransactionsHandler.UpdateTransactionStatus(TransactionID);
        }
    }
}