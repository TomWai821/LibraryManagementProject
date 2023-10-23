using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkBtn_userLogin.Visible = true;      // User login Link Button 
                    LinkBtn_signUp.Visible = true;         // User sign up Link Button
                                                           
                    LinkBtn_logout.Visible = false;        // User logout Link Button
                    LinkBtn_helloUser.Visible = false;     // User Profile Link Button
                                                           
                    LinkBtn_adminLog.Visible = true;       // Admin Login Link Button
                    LinkBtn_authorMan.Visible = false;     // Author Management Link Button
                    LinkBtn_publisherMan.Visible = false;  // Publisher Management Link Button
                    LinkBtn_bookInv.Visible = false;       // Book Inventory Link Button
                    LinkBtn_bookIss.Visible = false;       // Book Issuing Link Button
                    LinkBtn_memberMan.Visible = false;     // Member management Link Button
                } 
                else if (Session["role"].Equals("user")) 
                {
                    LinkBtn_userLogin.Visible = false;     // User login link Button 
                    LinkBtn_signUp.Visible = false;        // User sign up Button

                    LinkBtn_logout.Visible = true;         // User logout link Button
                    LinkBtn_helloUser.Visible = true;      // User Profile link Button
                    LinkBtn_helloUser.Text = "Hello " + Session["username"].ToString();

                    LinkBtn_adminLog.Visible = true;       // Admin Login link Button
                    LinkBtn_authorMan.Visible = false;     // Author Management Link Button
                    LinkBtn_publisherMan.Visible = false;  // Publisher Management Link Button
                    LinkBtn_bookInv.Visible = false;       // Book Inventory Link Button
                    LinkBtn_bookIss.Visible = false;       // Book Issuing Link Button
                    LinkBtn_memberMan.Visible = false;     // Member management Link Button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkBtn_userLogin.Visible = false;     // User login link Button 
                    LinkBtn_signUp.Visible = false;        // User sign up Button

                    LinkBtn_logout.Visible = true;         // User logout link Button
                    LinkBtn_helloUser.Visible = true;      // User Profile link Button
                    LinkBtn_helloUser.Text = "Hello Admin";

                    LinkBtn_adminLog.Visible = false;       // Admin Login link Button
                    LinkBtn_authorMan.Visible = true;     // Author Management Link Button
                    LinkBtn_publisherMan.Visible = true;  // Publisher Management Link Button
                    LinkBtn_bookInv.Visible = true;       // Book Inventory Link Button
                    LinkBtn_bookIss.Visible = true;       // Book Issuing Link Button
                    LinkBtn_memberMan.Visible = true;     // Member management Link Button
                }
            }
            catch (Exception exception)
            { 

            }
        }

        protected void LinkBtn_adminLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkBtn_authorMan_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }

        protected void LinkBtn_publisherMan_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }

        protected void LinkBtn_bookInv_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkBtn_bookIss_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookIssuing.aspx");
        }

        protected void LinkBtn_memberMan_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkBtn_viewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkBtn_userLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        protected void LinkBtn_signUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignup.aspx");
        }

        protected void LinkBtn_helloUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        protected void LinkBtn_logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkBtn_userLogin.Visible = true;      // User login Link Button 
            LinkBtn_signUp.Visible = true;         // User sign up Link Button

            LinkBtn_logout.Visible = false;        // User logout Link Button
            LinkBtn_helloUser.Visible = false;     // User Profile Link Button

            LinkBtn_adminLog.Visible = true;       // Admin Login Link Button
            LinkBtn_authorMan.Visible = false;     // Author Management Link Button
            LinkBtn_publisherMan.Visible = false;  // Publisher Management Link Button
            LinkBtn_bookInv.Visible = false;       // Book Inventory Link Button
            LinkBtn_bookIss.Visible = false;       // Book Issuing Link Button
            LinkBtn_memberMan.Visible = false;     // Member management Link Button
        }
    }
}