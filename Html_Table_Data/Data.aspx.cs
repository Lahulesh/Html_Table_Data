using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Html_Table_Data
{
    public partial class Data : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Connect"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [studentdetails]";
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();
                table.Append("<table border='1'>");
                table.Append("<tr><th>User Id</th><th>UserName</th><th>EmailID</th><th>Contact</th><th>Address</th>");
                table.Append("</tr>");
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>"+dr[0]+"</td>");
                        table.Append("<td>"+dr[1]+"</td>");
                        table.Append("<td>"+dr[2]+"</td>");
                        table.Append("<td>"+dr[3]+"</td>");
                        table.Append("<td>"+dr[4]+"</td>");
                        table.Append("</tr>");
                    }
                }
                table.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString()});
                dr.Close();
            }
        }
    }
}