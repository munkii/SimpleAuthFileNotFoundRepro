using SimpleAuth.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthFileNotFoundRepro.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FitBitApi api;
        private string simpleProperty;

        public MainViewModel()
        {
            this.api = new FitBitApi(
                           "fitbit",
                           "Clientid",
                           "Clientsecret",
                           false,
                           "projectbreathe://loggedin")
            {
                Scopes = "activity weight heartrate sleep".Split(' ').ToArray(),
                AutoAuthenticate = false,
                EnsureApiStatusCode = false
            };

            this.SimpleProperty = "Hello World";
        }
        
        public string SimpleProperty
        {
            get { return simpleProperty ; }
            set
            {
                if (simpleProperty != value)
                {
                    simpleProperty = value;
                    OnPropertyChanged();
                }
            }
        }

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
