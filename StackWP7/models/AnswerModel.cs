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
using System.Text.RegularExpressions;

namespace StackWP7.models
{
    [DataContract]
    public class AnswerModel
    {
        private int _answer_id = 0;
        [DataMember]
        public int answer_id
        {
            get
            {
                return _answer_id;
            }
            set
            {
                if (value != _answer_id)
                {
                    _answer_id = value;
                }
            }
        }

        private Boolean _accepted = false;
        [DataMember]
        public Boolean accepted
        {
            get
            {
                return _accepted;
            }
            set
            {
                if (value != _accepted)
                {
                    _accepted = value;
                }
            }
        }

        private String _answer_comments_url = "";
        [DataMember]
        public String answer_comments_url
        {
            get
            {
                return _answer_comments_url;
            }
            set
            {
                if (value != _answer_comments_url)
                {
                    _answer_comments_url = value;
                }
            }
        }

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

        private String _title = "";
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
                }
            }
        }

        public string Strip(string text)
        {
            return Regex.Replace(text, "<(.|\n)+?>", string.Empty);
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
                    _body = Strip(value);
                }
            }
        }
    }
}
