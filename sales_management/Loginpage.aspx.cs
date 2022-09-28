using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;

namespace sales_management
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string check = "select count(*) from [Table] where Name = '" + usertxt.Text + "' and Password = '" + passtxt.Text + "' ";
            SqlCommand com = new SqlCommand(check, con);
            con.Open();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                string name = usertxt.Text;
                HttpCookie ck = Request.Cookies["credential"];
                if (ck == null)
                {
                    ck = new HttpCookie("credential");
                    ck["username"] = name;
                    Response.Cookies.Add(ck);
                }
                else
                {
                    ck = new HttpCookie("credential");
                    ck["username"] = name;
                    Response.Cookies.Add(ck);
                }
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Text = "Your Email_Id or Password is invalid";
            }
        }
    }
}