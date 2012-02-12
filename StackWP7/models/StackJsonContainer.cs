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
using StackWP7.models;

namespace StackWP7
{

    [DataContract]
    public class StackJsonContainer
    {
        [DataMember]
        public QuestionModel[] items;

        [DataMember]
        public int quote_remaining;

        [DataMember]
        public int quota_max;

        public Boolean has_more;
    }
}
