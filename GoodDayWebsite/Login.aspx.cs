using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;


namespace GoodDayWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");

        protected void ValidateUser(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string password = Login1.Password;

            bool result = UserLogin(userName, password);
            if ((result))
            {
                if (result == true)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT Username FROM UserActivation WHERE Username ='" + userName + "';";
                        cmd.Connection = conn;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0) // Check if the DataTable returns any data from database
                            {
                                string myStringVariable = "Account has not been activated.";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                            }
                            else
                            {
                                e.Authenticated = true;
                                Session["userName"] = Login1.UserName;
                                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                                //Response.Redirect("Default.aspx");
                            }
                        }

                    }
                }
                else
                {
                    e.Authenticated = false;

                    string myStringVariable = "Invalid username or password";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                }
            }
        }



        private bool UserLogin(string userName, string password)
        {

            // read the coonection string from web.config 
            string conString = ConfigurationManager.ConnectionStrings["GoodDayCoffeeConnectionString"].ConnectionString;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conString))
            {
                //' declare the command that will be used to execute the select statement 
                SqlCommand com = new SqlCommand("SELECT Username FROM Users WHERE Username = @UserName AND Password = @Password", con);

                // set the username and password parameters
                com.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                com.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;

               
                    con.Open();
                    //' execute the select statment 
                    string result = Convert.ToString(com.ExecuteScalar());
                    //' check the result 
                    if (string.IsNullOrEmpty(result))
                    {
                        //invalid user/password , return flase 
                        return false;
                    }
                    else
                    {
                        // valid login
                        return true;
                    }
               

            }
        }
    }
}