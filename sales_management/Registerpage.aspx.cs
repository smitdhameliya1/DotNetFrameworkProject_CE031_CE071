using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace sales_management
{
    public partial class Registerpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\smitd\\source\\repos\\sales_management\\sales_management\\App_Data\\Register.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        protected void Button1_Click(object sender , EventArgs e)
        {
            string ins = "Insert into [Table](Name , Email_Id , Password) values('" + nametxt.Text + "' ,'" + emailtxt.Text + "' , '" + passtxt.Text + "')";
            SqlCommand com = new SqlCommand(ins, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
       }
    }
}