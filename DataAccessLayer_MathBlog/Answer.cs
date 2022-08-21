using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public int AdministratorID { get; set; }
        public DateTime AnswerDate { get; set; }
        public string AnswerContent { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string AuthorityName { get; set; }
    }
}
