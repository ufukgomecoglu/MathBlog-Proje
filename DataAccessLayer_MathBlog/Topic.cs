using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class Topic
    {
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
