using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.ComponentModel;


namespace StackWP7.models
{
    [DataContract]
    public class QuestionModel : INotifyPropertyChanged
    {
        [DataMember]
        public int question_id;

        [DataMember]
        public int creation_date;

        [DataMember]
        public int last_activity_date;

        [DataMember]
        public int score;

        [DataMember]
        public int answer_count;

        private string _title = "title";

        [DataMember]
        public String title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged(ref _title);
                }
            }
        }

        private string[] _tags = { "tags" };

        [DataMember]
        public String[] tags
        {
            get
            {
                return _tags;
            }
            set
            {
                if (value != _tags)
                {
                    _tags = value;
                    NotifyArrayChanged(ref _tags);
                }
            }
        }

        [DataMember]
        public int view_count;

        [DataMember]
        public OwnerModel owner;

        private string _link = "link";

        [DataMember]
        public String link
        {
            get
            {
                return _link;
            }
            set
            {
                if (value != _link)
                {
                    _link = value;
                    NotifyPropertyChanged(ref _link);
                }
            }
        }

        [DataMember]
        public Boolean is_answered;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(ref String propertyName)
        {
            propertyName = HttpUtility.HtmlDecode(propertyName);
        }


        private void NotifyArrayChanged(ref String[] propertyName)
        {
            for (int i = 0; i < propertyName.Length; i++)
            {
                propertyName[i] = HttpUtility.HtmlDecode(propertyName[i]);
            }
        }
    }
}
