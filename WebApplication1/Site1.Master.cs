using System;
using System.Collections.Generic;
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

        protected void LinkBtn_profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }
    }
}