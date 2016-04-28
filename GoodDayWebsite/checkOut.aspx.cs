using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace GoodDayWebsite
{
    public partial class checkOut : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");
        int customerID;
        string subTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(Session["ActiveCustomerID"]);
            if (!this.IsPostBack)
            {
                this.BindCoffeeCart();
                CalculateSubTotal();
            }
        }
        private void BindCoffeeCart()
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT CoffeeName, Grind, Quantity, Price, ItemTotal FROM ShoppingCart WHERE CustomerID = " + customerID + ";";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dg_checkout.DataSource = dt;
                    dg_checkout.DataBind();
                }
            }
        }

        private void CalculateSubTotal()
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT SUM(ItemTotal) AS [SubTotal] FROM ShoppingCart WHERE CustomerID = " + customerID + ";";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt2 = new DataTable();
                    sda.Fill(dt2);
                    subTotal = dt2.Rows[0]["SubTotal"].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                    lbl_OrderTotal.Text = "£" + subTotal;
                }
            }
        }
        protected void btn_FindAddress_click(object sender, EventArgs e)
        {

        }
    }
}