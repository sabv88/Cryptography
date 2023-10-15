using Cryptography.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Windows;

namespace Cryptography.ViewModel
{
    internal class AESViewModel : BaseViewModel
    {
        string key = string.Empty;
        string iv = string.Empty;
        string decryptedText = string.Empty;
        Command decryptCommand;
        public event PropertyChangedEventHandler PropertyChanged;


        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public string IV
        {
            get { return iv; }
            set
            {
                iv = value;
                OnPropertyChanged(nameof(IV));
            }
        }

        public string DecryptedText
        {
            get { return decryptedText; }
            set
            {
                decryptedText = value;
                OnPropertyChanged(nameof(DecryptedText));
            }
        }

        public Command EncryptCommand
        {
            get
            {
                return encryptCommand ??
                 (encryptCommand = new Command(obj =>
                    {
                        try
                        {
                            string localKey, localIv, localCipher;
                            AES.AESEncrypt(openText, out localCipher, out localKey, out localIv);
                            CipherText = localCipher;
                            Key = localKey;
                            IV = localIv;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }));

            }
        }

        public Command DecryptCommand
        {
            get
            {
                return decryptCommand ??
                  (decryptCommand = new Command(obj =>
                  {
                      try
                      {
                          DecryptedText = AES.AESDecrypt(CipherText, Key, IV);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
    }
}
