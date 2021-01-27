using Models;
using Services.DAL.Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Person> people;

        private IServiceAsync<Person> Service { get; } = new CrudServiceAsync<Person>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<Person> People
        {
            get => people;
            set
            {
                people = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(People)));
            }
        }
        public Person SelectedPerson { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            People = new ObservableCollection<Person> ( await Service.ReadAsync() );
        }
        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PersonWindow(SelectedPerson);
            dialog.ShowDialog();

            await Service.UpdateAsync(SelectedPerson.Id, SelectedPerson);
        }
    }
}
