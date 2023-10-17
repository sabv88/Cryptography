using Cryptography.logic.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cryptography.ViewModel
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        internal string openText = string.Empty;
        internal string cipherText = string.Empty;
        public IAsyncCommand EncryptCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public string OpenText
        {
            get { return openText; }
            set
            {
                openText = value;
                OnPropertyChanged(nameof(OpenText));
            }
        }

        public string CipherText
        {
            get { return cipherText; }
            set
            {
                cipherText = value;
                OnPropertyChanged(nameof(CipherText));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
