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
    
    public partial class AllCoffees : System.Web.UI.Page
    {
        string DisplayCoffee;
        string coffeeType;
        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");

        public void Page_Load(object sender, EventArgs e)
        {
            //For Home codes in clicking the images
            coffeeType = Request.QueryString["coffeeType"];
            if (coffeeType != null)
            {
                DisplayCoffee = coffeeType;
            }
            else if (Session["DisplayCoffee"] != null)
            {
                DisplayCoffee = (String)Session["DisplayCoffee"];
            }

            if (!this.IsPostBack)
            {
                this.BindListView();
            }
            lbl_CoffeeType.Text = DisplayCoffee + " ";
            lbl_breadcrumbCurrent.Text = DisplayCoffee + " ";
            

        }
        private void BindListView()
        {
                using (SqlCommand cmd = new SqlCommand())
                {
                if (DisplayCoffee == "All")
                {
                    cmd.CommandText = "SELECT * FROM Coffee;";
                }
                else if(DisplayCoffee == "Mild")
                {
                    cmd.CommandText = "SELECT * FROM Coffee WHERE CoffeeStrength Between 0 AND 4 ;";
                }
                else if (DisplayCoffee == "Medium")
                {
                    cmd.CommandText = "SELECT * FROM Coffee WHERE CoffeeStrength Between 5 AND 7;";
                }
                else if (DisplayCoffee == "Strong")
                {
                    cmd.CommandText = "SELECT * FROM Coffee WHERE CoffeeStrength Between 8 AND 10;";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Coffee WHERE CoffeeType LIKE '%" + DisplayCoffee + "';";

                }
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                    LVcoffees.DataSource = dt;
                    LVcoffees.DataBind();

                }
                }
            }

        protected void ddl_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (ddl_SortBy.SelectedValue == "A-Z")
                {
                    cmd.CommandText = "SELECT * FROM Coffee ORDER BY CoffeeName;";
                }
                else if (ddl_SortBy.SelectedValue == "Z-A")
                {
                    cmd.CommandText = "SELECT * FROM Coffee ORDER BY CoffeeName Desc;";
                }
                else if (ddl_SortBy.SelectedValue == "Low-High")
                {
                    cmd.CommandText = "SELECT * FROM Coffee ORDER BY CoffeePrice;";
                }
                else if (ddl_SortBy.SelectedValue == "High-Low")
                {
                    cmd.CommandText = "SELECT * FROM Coffee ORDER BY CoffeePrice Desc;";
                }
                else if (ddl_SortBy.SelectedValue == "Mild-Strong")
                {
                    cmd.CommandText = "SELECT * FROM Coffee ORDER BY CoffeeStrength;";
                }
                else if (ddl_SortBy.SelectedValue == "Strong-Mild")
                {
                    cmd.CommandText = "SELECT * FROM Coffee ORDER BY CoffeeStrength Desc;";
                }
                else if (ddl_SortBy.SelectedValue == "Origin")
                {
                    cmd.CommandText = "SELECT * FROM Coffee GROUP BY CoffeeOrigin;";
                }

                cmd.Connection = conn;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    LVcoffees.DataSource = dt;
                    LVcoffees.DataBind();
                }
            }
        }
    }
}