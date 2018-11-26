using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppShare.Models
{
    public class SiteContent
    {
        public int Id { get; set; }
        public string TitleURL { get; set; }

        public ContentTopics Topic { get; set; }
        public int TopicId { get; set; }

       
        public string Title { get; set; }

        public SiteContentStatus Status { get; set; }
        public int StatusId { get; set; }

        public string DocumentHTML  { get; set; }
    }
}