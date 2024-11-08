using MakeMeUpzz_UAS.Controller;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_UAS.Layouts
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        MakeMeUpzzEntities db = new MakeMeUpzzEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = null;
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
                {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }
            else if (Request.Cookies["user_cookie"] != null && Session["user"] == null)
            {
                string id = Request.Cookies["user_cookie"].Value;
                int ID = Convert.ToInt32(id);
                user = UserController.getUserByID(ID).Payload;
                Session["user"] = user;
            }
            else
            {
                //Get the logged-in user object from the session
                user = (User)Session["user"];
            }
            string userRole = user.UserRole.Trim();
            if (userRole.Equals("Admin", StringComparison.Ordinal))
            {
                ManageMakeupBtn.Visible = true;
                OrderQueueBtn.Visible = true;
                TransactionReportBtn.Visible = true;
                HistoryBtn.Visible = true;
                
            }
            else
            {
                OrderMakeUpBtn.Visible = true;
                HistoryBtn.Visible = true;
            }
        }

        
        protected void OrderMakeUpBtn_Click(object sender , EventArgs e)
        {
            Response.Redirect("~/Views/OrderMakeUp.aspx");
        }
        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Homepage.aspx");
        }
        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Views/Login.aspx");
        }

        protected void ManageMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeup.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/TransactionHistory.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void OrderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderQueue.aspx");
        }

        protected void TransactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ReportPage.aspx");
        }
    }
}