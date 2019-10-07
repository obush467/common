using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace UNS.Common
{
    public partial class InstallationPassportReport : DevExpress.XtraReports.UI.XtraReport
    {
        public InstallationPassportReport()
        {
            InitializeComponent();
        }

        private void XrTableCell11_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
