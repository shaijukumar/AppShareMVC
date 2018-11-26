using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppShare.Models
{
    public class SubTopics
    {
        public int Id { get; set; }        
        public string Title { get; set; }

        //public MainTopics MainTopic { get; set; }
        public int MainTopicId { get; set; }
    }
}