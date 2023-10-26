<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminBookIssuing.aspx.cs" Inherits="WebApplication1.adminBookIssuing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         });
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
                                    <h3>Book Issuing</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="125px" src="imgs/books.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_memberID" runat="server" placeholder="ts11-">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group my-2">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tb_bookID" runat="server" placeholder="b002">
                                        </asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="btn_Go" runat="server" Text="Go" OnClick="btn_Go_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_MemberName" runat="server" placeholder="" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_BookName" runat="server" placeholder="" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_issueDate" runat="server" placeholder="Start Date" TextMode="Date">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group my-2">
                                        <asp:TextBox CssClass="form-control" ID="tb_dueDate" runat="server" placeholder="End Date" TextMode="Date">
                                        </asp:TextBox>
                                    </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col d-grid my-3">
                                <asp:Button class="btn btn-primary" ID="btn_Issue" runat="server" Text="Issue" OnClick="btn_Issue_Click" />
                            </div>

                            <div class="col d-grid my-3">
                                <asp:Button class="btn btn-success" ID="btn_Return" runat="server" Text="Return" OnClick="btn_Return_Click"/>
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
                                    <h3>Issued Book List</h3>
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
                                    <asp:SqlDataSource ID="issued_dataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString1 %>" SelectCommand="SELECT * FROM [book_issue_table]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="issueBook_GridView" runat="server" DataSourceID="issued_dataSource" AutoGenerateColumns="False" OnRowDataBound="issueBook_GridView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
