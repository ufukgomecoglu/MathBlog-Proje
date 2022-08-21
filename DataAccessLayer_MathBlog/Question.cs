using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public int AdministratorID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string AuthorityName { get; set; }
        public string Summary { get; set; }
        public string FullContent { get; set; }
        public string ThumbnailName { get; set; }
        public string FullPictureName { get; set; }
        public DateTime LoadingDate { get; set; }
        public int Seen { get; set; }
        public bool IsDeleted { get; set; }


    }
}
