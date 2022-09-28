using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sales_management
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smitd\\source\\repos\\sales_management\\sales_management\\App_Data\\Register.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["credential"] == null || Request.Cookies["credential"]["username"]==null)
            {
                Response.Redirect("Loginpage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "Insert into [product_table](product_name, quantity, cost_price, sell_price) values('" + prod_name.Text + "' ," + prod_quantity.Text + " , " + prod_costprice.Text + "," + prod_sellprice.Text + ")";
            SqlCommand com = new SqlCommand(ins, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            prod_costprice.Text = "";
            prod_name.Text = "";
            prod_quantity = null;
            prod_sellprice = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}