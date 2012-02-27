using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace StackWP7.models
{
    [DataContract]
    public class FullQuestionModel
    {
        [DataMember]
        private String[] _tags = {""};
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
                }
            }
        }

        [DataMember]
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

        [DataMember]
        private AnswerModel[] _answers;
        [DataMember]
        public AnswerModel[] answers
        {
            get
            {
                return _answers;
            }
            set
            {
                if (value != _answers)
                {
                    _answers = value;
                }
            }
        }

        [DataMember]
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
