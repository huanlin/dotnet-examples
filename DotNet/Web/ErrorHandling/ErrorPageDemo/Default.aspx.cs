using System;

namespace ErrorPageDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            throw new Exception("休士頓，我們這裡出問題了!");
        }
    }
}