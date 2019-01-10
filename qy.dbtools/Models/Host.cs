using DevExpress.XtraTreeList.Nodes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QY.DBtools.Models
{
    public class Host : HostBase, INotifyPropertyChanged
    {
        public static string HostName = "主机";

        public string Address { get; set; }

        public int Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public bool IsBusy { get; set; }

        [JsonIgnore]
        public bool HasError { get; set; }

        [JsonIgnore]
        public bool IsStatusChanged
        {
            get
            {
                return IsBusy || HasError;
            }
        }

        public void ResetStatus()
        {
            IsBusy = false;
            HasError = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyStatusChanged()
        {
            NotifyChanged(nameof(IsBusy));
            NotifyChanged(nameof(HasError));
        }
    }
}
