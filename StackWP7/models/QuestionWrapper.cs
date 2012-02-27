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

namespace StackWP7.models
{
    [DataContract]
    public class QuestionWrapper
    {
        private int _total = 0;
        [DataMember]
        public int total
        {
            get
            {
                return _total;
            }
            set
            {
                if (value != _total)
                {
                    _total = value;
                }
            }
        }

        private int _page = 0;
        [DataMember]
        public int page
        {
            get
            {
                return _page;
            }
            set
            {
                if (value != _page)
                {
                    _page = value;
                }
            }
        }

        private int _pagesize = 0;
        [DataMember]
        public int pagesize
        {
            get
            {
                return _pagesize;
            }
            set
            {
                if (value != _pagesize)
                {
                    _pagesize = value;
                }
            }
        }

        private FullQuestionModel[] _questions;
        [DataMember]
        public FullQuestionModel[] questions
        {
            get
            {
                return _questions;
            }
            set
            {
                if (value != _questions)
                {
                    _questions = value;
                }
            }
        }
    }
}
