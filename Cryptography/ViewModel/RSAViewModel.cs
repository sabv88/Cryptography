using Cryptography.logic;
using Cryptography.logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cryptography.ViewModel
{
    class RSAViewModel : BaseViewModel, IRSAViewModel
    {
        string decrypted = string.Empty;
        string publicKey = string.Empty;
        string privateKey = string.Empty;
        public IAsyncCommand DecryptCommand { get; set; }
        IRSA RSA;

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

       public RSAViewModel(IRSA rsa) 
        {

            RSA = rsa;
            EncryptCommand = new AsyncCommand(async () =>
            {
                try
                {
                    Task<(string cipherText, string PublicKey, string PrivateKey)> a = default;
                    await Task.Run(() =>
                    a = RSA.RSAEncrypt(openText, false));
                    PublicKey = a.Result.PublicKey;
                    PrivateKey = a.Result.PrivateKey;
                    CipherText = a.Result.cipherText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            DecryptCommand = new AsyncCommand(async () =>
            {
                try
                {
                    Decrypted = await Task.Run(() =>
                  RSA.RSADecrypt(CipherText, PrivateKey, false));
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }
    }
}
