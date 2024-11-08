using MakeMeUpzz_UAS.Controller;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_UAS.Views
{
    public partial class Homeaspx : System.Web.UI.Page
    {
        MakeMeUpzzEntities db = new MakeMeUpzzEntities();
        protected void Page_Load(object sender, EventArgs e)
        {   
            // buat liat role
            if (!IsPostBack)
            {
                authenticateUser();
                User user = (User)Session["user"]; ;
                Response<List<User>> response = UserController.GetAllUsers();
                GridView1.DataSource = response.Payload;
                GridView1.DataBind();

                LblLoggedInUser.Text = $"Welcome, {user.UserRole} { user.Username}";
                LblLoggedInUser.Visible = true;
                string userRole = user.UserRole.Trim();
                if (userRole.Equals("Admin", StringComparison.Ordinal))
                {
                    GridView1.Visible = true;
                }
            } //-----------------               
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