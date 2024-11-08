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
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                User user = (User)Session["user"];
                if (user != null)
                {
                    DateTime tanggal = user.UserDOB;
                    UsernameTxtBox.Text = user.Username.Trim();
                    EmailTxtBox.Text = user.UserEmail.Trim();
                    DropDownGender.SelectedValue = user.UserGender;
                    DOBTxtBox.Text = user.UserDOB.ToString("yyyy-MM-dd");
                }
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
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            String Username = UsernameTxtBox.Text.Trim();
            String UserEmail = EmailTxtBox.Text.Trim();
            String UserGender = DropDownGender.SelectedValue.Trim();
            String DOB = DOBTxtBox.Text.Trim();
            Response<User> response = UserController.UpdateProfile(user.UserID, Username, UserEmail, UserGender, DOB);
           if(response.Success == false)
            {
                errorLabel.Text = response.Message;
                errorLabel.ForeColor = System.Drawing.Color.Red;
                errorLabel.Visible = true;
            }
            else
            {
                Response.Redirect("~/Views/Homepage.aspx");
            }
        }
        protected void Change_PassBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            String OldPass = OldPassTxtBox.Text.Trim();
            String Change_Pass1 = Change_Pass1TxtBox.Text.Trim();
            String Change_Pass2 = Change_Pass2TxtBox.Text.Trim();
            Response<User> response = UserController.UpdatePass(OldPass, Change_Pass1, Change_Pass2, user);
            if (response.Success == false)
            {
                errorLabelPassword.Text = response.Message;
                errorLabelPassword.ForeColor = System.Drawing.Color.Red;
                errorLabelPassword.Visible = true;
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }

        }
    }
}