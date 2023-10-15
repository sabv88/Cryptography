using Cryptography.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cryptography.ViewModel
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        internal string openText = string.Empty;
        internal string cipherText = string.Empty;
        internal Command encryptCommand;
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
