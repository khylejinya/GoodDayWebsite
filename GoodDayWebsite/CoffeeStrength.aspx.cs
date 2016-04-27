using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodDayWebsite
{
    public partial class CoffeeStrength : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LB_AllCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "All";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_StrongCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "Strong";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_MediumCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "Medium";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_MildCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "Mild";
            Response.Redirect("ListCoffees.aspx");
        }
    }
}