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
using System.Windows.Navigation;

namespace StackWP7
{
    public partial class Question : PhoneApplicationPage
    {
        public Question()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String query;
            if (NavigationContext.QueryString.TryGetValue("questionID", out query))
            {
                App.ViewModel.LoadQuestion(Convert.ToInt32(query));
            }
        }

        private void StackPanel_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}