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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                authenticateUser();
                user = (User)Session["user"];
                
                List<TransactionHeader> transactions = null;
                String userRole = user.UserRole.Trim();
                if (userRole.Equals("Admin", StringComparison.Ordinal))
                {
                    transactions = TransactionsController.GetAllTransaction();
                    MakeUserVisible();
                }
                else
                {
                    transactions = TransactionsController.GetTransactionsByUserID(user.UserID);
                }
                RoleLbl.Text = "Role: " + userRole;
                TransactionGV.DataSource = transactions;
                TransactionGV.DataBind();

            }
        }
        private void MakeUserVisible()
        {
            int count = 0;
            foreach (DataControlField column in TransactionGV.Columns)
            {
                BoundField boundField = column as BoundField;
                if (boundField != null && (boundField.DataField == "UserID"|| boundField.DataField == "User.Username"))
                {
                    boundField.Visible = true;
                    count++;
                }
                if(count >= 2)
                {
                    break;
                }
            }
        }

        protected void TransactionGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = TransactionGV.Rows[index];
            int TransactionID = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetails.aspx?id=" + TransactionID);
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