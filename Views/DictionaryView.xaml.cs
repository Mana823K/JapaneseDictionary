﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dictionary.ViewModels;

namespace Dictionary.Views
{
    /// <summary>
    /// Interaction logic for DictionaryView.xaml
    /// </summary>
    public partial class DictionaryView : UserControl
    {
        public DictionaryView()
        {
            InitializeComponent();

            DictionaryViewModel vm = new DictionaryViewModel();
            DataContext = vm;
        }
    }
}
