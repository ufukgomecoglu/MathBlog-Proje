using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int AnswerID { get; set; }
        public int UserID { get; set; }
        public int AdministratorID { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string AuthorityName { get; set; }
        

    }
}
