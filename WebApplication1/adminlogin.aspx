<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="WebApplication1.adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/adminuser.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
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

                                <label>Admin ID</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_adminID" runat="server" placeholder="ID">
                                    </asp:TextBox>
                                </div>

                                <label>Password</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_adminPassword" runat="server" placeholder="Password" TextMode="Password">
                                    </asp:TextBox>

                                    <div class="form-group d-grid gap-2 my-3">
                                        <asp:Button class="btn btn-success" ID="btn_adminLogin" runat="server" Text="Login" OnClick="btn_adminLogin_Click"></asp:Button>
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
        </div>
    </div>
</asp:Content>
