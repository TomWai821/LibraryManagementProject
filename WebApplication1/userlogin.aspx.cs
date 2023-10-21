using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strCon);
                if(connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * from member_master_table WHERE member_id ='" + tb_userID.Text.Trim() + "'AND password = '" + tb_password.Text.Trim() + "';", connection);
                SqlDataAdapter sqldataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sqldataAdapter.Fill(dataTable);

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows) {
                    while (sqlDataReader.Read()) {
                        // Get Row 8(Username) data
                        Response.Write("<script>alert('"+ sqlDataReader.GetValue(8).ToString() + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert(Invalid credential);</script>");
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('"+ exception.Message +"');</script>");
            }
        }
    }
}