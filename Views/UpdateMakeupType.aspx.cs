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
    public partial class UpdateMakeupType : System.Web.UI.Page
    {
        UsersRepository usersRepository = new UsersRepository();
        MakeupTypeRepository TypeRepo = new MakeupTypeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }
                int Tid = Convert.ToInt32(Request.QueryString["id"]);
                MakeupType type = MakeupTypeRepository.GetMakeupTypeByID(Tid);
                TypeNameTB.Text = type.MakeupTypeName;

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
        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {

            String MakeupTypeName = TypeNameTB.Text;
            int Tid = Convert.ToInt32(Request.QueryString["id"]);
            Response<MakeupType> response = MakeupController.UpdateMakeupTypeByID(Tid, MakeupTypeName);
            if (response.Success == false)
            {
                UpdateErrorLbl.Text = response.Message;
                UpdateErrorLbl.Visible = true;
                UpdateErrorLbl.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                Response.Redirect("~/Views/ManageMakeup.aspx");
            }
        }
    }
}