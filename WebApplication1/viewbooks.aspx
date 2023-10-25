<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="WebApplication1.viewbooks" %>
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
    <div class="container">
    <div class="col-md-10">
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
        <a href="homepage.aspx"><< Back to Home</a>
        <br>
        <br>
        </div>
</asp:Content>
