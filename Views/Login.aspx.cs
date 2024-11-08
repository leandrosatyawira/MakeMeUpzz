using MakeMeUpzz_UAS.Controller;
using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_UAS.Views
{
    public partial class Login : System.Web.UI.Page
    {

        MakeMeUpzzEntities db = new MakeMeUpzzEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
       protected void SubmitButton_Click(object sender, EventArgs e)
        {
            String username = UsernameTB.Text;
            String pass = PasswordTB.Text;
            Response<User> response = UserController.Login(username, pass);
            //authentication
            if (response.Success == false)
            {
                LblError.Text = response.Message;
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Visible = true;
            }
            else
            {
                Session["user"] = response.Payload;
                if (CBRememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = response.Payload.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                
                Response.Redirect("~/Views/Homepage.aspx");
            } 
        }
       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }

    }
}