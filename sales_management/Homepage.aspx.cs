using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sales_management
{
    public partial class Homepage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["credential"] == null || Request.Cookies["credential"]["username"]==null)
            {
                Response.Redirect("Loginpage.aspx");
            }
            Label3.Text = Request.Cookies["credential"]["username"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSales.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateSales.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["credential"] != null)
            {
                HttpCookie ck = new HttpCookie("credential");
                Response.Cookies.Add(ck);
                Response.Redirect("Loginpage.aspx");
            }
        }
    }
}