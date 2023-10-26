using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1
{
    public partial class userprofile : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"].ToString() == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack) 
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e) 
        {
            updateUserPersonalDetails();
        }

        void updateUserPersonalDetails()
        {
            string password = "";
            if (tb_newPassword.Text.Trim() == "")
            {
                password = tb_password.Text.Trim();
            }
            else 
            {
                password = tb_newPassword.Text.Trim();
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_master_table SET full_name=@fullname, dob=@dob ,contact_no=@contact_no ,email=@email ,state=@state ,city=@city ,pincode=@pincode ,full_address=@full_address ,password=@password ,account_status=@account_status WHERE member_id = '" + Session["username"].ToString().Trim() + "';", connection);
                cmd.Parameters.AddWithValue("@fullname", tb_fullName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", tb_DOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", tb_contactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@email", tb_email.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddl_State.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", tb_City.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode",tb_pinCode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address",tb_Address.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                connection.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                }
                else {
                    Response.Write("<script>alert('User ID does not exist');</script>");
                }

            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void getUserPersonalDetails() {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_table WHERE member_id = '" + Session["username"].ToString() + "';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                tb_fullName.Text = dataTable.Rows[0]["full_name"].ToString();
                tb_DOB.Text = dataTable.Rows[0]["dob"].ToString();
                tb_contactNo.Text = dataTable.Rows[0]["contact_no"].ToString();
                tb_email.Text = dataTable.Rows[0]["email"].ToString();
                ddl_State.SelectedValue = dataTable.Rows[0]["state"].ToString().Trim();
                tb_City.Text = dataTable.Rows[0]["city"].ToString();
                tb_Address.Text = dataTable.Rows[0]["full_address"].ToString();
                tb_userID.Text = dataTable.Rows[0]["member_id"].ToString();
                tb_password.Text = dataTable.Rows[0]["password"].ToString();

                label_accountStatus.Text = dataTable.Rows[0]["account_status"].ToString().Trim();

                if (dataTable.Rows[0]["account_status"].ToString().Trim() == "Active") 
                {
                    label_accountStatus.Attributes.Add("class","badge badge-pill badge-success");
                } 
                else if(dataTable.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    label_accountStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dataTable.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    label_accountStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else 
                {
                    label_accountStatus.Attributes.Add("class", "badge badge-pill badge-secondary");
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void getUserBookData() {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_table WHERE member_id = '" + Session["username"].ToString() + "';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                userProfile_GridView.DataSource = dataTable;
                userProfile_GridView.DataBind();
            }
            catch (Exception exception) {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        protected void userProfile_GridView_RowDataBound(object sender, GridViewRowEventArgs events)
        {
            try
            {
                if (events.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dateTime = Convert.ToDateTime(events.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if (today > dateTime)
                    {
                        events.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }
    }
}