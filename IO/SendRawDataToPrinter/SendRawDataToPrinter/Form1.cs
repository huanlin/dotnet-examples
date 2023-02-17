using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SendRawDataToPrinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog(this))
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    // Print the file to the printer.
                    RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text + "\r\n";

            // Allow the user to select a printer.
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                // Send a printer-specific to the printer.
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }
        }
    }
}
