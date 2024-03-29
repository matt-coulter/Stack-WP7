﻿using System;
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
            this.Items2 = new ObservableCollection<FullQuestionModel>();
            this.answers = new ObservableCollection<AnswerModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<QuestionModel> Items { get; private set; }
        public ObservableCollection<FullQuestionModel> Items2 { get; private set; }
        public ObservableCollection<AnswerModel> answers { get; private set; }

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

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadQuestion(int id)
        {
            WebClient webClient = new SharpGIS.GZipWebClient();

            webClient.DownloadStringCompleted += onQuestionLoaded;

            webClient.DownloadStringAsync(new Uri("http://api.stackoverflow.com/1.1/questions/" + id + "?body=true&answers=true", UriKind.Absolute));

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
                if (Items.Count == 0)
                {
                    QuestionModel q = new QuestionModel();
                    q.title = "No Results Found";
                    this.Items.Add(q);
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

        private void onQuestionLoaded(object sender, DownloadStringCompletedEventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                String myStr = e.Result;
                ms.Write(StrToByteArray(myStr), 0, myStr.Length);

                ms.Position = 0;

                // deserialization
                QuestionWrapper questions = (QuestionWrapper)Deserialize(ms, typeof(QuestionWrapper));
                ms.Close();

                this.Items2.Clear();
                foreach (FullQuestionModel question in questions.questions)
                {
                    this.Items2.Add(question);
                    this.answers.Clear();
                    foreach (AnswerModel answer in question.answers)
                    {
                        this.answers.Add(answer);
                    }
                }
                if (Items2.Count == 0)
                {
                    FullQuestionModel q = new FullQuestionModel();
                    q.title = "No Results Found";
                    this.Items2.Add(q);
                }

            }
            catch (Exception error)
            {
                this.Items2.Clear();
                FullQuestionModel q = new FullQuestionModel();
                q.title = "Error Code 1";
                q.body = error.Message;
                this.Items2.Add(q);
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