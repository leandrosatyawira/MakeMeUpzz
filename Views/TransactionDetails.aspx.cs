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

namespace MakeMeUpzz_UAS.Views
{
    public partial class TransactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                if(Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/Views/TransactionHistory.aspx");
                }
                int TransactionID = Convert.ToInt32(Request.QueryString["id"]);
                List<TransactionDetail> details = TransactionsController.GetTransactionsDetailsByTranID(TransactionID);
                TranDetailGV.DataSource = details;
                TranDetailGV.DataBind();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
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
    }
}