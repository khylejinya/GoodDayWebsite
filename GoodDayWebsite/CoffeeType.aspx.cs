using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodDayWebsite
{
    public partial class CoffeeType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LB_BlendedCoffee_Click(object sender, EventArgs e)
        {
            //LinkButton btn = (LinkButton)sender;
            Session["DisplayCoffee"] = "Blended";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_DecafCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "Decaffeinated";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_FlavCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "Flavoured";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_OrigCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "Origin";
            Response.Redirect("ListCoffees.aspx");
        }

        protected void LB_AllCoffee_Click(object sender, EventArgs e)
        {
            Session["DisplayCoffee"] = "All";
            Response.Redirect("ListCoffees.aspx");
        }
    }
}