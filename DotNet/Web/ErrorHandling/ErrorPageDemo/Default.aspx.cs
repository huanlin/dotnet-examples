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
                ddlLanguages.Items.Add("en-US");
                ddlLanguages.Items.Add("zh-TW");
                ddlLanguages.Items.Add("zh-CN");
                ddlLanguages.Items.Add("fr-FR");
                ddlLanguages.Items.Add("id-ID");
                ddlLanguages.SelectedIndex = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserLanguage"] = ddlLanguages.Text;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlLanguages.Text);
            throw new Exception("休士頓，我們這裡出問題了!");
        }
    }
}