using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using SharpGIS;

namespace StackWP7.models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<QuestionModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<QuestionModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData(string query)
        {
            WebClient webClient = new  SharpGIS.GZipWebClient();

            webClient.DownloadStringCompleted += onLoaded;

            query = HttpUtility.UrlEncode(query);

            webClient.DownloadStringAsync(new Uri("http://api.stackexchange.com/2.0/search?order=desc&sort=relevance&pagesize=15&intitle="+query+"&site=stackoverflow", UriKind.Absolute));

            this.IsDataLoaded = true;
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static object Deserialize(Stream stream, Type serializedObject)
        {
            if (null == serializedObject || null == stream) { return null; }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializedObject);
            return ser.ReadObject(stream);
        }

        private void onLoaded(object sender, DownloadStringCompletedEventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                String myStr = e.Result;
                ms.Write(StrToByteArray(myStr), 0, myStr.Length);

                ms.Position = 0;

                // deserialization
                StackJsonContainer questions = (StackJsonContainer)Deserialize(ms, typeof(StackJsonContainer));
                ms.Close();

                this.Items.Clear();
                foreach (QuestionModel question in questions.items)
                {
                    this.Items.Add(question);
                }

            }
            catch (Exception error)
            {
                this.Items.Clear();
                QuestionModel q = new QuestionModel();
                q.title = "Error Code 1";
                q.link = error.Message;
                this.Items.Add(q);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}