using Cryptography.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptography.ViewModel
{
    class RSAViewModel : BaseViewModel
    {
        string decrypted = string.Empty;
        string publicKey = string.Empty;
        string privateKey = string.Empty;

        Command decryptCommand;

        public string PublicKey
        {
            get { return publicKey; }
            set
            {
                publicKey = value;
                OnPropertyChanged(nameof(PublicKey));
            }
        }

        public string PrivateKey
        {
            get { return privateKey; }
            set
            {
                privateKey = value;
                OnPropertyChanged(nameof(PrivateKey));
            }
        }


        public string Decrypted
        {
            get { return decrypted; }
            set
            {
                decrypted = value;
                OnPropertyChanged(nameof(Decrypted));
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
                      string pubKey, privKey;
                          CipherText = Cryptography.logic.RSA.RSAEncrypt(openText, out pubKey, out privKey, false);
                      PublicKey = pubKey;
                      PrivateKey = privKey;
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
                      Decrypted = Cryptography.logic.RSA.RSADecrypt(CipherText, privateKey, false);
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
