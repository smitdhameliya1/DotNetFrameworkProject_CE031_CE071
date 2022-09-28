using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace sales_management
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["credential"] == null || Request.Cookies["credential"]["username"] == null)
            {
                Response.Redirect("Loginpage.aspx");
            }
            /* SqlConnection con = new SqlConnection();
             con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
             try
             {
                 using(con)
                 {
                     string command = "select * from product_table";
                     SqlCommand cmd = new SqlCommand(command, con);  
                     con.Open();
                     SqlDataReader rdr = cmd.ExecuteReader();
                     GridViewProduct.DataSource = rdr;
                     GridViewProduct.DataBind();
                     rdr.Close();

                 }
             }
             catch(Exception ex)
             {
                 Response.Write("Errors : " + ex.Message);
             }*/

        }

        protected void GridViewProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
                
        }

        protected void GridViewProduct_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridViewProduct_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridViewProduct_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}