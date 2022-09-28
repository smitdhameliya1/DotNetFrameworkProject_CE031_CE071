using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Configuration;

namespace sales_management
{
    public partial class Registerpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
         
        protected void Button1_Click(object sender , EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string ins = "Insert into [Table](Name , Email_Id , Password) values('" + nametxt.Text + "' ,'" + emailtxt.Text + "' , '" + passtxt.Text + "')";
            SqlCommand com = new SqlCommand(ins, con);

            con.Open();
            try
            {

                com.ExecuteNonQuery();
                HttpCookie ck = Request.Cookies["credential"];
                if (ck == null)
                {
                    ck = new HttpCookie("credential");
                    ck["username"] = nametxt.Text;
                }
                else
                {
                    ck["username"] = nametxt.Text;
                }


                con.Close();
                Response.Redirect("Loginpage.aspx");
            }
            catch
            {
                Response.Write("Username already exists!");
            }
           



          
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
       }
    }
}