using MakeMeUpzz_UAS.Controller;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace MakeMeUpzz_UAS.Views
{
    public partial class OrderQueue : System.Web.UI.Page
    {
        TransactionHeadersRepository headersRepository = new TransactionHeadersRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                RefreshGV();
            }
            
        }

        private void authenticateUser()
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }
            else if (Request.Cookies["user_cookie"] != null && Session["user"] == null)
            {
                string id = Request.Cookies["user_cookie"].Value;
                int ID = Convert.ToInt32(id);
                Response<User> user1 = UserController.getUserByID(ID);
                Session["user"] = user1.Payload;

            }
        }

        protected void UnhandledGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = UnhandledGV.Rows[index];
            int TransactionID = Convert.ToInt32(row.Cells[0].Text);
            TransactionsController.UpdateTransactionStatus(TransactionID);
            RefreshGV();
        }

        private void RefreshGV()
        {
            List<TransactionHeader> handledTransactions = TransactionsController.GetTransactionsByStatus("Handled");
            List<TransactionHeader> unhandledTransactions = TransactionsController.GetTransactionsByStatus("Unhandled");
            HandledGV.DataSource = handledTransactions;
            HandledGV.DataBind();

            UnhandledGV.DataSource = unhandledTransactions;
            UnhandledGV.DataBind();
        }
    }
}