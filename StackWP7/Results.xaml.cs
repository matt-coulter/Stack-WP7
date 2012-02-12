using System;
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
using StackWP7.models;
using System.Windows.Navigation;

namespace StackWP7
{
    public partial class Results : PhoneApplicationPage
    {
        public Results()
        {
            InitializeComponent();
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string query;
            if (NavigationContext.QueryString.TryGetValue("query", out query))
            {
                App.ViewModel.LoadData(query);
            }
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            NavigationService.Navigate(new Uri("/Question.xaml?questionID=" + ((QuestionModel)MainListBox.SelectedItem).question_id, UriKind.Relative));
            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }
    }
}