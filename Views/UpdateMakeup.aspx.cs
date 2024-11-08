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
    public partial class UpdateMakeup : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                authenticateUser();

                if(Request.QueryString["id"] == null)
                {
                    Response.Redirect("~/Views/ManageMakeup.aspx");
                }
                

                List<int> typeID = MakeupController.GetAllMakeupTypeID();
                List<int> brandID = MakeupController.GetAllMakeupBrandID();

                TypeIdDropDown.DataSource = typeID;
                TypeIdDropDown.DataBind();

                BrandIdDropdown.DataSource = brandID;
                BrandIdDropdown.DataBind();

                int MakeupID = Convert.ToInt32(Request.QueryString["id"]);

                Makeup makeup = MakeupController.GetMakeupByID(MakeupID).Payload;

                NameTB.Text = makeup.MakeupName;
                PriceTB.Text = makeup.MakeupPrice.ToString();
                WeightTB.Text = makeup.MakeupWeight.ToString();
                TypeIdDropDown.SelectedValue = makeup.MakeupTypeID.ToString();
                BrandIdDropdown.SelectedValue = makeup.MakeupBrandID.ToString();
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
            Response.Redirect("~/Views/ManageMakeup.aspx");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String MakeupName = NameTB.Text;
            String priceTB = PriceTB.Text;
            String weightTB = WeightTB.Text;
            String selectedType = TypeIdDropDown.SelectedValue;
            String selectedBrand = BrandIdDropdown.SelectedValue;
            int MakeupID = Convert.ToInt32(Request.QueryString["id"]);

            Response<Makeup> response = MakeupController.UpdateMakeup(MakeupID, MakeupName, priceTB, weightTB, selectedType, selectedBrand);
            if (response.Success == false)
            {
                AlertLbl.Text = response.Message;
                AlertLbl.Visible = true;
                AlertLbl.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Response.Redirect("~/Views/ManageMakeup.aspx");
        }
    }
}