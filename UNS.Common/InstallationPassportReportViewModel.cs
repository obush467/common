using DevExpress.Mvvm;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Common.Entities;
using UNS.Models.Entities;

namespace UNS.Common
{
    public class InstallationPassportReportViewModel : ViewModelBase, IList<InstallationPassportReportData>
    {
        public InstallationPassportReportData this[int index] { get => DataCollection[index]; set => DataCollection[index] = value; }

        public int Count => DataCollection.Count;

        public bool IsReadOnly => true;

        public ObservableCollection<InstallationPassportReportData> DataCollection { get; set; } = new ObservableCollection<InstallationPassportReportData>();
        public void Add(InstallationPassportReportData item)
        {
            DataCollection.Add(item);
        }

        public void Clear()
        {
            DataCollection.Clear();
        }

        public bool Contains(InstallationPassportReportData item)
        {
            return DataCollection.Contains(item);
        }

        public void CopyTo(InstallationPassportReportData[] array, int arrayIndex)
        {
            DataCollection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<InstallationPassportReportData> GetEnumerator()
        {
            return DataCollection.GetEnumerator();
        }

        public int IndexOf(InstallationPassportReportData item)
        {
            return DataCollection.IndexOf(item);
        }

        public void Insert(int index, InstallationPassportReportData item)
        {
            DataCollection.Insert(index, item);
        }

        public bool Remove(InstallationPassportReportData item)
        {
            return DataCollection.Remove(item);
        }

        public void RemoveAt(int index)
        {
            DataCollection.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return DataCollection.GetEnumerator();
        }
    }
}
