﻿using Models;
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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public PersonWindow(Person person)
        {
            DataContext = this;
            Person = person;
            InitializeComponent();
        }

        public Person Person { get; set; }

        public Array GenderItemsSource { get; } = Enum.GetValues(typeof(Gender));
    }
}
