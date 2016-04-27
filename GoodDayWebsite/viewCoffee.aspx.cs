using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace GoodDayWebsite
{
    public partial class viewCoffee : System.Web.UI.Page
    {
        //For selecting coffee
        string coffeeID;
        string coffeeName;
        string coffeeType;
        int coffeeStrength;
        string coffeeOrigin;
        string coffeePrice;
        string coffeeImage;
        string coffeeQuantity;
        string coffeeDesc;
        string coffeeImageLoc;

        //For selecting Customer ID
        string customerEmail;
        int customerID;

        //For calculating ItemTotal
        decimal itemTotal;

        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            coffeeID = Request.QueryString["coffeeID"];
            if (coffeeID != null)
            {
                BindCoffeeView();
                lbl_SelectedCoffee.Text = coffeeName;
                if (Session["DisplayCoffee"] != null)
                {
                    coffeeType = Session["DisplayCoffee"].ToString();
                }
                lbl_breadcrumbCoffee.Text = coffeeType;
                lbl_breadcrumbCurrent.Text = coffeeName;
                lbl_coffeeDesc.Text = coffeeDesc;
                lbl_coffeePrice.Text = "£" + coffeePrice;
                lbl_coffeeOrigin.Text = coffeeOrigin;
                if (Session["ActiveEmail"] != null)
                {
                    lbl_QuantityStock.Text = "(" + coffeeQuantity + " left in stock.)";
                }
            }
        }

        private void BindCoffeeView()
        {

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Coffee WHERE CoffeeId =" + coffeeID + ";";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                    {

                        coffeeName = dt.Rows[0]["CoffeeName"].ToString(); // Where Fieldname is the name of fields from your database that you want to get
                        coffeeType = dt.Rows[0]["CoffeeType"].ToString();
                        //coffeeStrength = dt.Rows[0]["CoffeeStrength"].ToString();
                        coffeeOrigin = dt.Rows[0]["CoffeeOrigin"].ToString();
                        coffeePrice = dt.Rows[0]["CoffeePrice"].ToString();
                        //coffeeImage = dt.Rows[0]["CoffeeImage"].ToString();
                        coffeeDesc = dt.Rows[0]["CoffeeDesc"].ToString();
                        coffeeImageLoc = dt.Rows[0]["CoffeeImageLoc"].ToString();
                        coffeeQuantity = dt.Rows[0]["CoffeeQuantity"].ToString();

                        if (!Convert.IsDBNull(dt.Rows[0]["CoffeeImage"]))
                        {
                            //byte[] MyData = new byte[0];
                            byte[] MyData = (byte[])dt.Rows[0]["CoffeeImage"];
                            string base64String = Convert.ToBase64String(MyData, 0, MyData.Length);
                            IM_CoffeeImage.ImageUrl = "data:image/png;base64," + base64String;
                        }

                        if (!Convert.IsDBNull(dt.Rows[0]["CoffeeStrength"]))
                        {
                            coffeeStrength = Convert.ToInt32(dt.Rows[0]["CoffeeStrength"].ToString());
                            if (coffeeStrength <= 4)
                            {
                                IM_Strength.ImageUrl = "~/images/Strength/Weak.jpg";
                            }
                            else if (coffeeStrength >= 5 && coffeeStrength <= 7)
                            {
                                IM_Strength.ImageUrl = "~/images/Strength/Medium.jpg";
                            }
                            else if (coffeeStrength >= 8 && coffeeStrength <= 10)
                            {
                                IM_Strength.ImageUrl = "~/images/Strength/Strong.jpg";
                            }

                        }

                    }
                }
            }


        }

        protected void btn_AddtoCart_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(coffeeQuantity) < Convert.ToInt32(txt_Quantity.Text))
            {
                CheckQuantityStock();
            }
            else
            {
                if (Session["ActiveEmail"] != null)
                {
                    SelectCustomerID();
                    SqlCommand addRecord = new SqlCommand("INSERT INTO ShoppingCart (CustomerID, CoffeeID, CoffeeName, CoffeeImageLoc, Quantity, Price, Grind, ItemTotal) VALUES (@CustomerID, @CoffeeID, @CoffeeName, @CoffeeImageLoc, @Quantity, @Price, @Grind, @ItemTotal)", conn);


                    itemTotal = Convert.ToDecimal(coffeePrice) * Convert.ToDecimal(txt_Quantity.Text);

                    //Also, to avoid SQL Injection, parameterized queries were used, rather than string concatenation.
                    addRecord.Parameters.Add(new SqlParameter("@CustomerID", customerID));
                    addRecord.Parameters.Add(new SqlParameter("@CoffeeID", coffeeID));
                    addRecord.Parameters.Add(new SqlParameter("@CoffeeName", coffeeName));
                    addRecord.Parameters.Add(new SqlParameter("@CoffeeImageLoc", coffeeImageLoc));
                    addRecord.Parameters.Add(new SqlParameter("@Quantity", txt_Quantity.Text));
                    addRecord.Parameters.Add(new SqlParameter("@Price", coffeePrice));
                    addRecord.Parameters.Add(new SqlParameter("@Grind", ddl_CoffeeGrind.SelectedValue));
                    addRecord.Parameters.Add(new SqlParameter("@ItemTotal", itemTotal));

                    conn.Open();
                    addRecord.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("AddToCart.aspx");
                }
                else
                {
                    lbl_Login.Visible = true;
                    lbl_OR.Visible = true;
                    lbl_SignUp.Visible = true;
                    lbl_alertSignIn.Visible = true;
                }
            }
        }
    
        private void CheckQuantityStock()
        {
                btn_AddtoCart.Enabled = false;
                lbl_QunatityError.Visible = true;
                btn_UpdateMe.Visible = true;
                Label1.Visible = true;
                btn_StartAgain.Visible = true;
                if (Session["ActiveEmail"] == null)
                {
                    lbl_Login.Visible = true;
                    lbl_OR.Visible = true;
                    lbl_SignUp.Visible = true;
                    lbl_alertQuantity.Visible = true;
                    btn_UpdateMe.Enabled = false;
                }
        }


        private void SelectCustomerID()
        {
            customerEmail = Session["ActiveEmail"].ToString();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT UserId FROM Users WHERE Email LIKE '%" + customerEmail + "';";
                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                    {

                        customerID = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                        Session["ActiveCustomerID"] = customerID;
                    }
                }
            }
        }

        protected void btn_UpdateMe_Click(object sender, EventArgs e)
        {
            if (Session["ActiveEmail"] != null)
            {
                SqlCommand addRecord = new SqlCommand("INSERT INTO UpdateEmail VALUES (@CoffeeID, @EmailAddress)", conn);
                
                //Also, to avoid SQL Injection, parameterized queries were used, rather than string concatenation.
                addRecord.Parameters.Add(new SqlParameter("@CoffeeID", coffeeID));
                addRecord.Parameters.Add(new SqlParameter("@EmailAddress", Session["ActiveEmail"].ToString()));

                conn.Open();
                addRecord.ExecuteNonQuery();
                conn.Close();
                string myStringVariable = "We will email you once coffee has been stocked";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btn_StartAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewCoffee.aspx?coffeeID=" + coffeeID); 
        }
    }
}