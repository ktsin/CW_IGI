using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAppWAPI.ViewModel
{
    public class SetIpViewModel : INotifyPropertyChanged
    {
        public string IpAddress {get; set;}


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void ApplyIp(object sender, EventArgs args)
        {
            if (ValidateIp(IpAddress))
            {

            }
            else
        }
        private static bool ValidateIp(string ip)
        {
            IPAddress t;
            return (IPAddress.TryParse(ip, out t));
                   
        }
    }
}
