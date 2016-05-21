using System;
using System.Globalization;
using System.Threading;

namespace ErrorPageDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlLanguagesInSession.Items.Add("en-US");
                ddlLanguagesInSession.Items.Add("zh-TW");
                ddlLanguagesInSession.Items.Add("zh-CN");
                ddlLanguagesInSession.Items.Add("fr-FR");
                ddlLanguagesInSession.Items.Add("id-ID");
                ddlLanguagesInSession.SelectedIndex = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserLanguage"] = ddlLanguagesInSession.Text;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["UserLanguage"].ToString());
            throw new Exception("休士頓，我們這裡出問題了!");
        }
    }
}