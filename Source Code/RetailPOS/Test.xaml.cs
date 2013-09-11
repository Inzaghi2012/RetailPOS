using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;

namespace RetailPOS
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            this.DataContext = new TestViewModel();
        }
    }

    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _IsOpen;
        private string _IsKeyBoardOpen;

        public bool IsOpen
        {
            get { return _IsOpen; }
            set
            {
                _IsOpen = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsOpen"));
                //OpenKeyboard();
            }
        }
        public string IsKeyBoardOpen
        {
            get { return _IsKeyBoardOpen; }
            set
            {
                _IsKeyBoardOpen = value;
                //RaisePropertyChanged("IsKeyBoardOpen");
            }
        }
        private void OpenKeyboard()
        {
            IsKeyBoardOpen = "True";
        }
    }
}
