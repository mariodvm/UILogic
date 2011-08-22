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
using UILogic;
using System.ComponentModel;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var person = new Person{ Name = "Mario", Email = "mariodvm@gmail.com", Age = 31 };

            DataContext = new PersonHomeView(person, this);
        }
    }

    public class Person : UIObject
    {
        string _Name;
        public string Name
        {
            get { return _Name; }
            set 
            { 
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        int _Age;
        public int Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                OnPropertyChanged("Age");
            }
        }
    }

}
