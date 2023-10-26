<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminPublisherManagement.aspx.cs" Inherits="WebApplication1.adminPublisherManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
     </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher Details</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="125px" src="imgs/publisher.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group my-2">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tb_publisherID" runat="server" placeholder="ID">
                                        </asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_publisherName" runat="server" placeholder="Publisher Name">
                                    </asp:TextBox>
                                </div>
                            </div>



                            <div class="col d-grid my-3">
                                <asp:Button class="btn btn-success" ID="btn_Add" runat="server" Text="Add" OnClick="btn_Add_OnClick"/>
                            </div>

                            <div class="col d-grid my-3">
                                <asp:Button class="btn btn-warning" ID="btn_Update" runat="server" Text="Update"  OnClick="btn_Update_OnClick"/>
                            </div>

                            <div class="col d-grid my-3">
                                <asp:Button class="btn btn-danger" ID="btn_Delete" runat="server" Text="Delete"  OnClick="btn_Delete_OnClick"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher List</h3>
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
                                <asp:SqlDataSource ID="Publisher_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_table]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="Publisher_GridView" runat="server" DataSourceID="Publisher_SqlDataSource"></asp:GridView>
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
