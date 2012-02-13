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
using System.IO;
using System.Text;


namespace StackWP7.models
{
    [DataContract]
    public class QuestionModel
    {
        private int _question_id = 0;
        [DataMember]
        public int question_id
        {
            get
            {
                return _question_id;
            }
            set
            {
                if (value != _question_id)
                {
                    _question_id = value;
                }
            }
        }

        private int _creation_date = 0;
        [DataMember]
        public int creation_date
        {
            get
            {
                return _creation_date;
            }
            set
            {
                if (value != _creation_date)
                {
                    _creation_date = value;
                }
            }
        }

        private int _last_activity_date = 0;
        [DataMember]
        public int last_activity_date
        {
            get
            {
                return _last_activity_date;
            }
            set
            {
                if (value != _last_activity_date)
                {
                    _last_activity_date = value;
                }
            }
        }

        private int _score = 0;
        [DataMember]
        public int score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value != _score)
                {
                    _score = value;
                }
            }
        }

        private int _answer_count = 0;
        [DataMember]
        public int answer_count
        {
            get
            {
                return _answer_count;
            }
            set
            {
                if (value != _answer_count)
                {
                    _answer_count = value;
                }
            }
        }

        private string _title = "";

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

        private string[] _tags = { "" };

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

        private int _view_count = 0;
        [DataMember]
        public int view_count
        {
            get
            {
                return _view_count;
            }
            set
            {
                if (value != _view_count)
                {
                    _view_count = value;
                }
            }
        }

        private OwnerModel _owner;
        [DataMember]
        public OwnerModel owner
        {
            get
            {
                return _owner;
            }
            set
            {
                if (value != _owner)
                {
                    _owner = value;
                }
            }
        }

        private string _link = "";
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

        private String _body = "";
        [DataMember]
        public String body
        {
            get
            {
                return _body;
            }
            set
            {
                if (value != _body)
                {
                    _body = value;
                    NotifyPropertyChanged(ref _body);
                }
            }
        }

        private Boolean _is_answered;
        [DataMember]
        public Boolean is_answered
        {
            get
            {
                return _is_answered;
            }
            set
            {
                if (value != _is_answered)
                {
                    _is_answered = value;
                }
            }
        }

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
