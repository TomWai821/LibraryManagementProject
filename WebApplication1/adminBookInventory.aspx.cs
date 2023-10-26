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
using System.Drawing.Drawing2D;
using System.IO;

namespace WebApplication1
{

    public partial class adminBookInventory : System.Web.UI.Page
    {
        string stringconnection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_file_path;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                fillAuthorPublisherValues();
            }
            bookData_GridView.DataBind();
        }

        protected void btn_checkID_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        protected void btn_bookAdd_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist()) {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID')</script>");
            }
            else {
                addBook(); 
            }
        }

        protected void btn_bookUpdate_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        protected void btn_bookDelete_Click(object sender, EventArgs e)
        {  
            deleteBook();
        }

        // user defined functions
        void getBookByID() {
            try
            {
                SqlConnection connection = new SqlConnection(stringconnection);
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_table WHERE book_id = '"+ tb_BookID.Text.Trim() +"';", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    tb_bookName.Text = dataTable.Rows[0]["book_name"].ToString();
                    ddl_Language.SelectedValue = dataTable.Rows[0]["language"].ToString().Trim();
                    ddl_authorName.SelectedValue = dataTable.Rows[0]["author_name"].ToString().Trim();
                    ddl_publisherName.SelectedValue = dataTable.Rows[0]["publisher_name"].ToString().Trim();
                    tb_publishDate.Text = dataTable.Rows[0]["publish_date"].ToString();

                    lb_Genre.ClearSelection();
                    string[] genre = dataTable.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < lb_Genre.Items.Count; j++)
                        {
                            if (lb_Genre.Items[j].ToString() == genre[i])
                            {
                                lb_Genre.Items[j].Selected = true;

                            }
                        }
                    }

                    tb_edition.Text = dataTable.Rows[0]["edition"].ToString();
                    tb_bookCost.Text = dataTable.Rows[0]["book_cost"].ToString().Trim();
                    tb_Pages.Text = dataTable.Rows[0]["no_of_pages"].ToString().Trim();
                    tb_actualStock.Text = dataTable.Rows[0]["actual_stock"].ToString().Trim();
                    tb_currentStock.Text = dataTable.Rows[0]["current_stock"].ToString().Trim();
                    tb_bookDesc.Text = dataTable.Rows[0]["book_description"].ToString();

                    tb_IssuedBooks.Text = "" + (Convert.ToInt32(dataTable.Rows[0]["current_stock"].ToString())
                        - Convert.ToInt32(dataTable.Rows[0]["current_stock"].ToString()));

                    global_actual_stock = Convert.ToInt32(dataTable.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dataTable.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_file_path = dataTable.Rows[0]["book_img_link"].ToString();
                }
                else {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
            }
            catch (Exception exception) {
                Response.Write("<script>'"+ exception.Message.ToString() +"'</script>");
            }
        }

        void fillAuthorPublisherValues() {
            try
            {
                SqlConnection connection = new SqlConnection(stringconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("Select author_name from author_master_table;", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                ddl_authorName.DataSource = dataTable;
                ddl_authorName.DataValueField = "author_name";
                ddl_authorName.DataBind();

                cmd = new SqlCommand("Select publisher_name from publisher_master_table;", connection);
                dataAdapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                ddl_publisherName.DataSource = dataTable;
                ddl_publisherName.DataValueField = "publisher_name";
                ddl_publisherName.DataBind();
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        bool checkIfBookExist() {
            try
            {
                SqlConnection connection = new SqlConnection(stringconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * FROM book_master_table WHERE book_id = '"+ tb_BookID.Text.Trim() +
                    "'OR book_name ='"+ tb_bookName.Text.Trim() +"'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count >= 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                return false;
            }
        }

        void addBook()
        {
            string genres = "";

            foreach (int i in lb_Genre.GetSelectedIndices()) 
            {
                genres = genres + lb_Genre.Items[i] + ",";
            }
            // genres = Advanture, Self Help
            genres = genres.Remove(genres.Length - 1);

            string filepath = "~/book_inventory/books1.png";
            string filename = Path.GetFileName(book_fileUpload.PostedFile.FileName);
            book_fileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
            filepath = "~/book_inventory/" + filename;


            try
            {
                SqlConnection connection = new SqlConnection(stringconnection);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_table (book_id ,book_name ,genre ,author_name ,publisher_name ,publish_date ,language ,edition ,book_cost ,no_of_pages ,book_description ,actual_stock ,current_stock ,book_img_link) " +
                                                     "VALUES (@book_id ,@book_name ,@genre ,@author_name ,@publisher_name ,@publish_date ,@language ,@edition ,@book_cost ,@no_of_pages ,@book_description ,@actual_stock ,@current_stock ,@book_img_link)", connection);
                cmd.Parameters.AddWithValue("@book_id", tb_BookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name",tb_bookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", ddl_authorName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", ddl_publisherName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", tb_publishDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language",ddl_Language.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", tb_edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", tb_bookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", tb_Pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description",tb_bookDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", tb_actualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", tb_actualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Write("<script>alert('book added successfully')</script>");
                bookData_GridView.DataBind();
                
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
            }
        }

        void updateBookByID()
        {

            if (checkIfBookExist())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(tb_actualStock.Text.Trim());
                    int current_stock = Convert.ToInt32(tb_currentStock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            tb_currentStock.Text = "" + current_stock;
                        }
                    }

                    // Set Genres
                    string genres = "";

                    foreach (int i in lb_Genre.GetSelectedIndices())
                    {
                        genres = genres + lb_Genre.Items[i] + ",";
                    }
                    // genres = Advanture, Self Help
                    genres = genres.Remove(genres.Length - 1);

                    // Set File path
                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(book_fileUpload.PostedFile.FileName); 
                    if (filename == "" || filename == null)
                    {
                        filepath = global_file_path;
                    }
                    else
                    {
                        book_fileUpload.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection connection = new SqlConnection(stringconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_table set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + tb_BookID.Text.Trim() + "';", connection);
                    cmd.Parameters.AddWithValue("@book_name", tb_bookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", ddl_authorName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", ddl_publisherName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", tb_publishDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", ddl_Language.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", tb_edition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", tb_bookCost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", tb_Pages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", tb_bookDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    bookData_GridView.DataBind();
                    Response.Write("<script>alert('book updated successfully')</script>");
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                }
            }
            else {
                Response.Write("<script>alert('Invalid Book ID')</script>");
            }
        }

        void deleteBook()
        {
            if (checkIfBookExist())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(stringconnection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_table WHERE book_id ='"+ tb_BookID.Text.Trim()+ "';", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    bookData_GridView.DataBind();
                    Response.Write("<script>alert('book deleted')</script>");
                }
                catch (Exception exception)
                {
                    Response.Write("<script>alert('" + exception.Message.ToString() + "')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID')</script>");
            }
        }

    }
}