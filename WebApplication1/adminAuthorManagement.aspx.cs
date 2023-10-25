using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminAuthorManagement : System.Web.UI.Page
    {

        string conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            author_GridView.DataBind();
        }

        protected void btn_Add_OnClick(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                Response.Write("<script>alert('Author with this ID already Exist. You cannot add another Author with the same Author ID');</script>");
            }
            else {
                addNewAuthor();
            }
        }

        protected void btn_Update_OnClick(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                updateAuthor();
            }
            else {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }

        protected void btn_Delete_OnClick(object sender, EventArgs e)
        {
            if (checkIfAuthorExist())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }

        void addNewAuthor() {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("INSERT INTO author_master_table (author_id, author_name) VALUES (@author_id, @author_name);", connection);
                command.Parameters.AddWithValue("@author_id", tb_authorID.Text.Trim());
                command.Parameters.AddWithValue("@author_name", tb_authorName.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Add author Successfully!');</script>");
                clearForm();
                author_GridView.DataBind();
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void updateAuthor() {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("UPDATE author_master_table SET author_name = @author_name WHERE author_id='" + tb_authorID.Text.Trim() + "'", connection);
                command.Parameters.AddWithValue("@author_name", tb_authorName.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Update Author Name Successfully!');</script>");
                clearForm();
                author_GridView.DataBind();
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void deleteAuthor()
        {
            try {
                SqlConnection connection = new SqlConnection(conString);
                if (connection.State == ConnectionState.Closed) 
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("DELETE FROM author_master_table WHERE author_id = @author_id;", connection);
                command.Parameters.AddWithValue("@author_id",tb_authorID.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Delete Author Successfully')</script>");
                clearForm();
                author_GridView.DataBind();
            }
            catch (Exception exception) 
            {
                Response.Write("<script>alert('"+ exception.Message.ToString()+"')</script>");
            }
        }

        bool checkIfAuthorExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                if (connection.State == ConnectionState.Closed) 
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("SELECT * from author_master_table WHERE author_id = '"+ tb_authorID.Text.Trim() +"';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1) {
                    return true;
                } else {
                    return false;
                }
            }
            catch(Exception exception) {
                Response.Write("<script>alert('" + exception.Message.ToString() + "');</script>");
                return false;
            }
        }

        void getAuthorByID()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                if(connection.State == ConnectionState.Closed){
                    connection.Open();
                }

                SqlCommand command = new SqlCommand("SELECT * FROM author_master_table WHERE author_id = '"+ tb_authorID.Text.Trim()+"';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                if (datatable.Rows.Count >= 1) {
                    tb_authorName.Text = datatable.Rows[0][1].ToString();
                } else{
                    Response.Write("<script>alert('Invalid author ID');</script>");
                }
 
            }
            catch (Exception excpetion) 
            {
                Response.Write("<script>alert('"+excpetion.Message.ToString()+"');</script>");
            }
        }

        void clearForm()
        {
            tb_authorID.Text = "";
            tb_authorName.Text= "";
        }
    }
}