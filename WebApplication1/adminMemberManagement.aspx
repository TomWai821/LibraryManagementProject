<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminMemberManagement.aspx.cs" Inherits="WebApplication1.adminMemberManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <img width="125px" src="imgs/generaluser.png">
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group my-2">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="a123">
                                        </asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server">
                                            <i class="fa-regular fa-circle-check"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group my-2">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Pending" ReadOnly="true">
                                        </asp:TextBox>
                                        <asp:LinkButton class="btn btn-success" ID="LinkButton1" runat="server">
                                            <i class="fa-regular fa-circle-check"></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton class="btn btn-warning" ID="LinkButton2" runat="server">
                                            <i class="fa-regular fa-circle-pause"></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton class="btn btn-danger" ID="LinkButton3" runat="server">
                                            <i class="fa-regular fa-circle-xmark"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="End Date" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="State" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="City" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Pin Code" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-12">
                                <label>Full Postal Address</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Full Address" TextMode="MultiLine" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        <div class="row">
                            <div class="col d-grid my-3 col-8 mx-auto">
                                <asp:Button class="btn btn-danger" ID="Button4" runat="server" Text="Delete User Permanently" />
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
                                <h3>Member List</h3>
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
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
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
