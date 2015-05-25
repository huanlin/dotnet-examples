using System;
using System.IO;
using InfoShare.Text2Tip.Application.Services;

namespace TwilioTest
{
    public partial class ReceiveMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Logs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fname = Path.Combine(path, DateTime.Now.ToString("yyyyMMddHHmmss") + "_req.txt");         

            Request.SaveAs(fname, true);

            // Save to database.
            var service = new MessageService();
            service.LogIncomingMessage(Request);
        }
    }
}