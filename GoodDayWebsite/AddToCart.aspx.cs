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
    public partial class AddToCart : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");

        int customerID;
        string subTotal;

        string newQuantity;
        decimal coffeePrice;
        decimal itemTotal;

        string cartID;

        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Convert.ToInt32(Session["ActiveCustomerID"]);
            if (!this.IsPostBack)
            {
                this.BindListView();
                CalculateSubTotal();
            }
        }

        private void BindListView()
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM ShoppingCart WHERE CustomerID = " + customerID + ";";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    lvCustomers.DataSource = dt;
                    lvCustomers.DataBind();

                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    if (dt.Rows[0]["Id"].ToString() != null)
                    //    {
                    //        coffeePrice = Convert.ToDecimal(dt.Rows[0]["Price"].ToString());
                    //    }
                    //}
                    
                }
            }
        }
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvCustomers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView();
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
                    lbl_subTotal.Text = "£" + subTotal;
                }
            }
        }
        
        

        protected void lvCustomers_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            cartID = "";
            Label lbl = (lvCustomers.Items[e.ItemIndex].FindControl("cartID")) as Label;
            if (lbl != null)
            cartID = lbl.Text;
           
            SqlCommand deleteRecord = new SqlCommand("DELETE FROM ShoppingCart WHERE Id LIKE '" + cartID + "';", conn);
            conn.Open();
            deleteRecord.ExecuteNonQuery();
            conn.Close();

            //Delete Order Item
            SqlCommand deleteRecord2 = new SqlCommand("DELETE FROM OrderItem WHERE Id LIKE '" + cartID + "';", conn);
            conn.Open();
            deleteRecord2.ExecuteNonQuery();
            conn.Close();

            lvCustomers.EditIndex = -1;


            this.BindListView();
            CalculateSubTotal();
        }

        protected void lvCustomers_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            cartID = "";
            newQuantity = "";

            Label lbl = (lvCustomers.Items[e.ItemIndex].FindControl("cartID")) as Label;
            if (lbl != null)
                cartID = lbl.Text;
            Label lbl2 = (lvCustomers.Items[e.ItemIndex].FindControl("coffeePrice")) as Label;
            if (lbl2 != null)
                coffeePrice = Convert.ToDecimal(lbl2.Text);
            TextBox txt = (lvCustomers.Items[e.ItemIndex].FindControl("txt_Quantity")) as TextBox;
            if (txt != null)
                newQuantity = txt.Text;
                

            itemTotal = coffeePrice * Convert.ToDecimal(newQuantity);

            SqlCommand updateDetails = new SqlCommand("UPDATE ShoppingCart SET Quantity=@Quantity, Price=@Price, ItemTotal=@ItemTotal WHERE Id=@Id;", conn);
            updateDetails.Parameters.Add(new SqlParameter("@Quantity", newQuantity));
            updateDetails.Parameters.Add(new SqlParameter("@Price", coffeePrice));
            updateDetails.Parameters.Add(new SqlParameter("@ItemTotal", itemTotal));
            updateDetails.Parameters.Add(new SqlParameter("@Id", cartID));

            conn.Open();
            updateDetails.ExecuteNonQuery();
            conn.Close();

            //Update Order Items
            SqlCommand updateDetails2 = new SqlCommand("UPDATE OrderItem SET Quantity=@Quantity, Price=@Price, Total=@ItemTotal WHERE Id=@Id;", conn);
            updateDetails2.Parameters.Add(new SqlParameter("@Quantity", newQuantity));
            updateDetails2.Parameters.Add(new SqlParameter("@Price", coffeePrice));
            updateDetails2.Parameters.Add(new SqlParameter("@ItemTotal", itemTotal));
            updateDetails2.Parameters.Add(new SqlParameter("@Id", cartID));

            conn.Open();
            updateDetails2.ExecuteNonQuery();
            conn.Close();


            this.BindListView();
            CalculateSubTotal();
        }

        protected void btn_Checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkOut.aspx");
        }
    }
}