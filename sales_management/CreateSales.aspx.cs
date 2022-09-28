using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sales_management
{
    public partial class CreateSales : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["credential"] == null || Request.Cookies["credential"]["username"] == null)
            {
                Response.Redirect("Loginpage.aspx");
            }
            string ins = "";

            if (DropDownList1.Items.Count != 0)
            {
                string product_name = DropDownList1.SelectedItem.ToString();
                ins = "select TOP 1 product_id, product_name, quantity, cost_price, sell_price from [product_table] where product_name = '"+product_name+"';";
            }
            else
            {
                ins = "select TOP 1 product_id, product_name, quantity, cost_price, sell_price from [product_table]";
            }

            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            
            SqlCommand cmd = new SqlCommand(ins, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int prod_id = 0, quantity = 0;
            decimal cost_price = 0;
            decimal sell_price = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prod_id = dr.GetInt32(0);
                    quantity = dr.GetInt32(2);
                    cost_price = dr.GetDecimal(3);
                    sell_price = dr.GetDecimal(4);

                }
                label_id.Text = prod_id.ToString();
                label_cost.Text = cost_price.ToString();
                label_quantity.Text = quantity.ToString();
                label_sellprice.Text = sell_price.ToString();
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            //close data reader
            dr.Close();

            //close connection
            con.Close();
            label_totalcost.Text = (quantity * sell_price).ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sales_quantity.Text = "";
            sales_rate.Text = "";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string product_name = DropDownList1.SelectedItem.ToString();
            
            string ins = "select product_id, quantity, cost_price, sell_price from [product_table] where product_name='" + product_name+"';";
            SqlCommand cmd = new SqlCommand(ins, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int prod_id=0, quantity=0;
            decimal cost_price = 0;
            decimal sell_price = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prod_id = dr.GetInt32(0);
                    quantity = dr.GetInt32(1);
                    cost_price = dr.GetDecimal(2);
                    sell_price = dr.GetDecimal(3);

                }
                label_id.Text = prod_id.ToString();
                label_cost.Text = cost_price.ToString();
                label_quantity.Text = quantity.ToString();
                label_sellprice.Text = sell_price.ToString();
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            //close data reader
            dr.Close();

            //close connection
            con.Close();
            label_totalcost.Text = (quantity * sell_price).ToString();
        }

        protected void sales_quantity_TextChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(sales_quantity.Text) > decimal.Parse(label_quantity.Text))
            {
                sales_quantity.Text = "";
                label_validation_quantity.Text = "Quantity should be less than available";
            }
            else
            {
                label_validation_quantity.Text = "";
                decimal quantity = (!String.IsNullOrEmpty(sales_quantity.Text)) ? decimal.Parse(sales_quantity.Text) : decimal.Parse(label_quantity.Text);
                decimal rate = (!String.IsNullOrEmpty(sales_rate.Text)) ? decimal.Parse(sales_rate.Text) : decimal.Parse(label_sellprice.Text);
                label_totalcost.Text = (quantity * rate).ToString();
            }
            
        }


        protected void sales_rate_TextChanged(object sender, EventArgs e)
        {
            decimal quantity = (!String.IsNullOrEmpty(sales_quantity.Text)) ? decimal.Parse(sales_quantity.Text) : decimal.Parse(label_quantity.Text);
            decimal rate = (!String.IsNullOrEmpty(sales_rate.Text)) ? decimal.Parse(sales_rate.Text) : decimal.Parse(label_sellprice.Text);
            label_totalcost.Text = (quantity * rate).ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            decimal quantity = (!String.IsNullOrEmpty(sales_quantity.Text)) ? decimal.Parse(sales_quantity.Text) : decimal.Parse(label_quantity.Text);
            decimal rate =  (!String.IsNullOrEmpty(sales_rate.Text)) ? decimal.Parse(sales_rate.Text) : decimal.Parse(label_sellprice.Text);
            int id = int.Parse(label_id.Text);
            decimal cost = quantity * rate;
            string ins = "Insert into [sales_table](product_id , quantity, rate, cost) values(" + id + " ," + quantity + " , " + rate + ","+cost+")";
            SqlCommand com = new SqlCommand(ins, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            
            int avai = int.Parse(label_quantity.Text) - int.Parse(quantity.ToString());
            ins = "Update [product_table] set quantity = " + avai + " where product_id="+id;
            com = new SqlCommand(ins, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            sales_quantity.Text = "";
            sales_rate.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}