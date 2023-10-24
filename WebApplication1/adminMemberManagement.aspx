<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminMemberManagement.aspx.cs" Inherits="WebApplication1.adminMemberManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
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
                                        <asp:TextBox CssClass="form-control" ID="tb_memberID" runat="server" placeholder="a123">
                                        </asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="btn_Check" runat="server" OnClick="btn_Check_Click">
                                            <i class="fa-regular fa-circle-check"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_fullName" runat="server" placeholder="" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group my-2">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tb_AccountState" runat="server" placeholder="Pending" ReadOnly="true">
                                        </asp:TextBox>
                                        <asp:LinkButton class="btn btn-success" ID="btn_active" runat="server" OnClick="btn_active_Click">
                                            <i class="fa-regular fa-circle-check"></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton class="btn btn-warning" ID="btn_pending" runat="server" OnClick="btn_pending_Click">
                                            <i class="fa-regular fa-circle-pause"></i>
                                        </asp:LinkButton>

                                        <asp:LinkButton class="btn btn-danger" ID="btn_deactive" runat="server" OnClick="btn_deactive_Click">
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
                                    <asp:TextBox CssClass="form-control" ID="tb_DOB" runat="server" placeholder="Start Date" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_Contact" runat="server" placeholder="End Date" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_Email" runat="server" placeholder="End Date" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_State" runat="server" placeholder="State" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_City" runat="server" placeholder="City" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group my-2">
                                    <asp:TextBox CssClass="form-control" ID="tb_PinCode" runat="server" placeholder="Pin Code" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-12">
                                <label>Full Postal Address</label>
                                <div class="form-group my-2">
                                    <asp:TextBox class="form-control" ID="tb_Address" runat="server" placeholder="Full Address" TextMode="MultiLine" ReadOnly="true">
                                    </asp:TextBox>
                                </div>
                            </div>

                        <div class="row">
                            <div class="col d-grid my-3 col-8 mx-auto">
                                <asp:Button class="btn btn-danger" ID="btn_deleteMember" runat="server" Text="Delete User Permanently" OnClick="btn_deleteMember_Click"/>
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
                            <asp:SqlDataSource ID="SqlDataSource_member" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString1 %>" SelectCommand="SELECT * FROM [member_master_table]"></asp:SqlDataSource>
                            <asp:GridView class="table table-striped table-bordered" ID="memberData_GridView" runat="server" DataSourceID="SqlDataSource_member" AutoGenerateColumns="False" DataKeyNames="member_id">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="account_status" HeaderText="Account State" SortExpression="account_status"/>
                                    <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                    <asp:BoundField DataField="email" HeaderText="Email ID" SortExpression="email" />
                                    <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
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
