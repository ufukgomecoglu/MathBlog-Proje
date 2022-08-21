using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class Administrator
    {
        public int AdministratorID { get; set; }
        public int AuthorityID { get; set; }
        public string AuthorityName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Eposta { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
