﻿using Cryptography.logic;
using Cryptography.logic.Interfaces;
using Cryptography.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptography
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IAESViewModel aes, IRSAViewModel rsa, IHashViewModel hash)
        {
            InitializeComponent();
            AESGrid.DataContext = aes;
            HashGrid.DataContext = hash;
            RSAGrid.DataContext = rsa;
        }
    }
}
