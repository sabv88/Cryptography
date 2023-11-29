using Cryptography.logic;
using Cryptography.logic.Interfaces;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptography.ViewModel
{
    class HashViewModel : BaseViewModel, IHashViewModel
    {
        string selected;
        public event PropertyChangedEventHandler PropertyChanged;
        public IAsyncCommand GetHash { get; set; }
        IHash Hash;

        public string Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        public HashViewModel(IHash hash) 
        {
            Hash = hash;
            GetHash = new AsyncCommand(async () =>
            {
                try
                {
                    switch (Selected)
                    {
                        case "MD5":
                            await Task.Run(async () =>
                   CipherText = await Hash.MD5(OpenText));
                            break;
                        case "SHA1":
                            await Task.Run(async () =>
                   CipherText = await Hash.SHA1(OpenText));
                            break;
                        case "SHA256":
                            await Task.Run(async () =>
                   CipherText = await Hash.SHA256(OpenText));
                            break;
                        case "SHA384":
                            await Task.Run(async () => CipherText = await Hash.SHA384(OpenText));
                            break;
                        case "SHA512":
                            await Task.Run(async () => CipherText = await Hash.SHA512(OpenText));
                            break;
                    }                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            });
        }
    }
}
