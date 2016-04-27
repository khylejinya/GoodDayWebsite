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
    public partial class Default : System.Web.UI.Page
    {
        string userName;
        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["ActiveEmail"] = "khylejinya10@yahoo.co.uk";
            //Session["ActiveCustomerID"] = 1;

            if (Session["userName"] != null)
            {
                userName = Session["userName"].ToString();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Username ='" + userName + "';";
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                        {
                            string userEmail = dt.Rows[0]["Email"].ToString();
                            Session["ActiveEmail"] = userEmail;
                            string userID = dt.Rows[0]["UserId"].ToString();
                            Session["ActiveCustomerID"] = userID;
                        }
                    }
                }
            }
        }
    }
}