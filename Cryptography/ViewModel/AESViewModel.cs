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
using System.Security.Policy;
using Cryptography.logic.Interfaces;

namespace Cryptography.ViewModel
{
    internal class AESViewModel : BaseViewModel
    {
        string key = string.Empty;
        string iv = string.Empty;
        string decryptedText = string.Empty;
        public IAsyncCommand DecryptCommand { get; set; }
        IAES AES;

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



        public AESViewModel(IAES aES)
        {
            AES = aES;
            EncryptCommand = new AsyncCommand(async () =>
            {
                try
                {

                    Task<(string cipherText, string Key, string IV)> a = default;
                    await Task.Run(() =>
                        
                     a =  AES.AESEncrypt(OpenText));

                    CipherText = a.Result.cipherText;
                    Key = a.Result.Key;
                    IV = a.Result.IV;
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
                    DecryptedText = await Task.Run(
                        () => 
                        
                        AES.AESDecrypt(CipherText, Key, IV)
                        
                        
                        );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });



        }
    }
}
