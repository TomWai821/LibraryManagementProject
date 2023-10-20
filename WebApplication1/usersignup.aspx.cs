using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class usersignup : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Sign Up button click event
        protected void btn_signUp_Click(object sender, EventArgs e)
        {
            if (CheckUserExist())
            {
                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID')</script>");
            }
            else 
            {
                SignupMember();
            }
        }

        private void SignupMember()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strCon);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_table(full_name, dob, contact_no, email, state, city, pincode, full_address, member_id, password, account_status)" +
                    " VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status)", connection);

                //ddl = DropDownList, tb = TextBox
                cmd.Parameters.AddWithValue("@full_name", tb_fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", tb_dob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", tb_contact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddl_state.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", tb_city.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", tb_pinCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", tb_address.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", tb_memberID.Text.Trim());
                cmd.Parameters.AddWithValue("@password", tb_password.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('Sign Up Successfully. Go to user Login to Login')</script>");
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "')</script>");
            }
        }

        bool CheckUserExist() {
            try
            {
                SqlConnection connection = new SqlConnection(strCon);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_table where member_id='"
                    + tb_memberID.Text.Trim() + "';", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                connection.Close();

                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "')</script>");
                return false;
            }
        }
    }
}