using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace binds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ListBoxItemViewModel> options;
        public ObservableCollection<ListBoxItemViewModel> Options
        {
            get { return options; }
            set
            {
                if (options != value)
                {
                    options = value;
                    OnPropertyChanged();
                }
            }
        }

        private ListBoxItemViewModel selectedOption;
        public ListBoxItemViewModel SelectedOption
        {
            get { return selectedOption; }
            set
            {
                if (selectedOption != value)
                {
                    selectedOption = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Options = new ObservableCollection<ListBoxItemViewModel>
            {
                new ListBoxItemViewModel("Option 1", "C:\\Users\\Vlados\\Documents\\cats.jpg"),
                new ListBoxItemViewModel("Option 2", "C:\\Users\\Vlados\\Documents\\GettyImages-172050389-8ab8710.jpg"),
                new ListBoxItemViewModel("Option 3", "C:\\Users\\Vlados\\Documents\\manul-1.jpg")
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ListBoxItemViewModel
    {
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public ListBoxItemViewModel(string content, string imagePath)
        {
            Content = content;
            ImagePath = imagePath;
        }
    }
}