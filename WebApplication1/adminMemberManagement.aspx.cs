using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.EnterpriseServices;

namespace WebApplication1
{
    public partial class adminMemberManagement : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            memberData_GridView.DataBind();
        }

        protected void btn_Check_Click(object sender, EventArgs e)
        {
            getDataByID();            
        }

        protected void btn_active_Click(object sender, EventArgs e) { updateMemberStatusByID("active"); }

        protected void btn_pending_Click(object sender, EventArgs e) { updateMemberStatusByID("pending"); }

        protected void btn_deactive_Click(object sender, EventArgs e) { updateMemberStatusByID("deactive"); }

        protected void btn_deleteMember_Click(object sender, EventArgs e) { deleteMemberByID(); }

        void getDataByID() {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_table WHERE member_id = '" + tb_memberID.Text.Trim() + "';", connection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read()) {
                        tb_fullName.Text = dataReader.GetValue(0).ToString();
                        tb_AccountState.Text = dataReader.GetValue(10).ToString();
                        tb_DOB.Text = dataReader.GetValue(1).ToString();
                        tb_Contact.Text = dataReader.GetValue(2).ToString();
                        tb_Email.Text = dataReader.GetValue(3).ToString();
                        tb_State.Text = dataReader.GetValue(4).ToString();
                        tb_City.Text = dataReader.GetValue(5).ToString();
                        tb_PinCode.Text = dataReader.GetValue(6).ToString();
                        tb_Address.Text = dataReader.GetValue(7).ToString();
                    }
                    
                }
                else {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "');</script>");
            }
        }

        void updateMemberStatusByID(string status) {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_master_table SET account_status='" + status + "' WHERE member_ID ='" + tb_memberID.Text.Trim() + "';", connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                memberData_GridView.DataBind();
                Response.Write("<script>alert('Member Status Updated');</script>");

            }catch(Exception exception) {
                Response.Write("<script>alert('"+ exception.Message.ToString() +"');</script>");
            }
        }

        void deleteMemberByID() {
            if (checkIfMemberExist())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_table WHERE member_id ='" + tb_memberID.Text.Trim() + "';", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    clearForm();
                    memberData_GridView.DataBind();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message.ToString() + "');</script>");
                }
            }
            else {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
               
        }

        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_table WHERE member_id = '" + tb_memberID.Text.Trim() + "';", connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
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
                Response.Write("<script>alert('" + exception.Message.ToString() + "');</script>");
                return false;
            }
        }

        void clearForm() {
            tb_fullName.Text = "";
            tb_AccountState.Text = "";
            tb_DOB.Text = "";
            tb_Contact.Text = "";
            tb_Email.Text = "";
            tb_State.Text = "";
            tb_City.Text = "";
            tb_PinCode.Text = "";
            tb_Address.Text = "";
        }
    }
}