using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication1
{
    public partial class adminlogin : System.Web.UI.Page
    {

        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_adminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strCon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * from admin_login_table WHERE username ='" + tb_adminID.Text.Trim() + "'AND password = '" + tb_adminPassword.Text.Trim() + "';", connection);
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sqldataAdapter.Fill(dataTable);

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        // Get Row 8(Username) data
                        //Response.Write("<script>alert('Login Successful');</script>");

                        Session["username"] = sqlDataReader.GetString(0).ToString();
                        Session["fullname"] = sqlDataReader.GetString(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert(Invalid credential);</script>");
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "');</script>");
            }
        }
    }
}