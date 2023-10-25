<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminBookInventory.aspx.cs" Inherits="WebApplication1.adminBookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         });

         function readURL(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();

                 reader.onload = function (e) {
                     $('#imgview').attr('src', e.target.result);
                 };

                 reader.readAsDataURL(input.files[0]);
             }
         }
     </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Membet Details</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" height="150px" width ="100px" src="book_inventory/books1.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col my-3">
                                <asp:FileUpload class="form-control" onChange="readURL(this);" ID="book_fileUpload" runat="server" />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group my-2">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tb_BookID" runat="server" placeholder="a123">
                                        </asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="btn_checkID" runat="server" OnClick="btn_checkID_Click">
                                            <i class="fa-regular fa-circle-check"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_bookName" runat="server" placeholder="">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group my-2">
                                    <asp:DropDownList class="form-control" ID="ddl_Language" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marathi" Value="Marathi" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Urdu" Value="Urdu" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group my-2">
                                    <asp:DropDownList class="form-control" ID="ddl_publisherName" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group my-2">
                                    <asp:DropDownList class="form-control" ID="ddl_authorName" runat="server">
                                        <asp:ListItem Text="A1" Value="a1" />
                                        <asp:ListItem Text="a2" Value="a2" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publish Date</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_publishDate" runat="server" TextMode="Date">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="lb_Genre" runat="server" SelectionMode="Multiple" Rows="5">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                        <asp:ListItem Text="Self Help" Value="Self Help" />
                                        <asp:ListItem Text="Motivation" Value="Motivation" />
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                        <asp:ListItem Text="Wellness" Value="Wellness" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Suspense" Value="Suspense" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Math" Value="Math" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_edition" runat="server" placeholder="Edition">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_bookCost" runat="server" placeholder="Book Cost">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_Pages" runat="server" placeholder="Pages">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_actualStock" runat="server" placeholder="Actual Stock">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_currentStock" runat="server" placeholder="Current Stock" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_IssuedBooks" runat="server" placeholder="Issued Books" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col">
                                <label>Book Description</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_bookDesc" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2">
                                    </asp:TextBox>
                                </div>
                            </div>

                        <div class="row">
                                <div class="col-4 d-grid my-3">
                                    <asp:Button class="btn btn-success" ID="btn_bookAdd" runat="server" Text="Add" OnClick="btn_bookAdd_Click"></asp:Button>
                                </div>

                                <div class="col-4 d-grid my-3">
                                    <asp:Button class="btn btn-warning" ID="btn_bookUpdate" runat="server" Text="Update" OnClick="btn_bookUpdate_Click"></asp:Button>
                                </div>

                                <div class="col-4 d-grid my-3">
                                    <asp:Button class="btn btn-danger" ID="btn_bookDelete" runat="server" Text="Delete" OnClick="btn_bookDelete_Click"></asp:Button>
                                </div>
                            </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Book Inventory List</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="bookData_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString1 %>" SelectCommand="SELECT * FROM [book_master_table]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="bookData_GridView" runat="server" DataSourceID="bookData_SqlDataSource" AutoGenerateColumns="False" DataKeyNames="book_id">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="col-12">
                                                                <asp:Label ID="label_bookName" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                            </div>
                                                            <div class="col-12 my-1">
                                                                Author -
                                                                <asp:Label ID="label_authorName" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True"></asp:Label>
                                                                &nbsp;| Genre -
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("genre") %>' Font-Bold="True"></asp:Label>
                                                                &nbsp;| Language -
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("language") %>' Font-Bold="True"></asp:Label>
                                                            </div>

                                                            <div class="col-12 my-1">
                                                                Publisher -
                                                                <asp:Label ID="label_publisher" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                 &nbsp;| Publish Date -
                                                                <asp:Label ID="label_publishDate" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                &nbsp;| Pages -
                                                                <asp:Label ID="label_pages" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                &nbsp;| Edition -
                                                                <asp:Label ID="label_edition" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                            </div>

                                                            <div class="col-12 my-1">
                                                                 Cost -
                                                                <asp:Label ID="lable_cost" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                 &nbsp;| Actual Stock -
                                                                <asp:Label ID="lable_acualStock" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                &nbsp;| Avaliable -
                                                                <asp:Label ID="label_avaliable" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                            </div>

                                                            <div class="col-12">
                                                                Description -
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <a href="homepage.aspx"><< Back to Home</a>
        <br>
        <br>
    </div>
</asp:Content>
