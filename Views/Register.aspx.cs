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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UsersRepository usersRepository = new UsersRepository();
 
        
        protected void Submit_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String email = EmailTextBox.Text;
            String pass = PassTextBox.Text;
            String confirm_pass = Confirm_PassTextBox.Text;
            String Gender = DropDownGender.SelectedValue;
            DateTime DOB = CalendarDOB.SelectedDate;
            Response<User> response = UserController.register(username, email, DOB, Gender, "Customer", pass, confirm_pass);

            if (response.Success == false)
            {
                errorLabel.Text = response.Message;
                errorLabel.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                errorLabel.Text = "Success";
                errorLabel.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/Views/Login.aspx");
            }

        }

        protected void LBLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}