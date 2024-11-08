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
    public partial class InsertMakeupBrand : System.Web.UI.Page
    {
        MakeupBrandRepository brandRepo = new MakeupBrandRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

            authenticateUser();
        }
        protected void BackBtn_Click(System.Object sender, System.EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeUp.aspx");
        }

        

        protected void InsertBtn_Click(System.Object sender, System.EventArgs e)
        {

            String brandName = BrandNameTB.Text;
            String ratingTb = BrandRatingTb.Text;
            Response<MakeupBrand> response = MakeupController.AddMakeupBrand(brandName, ratingTb);

            if(response.Success == false)
            {
                BrandErrorLbl.Text = response.Message;
                BrandErrorLbl.Visible = true;
                BrandErrorLbl.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Response.Redirect("~/Views/ManageMakeUp.aspx");
            
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