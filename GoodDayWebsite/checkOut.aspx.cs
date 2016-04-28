using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace GoodDayWebsite
{
    public partial class checkOut : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");
        int customerID;
        string subTotal;

        //For selecting Customer ID
        string customerEmail;
        string username;

        int lastOrderID;
        int orderID;

        DateTime localDate;

        string paymentID;
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

        protected void btn_Pay_Click(object sender, EventArgs e)
        {
            if (Session["ActiveEmail"] != null)
            {
                SelectOrderID();
                SelectCustomerID();

                //Insert Payment Details
                AddPaymentToDatabase();

                //Insert Order in Database
                AddOrderToDatabase();

                //Delete Shopping Cart Items
                DeleteShoppingCart();

                string myStringVariable = "Thank you for your purchase!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                SendInvoiceEmail();
                Response.Redirect("Default.aspx");
            }
        }

        private void AddPaymentToDatabase()
        {
            SqlCommand addInvoice = new SqlCommand("INSERT INTO PaymentMethod (OrderID, PaymentMethod, CardNumber, CardExpiryMonth, CardExpiryYear) VALUES (@OrderID, @PaymentMethod, @CardNumber, @CardExpiryMonth, @CardExpiryYear)", conn);

            addInvoice.Parameters.Add(new SqlParameter("@OrderID", orderID));
            addInvoice.Parameters.Add(new SqlParameter("@PaymentMethod", ddl_paymentMethod.SelectedValue));
            addInvoice.Parameters.Add(new SqlParameter("@CardNumber", txt_cardNumber.Text));
            addInvoice.Parameters.Add(new SqlParameter("@CardExpiryMonth", txt_cardExpiryMonth.Text));
            addInvoice.Parameters.Add(new SqlParameter("@CardExpiryYear", txt_cardExpiryYear.Text));

            conn.Open();
            addInvoice.ExecuteNonQuery();
            conn.Close();
        }

        private void AddOrderToDatabase()
        {
            SqlCommand addRecord = new SqlCommand("INSERT INTO [Order] (OrderID, CustomerID, DateOrdered, OrderStatus, PaymentID, FirstName, LastName, PostCode, HouseNumber, Street, Town, County, Phone) VALUES (@OrderID, @CustomerID, @DateOrdered, @OrderStatus, @PaymentID, @FirstName, @LastName, @PostCode, @HouseNumber, @Street, @Town, @County, @Phone)", conn);

            localDate = DateTime.Now;

            SelectPaymentID();

            //Also, to avoid SQL Injection, parameterized queries were used, rather than string concatenation.
            addRecord.Parameters.Add(new SqlParameter("@OrderID", orderID));
            addRecord.Parameters.Add(new SqlParameter("@CustomerID", customerID));
            addRecord.Parameters.Add(new SqlParameter("@DateOrdered", localDate));
            addRecord.Parameters.Add(new SqlParameter("@OrderStatus", "Pending"));
            addRecord.Parameters.Add(new SqlParameter("@PaymentID", paymentID));
            addRecord.Parameters.Add(new SqlParameter("@FirstName", txt_firstName.Text));
            addRecord.Parameters.Add(new SqlParameter("@LastName", txt_lastName.Text));
            addRecord.Parameters.Add(new SqlParameter("@PostCode", txt_postcode2.Text));
            addRecord.Parameters.Add(new SqlParameter("@HouseNumber", txt_houseNumber.Text));
            addRecord.Parameters.Add(new SqlParameter("@Street", txt_Street.Text));
            addRecord.Parameters.Add(new SqlParameter("@County", txt_County.Text));
            addRecord.Parameters.Add(new SqlParameter("@Town", txt_City.Text));
            addRecord.Parameters.Add(new SqlParameter("@Phone", txt_Phone.Text));

            conn.Open();
            addRecord.ExecuteNonQuery();
            conn.Close();
        }

        private void DeleteShoppingCart()
        {
            SelectCustomerID();
            SqlCommand deleteRecord = new SqlCommand("DELETE FROM ShoppingCart WHERE CustomerID=" + customerID + ";", conn);

            conn.Open();
            deleteRecord.ExecuteNonQuery();
            conn.Close();
        }

        private void SelectPaymentID()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SelectOrderID();
                cmd.CommandText = "SELECT PaymentId FROM PaymentMethod WHERE OrderID = " + orderID + ";";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt2 = new DataTable();
                    sda.Fill(dt2);
                    paymentID = dt2.Rows[0]["PaymentId"].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                    
                }
            }
        }

        private void SelectCustomerID()
        {
            customerEmail = Session["ActiveEmail"].ToString();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT UserId, Username FROM Users WHERE Email LIKE '%" + customerEmail + "';";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                    {
                        customerID = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                        Session["ActiveCustomerID"] = customerID;
                        username = dt.Rows[0]["Username"].ToString();
                    }
                }
            }
        }

        private void SelectOrderID()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT TOP 1 OrderID FROM [Order] ORDER BY OrderID DESC; ";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                    {
                        lastOrderID = Convert.ToInt32(dt.Rows[0]["OrderID"].ToString());
                    }
                }
            }

            orderID = lastOrderID + 1;
        }

        private void SendInvoiceEmail()
        {
            SelectCustomerID();
            using (MailMessage mm = new MailMessage("SDIAF1415@gmail.com", Session["ActiveEmail"].ToString()))
            {
                mm.Subject = "Good Day Coffee Invoice";
                string body = "Hello " + username.Trim() + ",";
                body += "<br /><br />Note: This is an auto-generated message. Please do not respond to it!";
                body += "<br /> Thank you for your recent purchase.";
                body += "<br /><br /> Order Number: " + orderID;
                body += "<br /> Date: " + localDate;
                body += "<br /> Total: " + lbl_OrderTotal.Text;
                body += "<br /><br /> Thank you again for your purchase!";
                body += "<br /> <b> Good Day Coffee </b>";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("SDIAF1415@gmail.com", "Software1415");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}