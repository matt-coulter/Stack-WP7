﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace StackWP7
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
        }

        private void callQuery()
        {
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/Results.xaml?query=" + SearchQuery.Text, UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            callQuery();
        }

        private void SearchQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                callQuery();
            }
        }
     
    }
}