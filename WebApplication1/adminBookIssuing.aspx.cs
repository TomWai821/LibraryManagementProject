using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Caching;

namespace WebApplication1
{
    public partial class adminBookIssuing : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            issueBook_GridView.DataBind();
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            getNames();
        }

        protected void btn_Issue_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntityExist())
                {
                    Response.Write("<script>alert('This member already has this book')</script>");
                }
                else {
                    issuedBook();
                }  
            }
            else {
                Response.Write("<script>alert('Wrong Member ID or Book ID')</script>");
            }
        }

        protected void btn_Return_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {
                if (checkIfIssueEntityExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('This entry does not exist')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Member ID or Book ID')</script>");
            }
        }

        // user define function
        void getNames()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_table WHERE book_id = '" + tb_bookID.Text.Trim() + "';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    tb_BookName.Text = dataTable.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid User ID')</script>");
                }

                cmd = new SqlCommand("SELECT * from member_master_table WHERE member_id = '" + tb_memberID.Text.Trim() + "';", connection);
                adapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    tb_MemberName.Text = dataTable.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid User ID')</script>");
                }

            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_table WHERE book_id = '" + tb_bookID.Text.Trim() + "' AND current_stock > 0;", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

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
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                return false;
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

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_table WHERE member_id = '" + tb_memberID.Text.Trim() + "';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

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
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                return false;
            }
        }

        bool checkIfIssueEntityExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_table WHERE member_id = '"+ tb_memberID.Text.Trim() + "' AND book_id = '"+ tb_bookID.Text.Trim()+ "';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

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
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                return false;
            }
        }

        void issuedBook() {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_table (member_id, member_name, book_id ,book_name ,issue_date ,due_date) " +
                    "VALUES (@member_id, @member_name, @book_id ,@book_name ,@issue_date ,@due_date);", connection);
                cmd.Parameters.AddWithValue("@member_id", tb_memberID.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", tb_MemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", tb_bookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", tb_BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", tb_issueDate.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", tb_dueDate.Text.Trim());
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_table SET current_stock = current_stock - 1 WHERE book_id = '" + tb_bookID.Text.Trim() + "';", connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                Response.Write("<script>alert('Book Issued sucessfully')</script>");
                issueBook_GridView.DataBind(); 
            } 
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void returnBook() {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_table WHERE member_id ='"+ tb_memberID.Text.Trim() + "' AND book_id = '"+ tb_bookID.Text.Trim() + "';", connection);
                int result = cmd.ExecuteNonQuery();
                if (result > 0) {

                    cmd = new SqlCommand("UPDATE book_master_table SET current_stock = current_stock + 1 WHERE book_id = '" + tb_bookID.Text.Trim() + "';", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    Response.Write("<script>alert('Book return sucessfully')</script>");
                    issueBook_GridView.DataBind();

                }
                
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        protected void issueBook_GridView_RowDataBound(object sender, GridViewRowEventArgs events)
        {
            try
            {
                if (events.Row.RowType == DataControlRowType.DataRow) {
                    DateTime dateTime = Convert.ToDateTime(events.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if (today > dateTime) {
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
