using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodDayWebsite
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ActiveEmail"] != null)
            {
                LoginTop.Text = "Hello, <a href='#'>" + Session["ActiveEmail"].ToString() + "</a>, <a href='Logout.aspx'>Logout</a>";
            }
        }
    }
}