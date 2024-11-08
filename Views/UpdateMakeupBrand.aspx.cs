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
    public partial class UpdateMakeupBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }
                int BrandId = Convert.ToInt32(Request.QueryString["id"]);
                MakeupBrand brand = MakeupBrandRepository.GetMakeupBrandByID(BrandId);
                BrandNameTB.Text = brand.MakeupBrandName;
                BrandRatingTB.Text = brand.MakeupBrandRating.ToString();
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

        protected void UpdateBrandBtn_Click(object sender, EventArgs e)
        {
            String brandName = BrandNameTB.Text;
            String ratingTb = BrandRatingTB.Text;
            int Tid = Convert.ToInt32(Request.QueryString["id"]);
            Response<MakeupBrand> response = MakeupController.UpdateMakeUpBrandByID(Tid, brandName, ratingTb);

            if (response.Success == false)
            {
                UpdateErrorLbl.Text = response.Message;
                UpdateErrorLbl.Visible = true;
                UpdateErrorLbl.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Response.Redirect("~/Views/ManageMakeUp.aspx");
            
        }
    }
}