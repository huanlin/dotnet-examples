using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TwilioTest
{
    public partial class Default : System.Web.UI.Page
    {
        void LoadReceivedMessages()
        {
            lbxMsg.Items.Clear();
            var path = Server.MapPath("~/Logs");
            if (!Directory.Exists(path))
            {                
                return;
            }
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            IEnumerable<System.IO.FileInfo> fileQuery = from file in fileList
                                                        where file.Extension == ".txt"
                                                        orderby file.CreationTime descending 
                                                        select file;
            int count = 0;
            foreach (System.IO.FileInfo fi in fileQuery)
            {
                lbxMsg.Items.Add(fi.FullName);
                count++;
                if (count >= 20)
                {
                    break;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReceivedMessages();
            }
        }

        protected void btnLoadReceivedMsg_Click(object sender, EventArgs e)
        {
            LoadReceivedMessages();
        }

        protected void lbxMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMsg.SelectedIndex < 0)
            {
                lblMsgContent.Text = "";
                return;
            }
            lblMsgContent.Text = File.ReadAllText(lbxMsg.SelectedItem.ToString());
        }
    }
}