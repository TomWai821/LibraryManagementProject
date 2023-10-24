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
    public partial class adminPublisherManagement : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Publisher_GridView.DataBind();
        }

        protected void btn_Add_OnClick(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                Response.Write("<script>alert('Publisher with this ID already Exist. You cannot add another publisher with the same Publisher ID')</script>");
            }
            else
            {
                addPublisher();
            }
        }

        protected void btn_Update_OnClick(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Invalid Publisher ID')</script>");
            }
        }

        protected void btn_Delete_OnClick(object sender, EventArgs e)
        {
            if (checkIfPublisherExist())
            {
                DeletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Invalid Publisher ID')</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }

        bool checkIfPublisherExist()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * FROM publisher_master_table WHERE publisher_id = '" + tb_publisherID.Text.Trim() + "';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count >= 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception exception) {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                return false;
            }
        }

        void addPublisher()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("INSERT INTO publisher_master_table (publisher_id, publisher_name) VALUES (@publisher_id, @publisher_name);", connection);
                command.Parameters.AddWithValue("@publisher_id", tb_publisherID.Text.Trim());
                command.Parameters.AddWithValue("@publisher_name", tb_publisherName.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Add Publisher Successfully!');</script>");
                clearForm();
                Publisher_GridView.DataBind();
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "');</script>");
            }
        }

        void UpdatePublisher() {
            try {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed) {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("UPDATE publisher_master_table SET publisher_name = @publisher_name WHERE publisher_id = '" + tb_publisherID.Text.Trim() + "';", connection);
                command.Parameters.AddWithValue("@publisher_name", tb_publisherName.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Update Publisher Name Successfully!');</script>");
                clearForm();
                Publisher_GridView.DataBind();
            }
            catch (Exception exception) {
                Response.Write("<script>alert('" + exception.Message.ToString() + "');</script>");
            }
        }

        void DeletePublisher()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("DELETE FROM publisher_master_table WHERE publisher_id = '"+tb_publisherID.Text.Trim()+"';", connection);
                command.ExecuteNonQuery();
                connection.Close();

                Response.Write("<script>alert('Delete Publisher Successfully')</script>");
                clearForm();
                Publisher_GridView.DataBind();
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void getPublisherByID() {
              try
              {
                  SqlConnection connection = new SqlConnection(connectionString);
                  if (connection.State == ConnectionState.Closed)
                  {
                      connection.Open();
                  }

                  SqlCommand command = new SqlCommand("SELECT * FROM publisher_master_table WHERE publisher_id = '" + tb_publisherID.Text.Trim() + "';", connection);
                  SqlDataAdapter adapter = new SqlDataAdapter(command);
                  DataTable datatable = new DataTable();
                  adapter.Fill(datatable);

                  if (datatable.Rows.Count >= 1)
                  {
                      tb_publisherName.Text = datatable.Rows[0][1].ToString();
                  }
                  else
                  {
                      Response.Write("<script>alert('Invalid publisher ID');</script>");
                  }

              }
              catch (Exception excpetion)
              {
                  Response.Write("<script>alert('" + excpetion.Message.ToString() + "');</script>");
              }
            }
        
        void clearForm()
        {
            tb_publisherID.Text = "";
            tb_publisherName.Text = "";
        }

    }
}