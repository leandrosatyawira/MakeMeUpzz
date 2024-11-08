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
    public partial class ManageMakeup : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                refreshGV();
                
            }
        }

        protected void refreshGV()
        {
            List<Makeup> makeup = MakeupController.GetAllMakeup().Payload;
            List<MakeupBrand> makeupBrands = MakeupController.GetAllMakeupBrandSortedByRating().Payload;
            List<MakeupType> makeupTypes = MakeupController.GetAllMakeupType().Payload;

            MakeupGV.DataSource = makeup;
            MakeupGV.DataBind();

            MakeupTypeGV.DataSource = makeupTypes;
            MakeupTypeGV.DataBind();

            MakeupBrandGV.DataSource = makeupBrands;
            MakeupBrandGV.DataBind();
        }

        protected void MakeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupController.DeleteMakeupByID(id);
            refreshGV();
        }

        protected void MakeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeup.aspx?id=" + id);
        }

        protected void MakeupTypeGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupTypeGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupController.DeleteMakeupTypeByID(id);
            refreshGV();
        }

        protected void MakeupTypeGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTypeGV.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupType.aspx?id=" + id);
        }

        protected void MakeupBrandGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupBrandGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            MakeupController.DeleteMakeupBrandByID(id);
            refreshGV();
        }

        protected void MakeupBrandGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBrandGV.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateMakeupBrand.aspx?id=" + id);
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeup.aspx");
        }

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupType.aspx");
        }

        protected void InsertmakeupBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrand.aspx");
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