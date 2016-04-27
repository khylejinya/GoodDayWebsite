using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace GoodDayWebsite
{
    public partial class Signup : System.Web.UI.Page
    {
        //SqlConnection conn = new SqlConnection("Data Source=KHYLE-PC;Initial Catalog=GoodDayCoffee;Integrated Security=True;Pooling=False");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_Click(object sender, EventArgs e)
        {
           
        }

        public void OnConfirm(object sender, EventArgs e)
        {
            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
            //    SqlCommand addUser = new SqlCommand("INSERT INTO Users (Email, Password) VALUES (@UserEmail, @Password)", conn);

            //    //Also, to avoid SQL Injection, parameterized queries were used, rather than string concatenation.
            //    addUser.Parameters.Add(new SqlParameter("@UserEmail", emailAddress.Text));
            //    addUser.Parameters.Add(new SqlParameter("@Password", password.Text));

            //    conn.Open();
            //    addUser.ExecuteNonQuery();
            //    conn.Close();

            //    string myStringVariable = "Have a Good Day, " + emailAddress.Text + "!";
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

            //    Session["ActiveEmail"] = emailAddress.Text;
            ////    Response.Redirect("Default.aspx");
            //}
            //else
            //{
            //    //do nothing
            //}
        }


        protected void RegisterUser(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["GoodDayCoffeeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.Add(new SqlParameter("@Username", username.Text));
                        cmd.Parameters.Add(new SqlParameter("@Email", emailAddress.Text));
                        cmd.Parameters.Add(new SqlParameter("@Password", password.Text));
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "Username already exists.\\nPlease choose a different username.";
                        break;
                    case -2:
                        message = "Supplied email address has already been used.";
                        break;
                    default:
                        message = "Registration successful. Activation email has been sent.";
                        SendActivationEmail(userId);
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                Response.Redirect("Default.aspx");
            }
        }
        private void SendActivationEmail(int userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["GoodDayCoffeeConnectionString"].ConnectionString;
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @Username, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@Username", username.Text);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            using (MailMessage mm = new MailMessage("SDIAF1415@gmail.com", emailAddress.Text))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + username.Text.Trim() + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Signup.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
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