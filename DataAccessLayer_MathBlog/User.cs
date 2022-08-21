using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Eposta { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public DateTime MembershipDate { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public int Commentnumber { get; set; }
        public int QuestionNumber { get; set; }
    }
}
