using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PechkinWebTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var gc = new Pechkin.GlobalConfig();
            var pechkin = new Pechkin.Synchronized.SynchronizedPechkin(gc);

            byte[] pdf = pechkin.Convert(new Uri("http://www.google.com"));

            System.IO.File.WriteAllBytes(@"C:\temp\test.pdf", pdf);    
        }
    }
}