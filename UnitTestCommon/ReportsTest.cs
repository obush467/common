using DevExpress.XtraReports.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Common;
using UNS.Models.Entities;
using DevExpress.Xpf.Printing;
using DevExpress.Data;
using UNS.Common.Entities;

namespace UnitTestCommon
{
    [TestClass]
    public class ReportsTest
    {
        [TestMethod]
        public void P()
        {
            UNS.Common.InstallationPassportReport report = new UNS.Common.InstallationPassportReport
            {
                DataSource = new InstallationPassportReportViewModel()
                {
                    DataCollection = new System.Collections.ObjectModel.ObservableCollection<InstallationPassportReportData>(
             new List<InstallationPassportReportData> {
                 { new InstallationPassportReportData()
                 {
                     UNIU = "fghfghfgh",
                     AddressObject = "fghfghfgh",
                     AddressHouse = "ggfhfghf",
                     Contacts = string.Concat(Enumerable.Repeat("dsdf sdfsdf sdf sdfsdsfsdfs sdfsdfsdf sdfsdf sdf sdfsdf sfsfsdfsdfsd sfghfghfghf fgh fgh fghfgh  fghfgh fgh", 5)),
                     DislocationPath="C:\\Users\\Bushmakin\\Pictures\\1111.png"
                 }
                 },
                              { new InstallationPassportReportData()
                 {
                     UNIU = "fghfghfgh",
                     AddressObject = "fghfghfgh",
                     AddressHouse = "ggfhfghf",
                     Contacts = string.Concat(Enumerable.Repeat("dsdf sdfsdf sdf sdfsdsfsdfs sdfsdfsdf sdfsdf sdf sdfsdf sfsfsdfsdfsd sfghfghfghf fgh fgh fghfgh  fghfgh fgh", 5)),
                     DislocationPath="C:\\Users\\Bushmakin\\Pictures\\1111.png"
                 }
                 },
                              { new InstallationPassportReportData()
                 {
                     UNIU = "fghfghfgh",
                     AddressObject = "fghfghfgh",
                     AddressHouse = "ggfhfghf",
                     Contacts = string.Concat(Enumerable.Repeat("dsdf sdfsdf sdf sdfsdsfsdfs sdfsdfsdf sdfsdf sdf sdfsdf sfsfsdfsdfsd sfghfghfghf fgh fgh fghfgh  fghfgh fgh", 5)),
                     DislocationPath="C:\\Users\\Bushmakin\\Pictures\\1111.png"
                 }
                 }})
                }
            };
            PrintHelper.Print(report);
        }
    }
}
