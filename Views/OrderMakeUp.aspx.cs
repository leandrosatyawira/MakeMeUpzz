using MakeMeUpzz_UAS.Controller;
using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Handler;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_UAS.Views
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                User user = (User)Session["user"];

                if (user.UserRole.Trim().Equals("Admin"))
                {
                    Response.Redirect("~/Views/Homepage.aspx");
                }

                List<Makeup> makeups = MakeupController.GetAllMakeup().Payload;
                MakeupGV.DataSource = makeups;
                MakeupGV.DataBind();

                RefreshCartGV();
            }
        }

        public void RefreshCartGV()
        {
            User user = (User)Session["user"];
            List<Cart> carts = CartController.GetCartByUserID(user.UserID);
            CartGridview.DataSource = carts;
            CartGridview.DataBind();
        }


        protected void MakeupGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = MakeupGV.Rows[index];
            TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
            Label lblMakeupID = (Label)row.FindControl("lblMakeupID");
            String quantityTB = txtQuantity.Text;
            String makeupIDlbl = lblMakeupID.Text;
            User user = (User)Session["user"];
            int UserID = user.UserID;

            Response<Cart> response = CartController.UpdateCart(quantityTB, makeupIDlbl, UserID);

            if(response.Success == false)
            {
                Alert.Text = response.Message;
                Alert.Visible = true;
                Alert.ForeColor = System.Drawing.Color.Red;
                return;
            }
            RefreshCartGV();
            txtQuantity.Text = "";
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            ClearCart();
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int userID = user.UserID;
            TransactionsController.AddUnhandledTransaction(userID);
            ClearCart();
            
        }

        protected void ClearCart()
        {
            User user = (User)Session["user"];
            int userID = user.UserID;
            CartHandler.DeleteCartByUserID(userID);
            RefreshCartGV();
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