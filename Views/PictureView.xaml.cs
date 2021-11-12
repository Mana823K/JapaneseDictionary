using System;
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
using Dictionary.Services;
using Dictionary.Commands;

namespace Dictionary.Views
{
    /// <summary>
    /// Interaction logic for PictureView.xaml
    /// </summary>
    public partial class PictureView : UserControl
    {

        public PictureView()
        {
            InitializeComponent();

            DataContext = new PictureViewModel();
        }
    }
}
