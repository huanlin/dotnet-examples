using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;

namespace TwilioTest
{
    public partial class SendMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = txtAccSid.Text;
            string AuthToken = txtAuthToken.Text;

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var message = twilio.SendSmsMessage(txtFrom.Text, txtTo.Text, txtMsg.Text, "");

            if (String.IsNullOrWhiteSpace(message.Sid))
            {
                Response.Write("Failed. Twilio returns an empty message ID.");
            }
            else
            {
                Response.Write("Message sent successfully! Message ID: " + message.Sid + "<br />");
            }
        }
    }
}