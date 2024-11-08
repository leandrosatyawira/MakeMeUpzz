using MakeMeUpzz_UAS.Controller;
using MakeMeUpzz_UAS.Dataset;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_UAS.Views
{
    public partial class ReportPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                authenticateUser();
                CrystalReport1 report1 = new CrystalReport1();
                CrystalReportViewer1.ReportSource = report1;

                List<TransactionHeader> transactions = TransactionsController.GetAllTransaction();
                DataSet1 data = GetData(transactions);
                report1.SetDataSource(data);
            }

        }

        private DataSet1 GetData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.Transaction;
            var detailTable = data.Detail;
            var GrandTotalTable = data.GrandTotal;
            int GrandTotal = 0;

            foreach(var t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["ID"] = t.TransactionID;
                hrow["Customer"] = t.User.Username;
                hrow["Date"] = t.TransactionDate;
                headerTable.Rows.Add(hrow);
                foreach(var d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["Item"] = d.Makeup.MakeupName;
                    drow["Quantity"] = d.Quantity;
                    drow["Price"] = d.Makeup.MakeupPrice * d.Quantity;
                    GrandTotal += d.Makeup.MakeupPrice * d.Quantity;
                    detailTable.Rows.Add(drow);
                }
            }
            var grow = GrandTotalTable.NewRow();
            grow["GrandTotal"] = GrandTotal;
            GrandTotalTable.Rows.Add(grow);

            return data;
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