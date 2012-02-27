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
    public class OwnerModel
    {
        [DataMember]
        public int user_id
        {
            get;
            set;
        }

        [DataMember]
        public String display_name
        {
            get;
            set;
        }

        [DataMember]
        public int reputation
        {
            get;
            set;
        }

        [DataMember]
        public String user_type
        {
            get;
            set;
        }

        [DataMember]
        public String profile_image
        {
            get;
            set;
        }

        [DataMember]
        public String link
        {
            get;
            set;
        }

        [DataMember]
        public int accept_rate
        {
            get;
            set;
        }
    }
}
