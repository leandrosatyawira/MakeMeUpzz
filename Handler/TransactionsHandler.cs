using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Handler
{
    public class TransactionsHandler
    {
        public static int GenerateTransactionId()
        {
            TransactionHeader transaction = TransactionHeadersRepository.GetLastTransactions();
            if (transaction == null)
            {
                return 1;
            }
            else
            {
                int transactionID = transaction.TransactionID + 1;
                return transactionID;
            }
        }

        public static void AddUnhandledTransaction(int UserID)
        {
            DateTime transactionDate = DateTime.Now;
            int TransactionID = GenerateTransactionId();
            List<Cart> carts = CartRepository.GetCartByUserID(UserID);
            TransactionHeadersRepository.AddUnhandledTransaction(TransactionID, UserID, transactionDate);
            TransactionDetailsRepository.AddNewTransactionDetails(TransactionID, carts);
        }

        public static List<TransactionHeader> GetAllTransaction()
        {
            return TransactionHeadersRepository.GetAllTransaction();
        }

        public static List<TransactionHeader> GetTransactionsByUserID(int UserID)
        {
            return TransactionHeadersRepository.GetTransactionsByUserID(UserID);
        }

        public static List<TransactionDetail> GetTransactionsDetailsByTranID(int TransactionID)
        {
            return TransactionDetailsRepository.GetTransactionsDetailsByTranID(TransactionID);
        }

        public static List<TransactionHeader> GetTransactionsByStatus(String status)
        {
            return TransactionHeadersRepository.GetTransactionsByStatus(status);
        }

        public static void UpdateTransactionStatus(int TransactionID)
        {
            TransactionHeadersRepository.UpdateTransactionStatus(TransactionID);
        }

    }
}