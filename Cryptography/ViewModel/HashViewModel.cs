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
    class HashViewModel : BaseViewModel
    {
        string selected;
        public event PropertyChangedEventHandler PropertyChanged;
        public Command getHash;

        public string Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public Command GetHash
        {
            get
            {
                return getHash ??
                  (getHash = new Command(obj =>
                  {
                    switch(obj as string)
                      {
                          case "MD5":
                              CipherText = Hash.MD5(OpenText);
                              break;
                          case "SHA1":
                              CipherText = Hash.SHA1(OpenText);
                              break;
                          case "SHA256":
                              CipherText = Hash.SHA256(OpenText);
                              break;
                          case "SHA384":
                              CipherText = Hash.SHA384(OpenText);
                              break;
                          case "SHA512":
                              CipherText = Hash.SHA512(OpenText);
                              break;
                      }

                  }));
            }
        }
    }
}
