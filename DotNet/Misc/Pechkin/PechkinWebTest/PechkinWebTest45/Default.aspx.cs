using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PechkinWebTest45
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var gc = new Pechkin.GlobalConfig();
            var pechkin = Pechkin.Factory.Create(gc);
            var oc = new Pechkin.ObjectConfig().SetPrintBackground(true).SetLoadImages(true);
            byte[] pdf = pechkin.Convert(new Uri(TextBox1.Text));
            System.IO.File.WriteAllBytes(@"C:\temp\test.pdf", pdf);    
        }
    }
}