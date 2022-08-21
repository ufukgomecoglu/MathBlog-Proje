using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_MathBlog
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }
        #region Methods
        public bool UniqueEposta(string eposta)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Administrators WHERE Eposta=@eposta ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UniqueTopic(string name)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Topics WHERE TopicName=@TopicName ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicName", name);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool ValidEposta(string eposta)
        {
            if (eposta.Contains('@') && eposta.Contains(".com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string ZeroAndDigit(string text)
        {
            bool key = true;
            if (text.Length == 11)
            {
                key = true;
            }
            else
            {
                key = false;
            }
            if (text[0] == '0' && key == true)
            {
                key = true;
            }
            else
            {
                key = false;
            }
            if (text[1] == '5' && key == true)
            {
                key = true;
            }
            else
            {
                key = false;
            }

            if (key == true)
            {
                return text;
            }
            else
            {
                return null;
            }
        }
        public string NumberValidation(string text)
        {
            bool key = true;
            for (int i = 0; i < text.Length; i++)
            {
                int number = (int)text[i];
                if (number >= 48 && number <= 57)
                {
                    key = true;
                }
                else
                {
                    key = false;
                    break;
                }
            }
            if (key == true)
            {
                return text;
            }
            else
            {
                return null;
            }
        }
        public string NullControl(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                return text;
            }
            else
            {
                return null;
            }
        }

        public int FindNumberOfQuestion(int userID)
        {
            try
            {

                cmd.CommandText = "SELECT  COUNT (*) FROM Questions WHERE UserID = @UserID AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", userID);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                return number;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public int FindNumberOfComments(int userID)
        {
            try
            {
                cmd.CommandText = "SELECT  COUNT (*) FROM Comments WHERE UserID = @UserID AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", userID);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                return number;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Question> ShowQuestionAdmin(int questionID)
        {
            try
            {
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.AdministratorID,AD.Name,AD.UserName,A.AuthorityName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Administrators AS AD ON Q.AdministratorID=AD.AdministratorID JOIN Authorities AS A ON A.AuthorityID=AD.AuthorityID WHERE Q.QuestionID=@QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                List<Question> questions = new List<Question>();
                Question question = new Question();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    question.QuestionID = reader.GetInt32(0);
                    question.TopicID = reader.GetInt32(1);
                    question.TopicName = reader.GetString(2);
                    question.AdministratorID = reader.GetInt32(3);
                    question.Name = reader.GetString(4);
                    question.UserName = reader.GetString(5);
                    question.AuthorityName = reader.GetString(6);
                    question.Summary = reader.GetString(7);
                    question.FullContent = reader.GetString(8);
                    question.ThumbnailName = reader.GetString(9);
                    question.FullPictureName = reader.GetString(10);
                    question.LoadingDate = reader.GetDateTime(11);
                    if (!reader.IsDBNull(12))
                    {
                        question.Seen = reader.GetInt32(12);
                    }
                    else
                    {
                        question.Seen = 0;
                    }
                    question.IsDeleted = reader.GetBoolean(13);
                    questions.Add(question);
                }

                return questions;


            }
            catch (Exception)
            {
                return null;

            }
            finally
            {
                con.Close();
            }
        }
        public List<Question> ShowQuestionUser(int questionID)
        {
            try
            {
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.UserID,U.Name,U.UserName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Users AS U ON Q.UserID=U.UserID WHERE Q.QuestionID=@QuestionID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                List<Question> questions = new List<Question>();
                Question question = new Question();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    question.QuestionID = reader.GetInt32(0);
                    question.TopicID = reader.GetInt32(1);
                    question.TopicName = reader.GetString(2);
                    question.UserID = reader.GetInt32(3);
                    question.Name = reader.GetString(4);
                    question.UserName = reader.GetString(5);
                    question.AuthorityName = "User";
                    question.Summary = reader.GetString(6);
                    question.FullContent = reader.GetString(7);
                    question.ThumbnailName = reader.GetString(8);
                    question.FullPictureName = reader.GetString(9);
                    question.LoadingDate = reader.GetDateTime(10);
                    if (!reader.IsDBNull(11))
                    {
                        question.Seen = reader.GetInt32(11);
                    }
                    else
                    {
                        question.Seen = 0;
                    }
                    question.IsDeleted = reader.GetBoolean(12);
                    questions.Add(question);
                }
                return questions;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Question> GetQuestionByTopic(int topicid)
        {
            try
            {
                List<Question> questions = new List<Question>();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.AdministratorID,AD.Name,AD.UserName,A.AuthorityName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Administrators AS AD ON Q.AdministratorID=AD.AdministratorID JOIN Authorities AS A ON A.AuthorityID=AD.AuthorityID WHERE Q.TopicID=@TopicID AND Q.IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicID", topicid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question question = new Question();
                    question.QuestionID = reader.GetInt32(0);
                    question.TopicID = reader.GetInt32(1);
                    question.TopicName = reader.GetString(2);
                    question.AdministratorID = reader.GetInt32(3);
                    question.Name = reader.GetString(4);
                    question.UserName = reader.GetString(5);
                    question.AuthorityName = reader.GetString(6);
                    question.Summary = reader.GetString(7);
                    question.FullContent = reader.GetString(8);
                    question.ThumbnailName = reader.GetString(9);
                    question.FullPictureName = reader.GetString(10);
                    question.LoadingDate = reader.GetDateTime(11);
                    if (!reader.IsDBNull(12))
                    {
                        question.Seen = reader.GetInt32(12);
                    }
                    else
                    {
                        question.Seen = 0;
                    }
                    question.IsDeleted = reader.GetBoolean(13);
                    questions.Add(question);
                }
                con.Close();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.UserID,U.Name,U.UserName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Users AS U ON Q.UserID=U.UserID WHERE Q.TopicID=@TopicID AND Q.IsDeleted=0 ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicID", topicid);
                con.Open();
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    Question question = new Question();
                    question.QuestionID = reader1.GetInt32(0);
                    question.TopicID = reader1.GetInt32(1);
                    question.TopicName = reader1.GetString(2);
                    question.UserID = reader1.GetInt32(3);
                    question.Name = reader1.GetString(4);
                    question.UserName = reader1.GetString(5);
                    question.AuthorityName = "User";
                    question.Summary = reader1.GetString(6);
                    question.FullContent = reader1.GetString(7);
                    question.ThumbnailName = reader1.GetString(8);
                    question.FullPictureName = reader1.GetString(9);
                    question.LoadingDate = reader1.GetDateTime(10);
                    if (!reader1.IsDBNull(11))
                    {
                        question.Seen = reader1.GetInt32(11);
                    }
                    else
                    {
                        question.Seen = 0;
                    }
                    question.IsDeleted = reader1.GetBoolean(12);
                    questions.Add(question);
                }

                return questions;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public bool SendMailForgot(string eposta, string otp)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("ufuk.gomecoglu@hotmail.com");
                mailMessage.To.Add(eposta);
                mailMessage.Subject = "New Password | mathblog";
                mailMessage.Body = $"Your new password {otp}";
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential("ufuk.gomecoglu@hotmail.com", "ufuk1991");
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
        #region EntryMethods
        public Administrator Login(string eposta, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Administrators WHERE Eposta=@eposta AND Password=@password AND IsDeleted=0";
                cmd.Parameters.AddWithValue("@eposta", eposta);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT AD.AdministratorID,AD.AuthorityID,AU.AuthorityName,AD.Name,AD.SecondName,AD.Surname,AD.UserName,AD.Eposta,AD.Password,AD.MobilePhone,AD.IsDeleted  FROM Administrators AS AD JOIN Authorities AS AU ON AD.AuthorityID = AU.AuthorityID WHERE AD.Eposta=@eposta";
                cmd.Parameters.AddWithValue("@eposta", eposta);
                con.Open();
                if (number > 0)
                {
                    Administrator administrator = new Administrator();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        administrator.AdministratorID = reader.GetInt32(0);
                        administrator.AuthorityID = reader.GetInt32(1);
                        administrator.AuthorityName = reader.GetString(2);
                        administrator.Name = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                        {
                            administrator.SecondName = reader.GetString(4);
                        }
                        administrator.Surname = reader.GetString(5);
                        administrator.UserName = reader.GetString(6);
                        administrator.Eposta = reader.GetString(7);
                        administrator.Password = reader.GetString(8);
                        administrator.MobilePhone = reader.GetString(9);
                        administrator.IsDeleted = reader.GetBoolean(10);
                    }
                    return administrator;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Administrator IForgotMyPassword(string eposta, string usurName)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Administrators WHERE Eposta=@eposta AND Username=@Username AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                cmd.Parameters.AddWithValue("@Username", usurName);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT AD.AdministratorID,AD.AuthorityID,AU.AuthorityName,AD.Name,AD.SecondName,AD.Surname,AD.UserName,AD.Eposta,AD.Password,AD.MobilePhone,AD.IsDeleted  FROM Administrators AS AD JOIN Authorities AS AU ON AD.AuthorityID = AU.AuthorityID WHERE AD.Eposta=@eposta";
                cmd.Parameters.AddWithValue("@eposta", eposta);
                con.Open();
                if (number > 0)
                {
                    Administrator administrator = new Administrator();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        administrator.AdministratorID = reader.GetInt32(0);
                        administrator.AuthorityID = reader.GetInt32(1);
                        administrator.AuthorityName = reader.GetString(2);
                        administrator.Name = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                        {
                            administrator.SecondName = reader.GetString(4);
                        }
                        administrator.Surname = reader.GetString(5);
                        administrator.UserName = reader.GetString(6);
                        administrator.Eposta = reader.GetString(7);
                        administrator.Password = reader.GetString(8);
                        administrator.MobilePhone = reader.GetString(9);
                        administrator.IsDeleted = reader.GetBoolean(10);
                    }
                    return administrator;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public User IForgotMyPasswordUser(string eposta, string usurName)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Eposta=@eposta AND Username=@Username AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                cmd.Parameters.AddWithValue("@Username", usurName);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                cmd.CommandText = "SELECT * FROM Users WHERE Eposta=@Eposta";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                con.Open();
                if (number > 0)
                {
                    User user = new User();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.SecondName = reader.GetString(2);
                        user.Surname = reader.GetString(3);
                        user.UserName = reader.GetString(4);
                        user.Eposta = reader.GetString(5);
                        user.Password = reader.GetString(6);
                        user.MobilePhone = reader.GetString(7);
                        user.MembershipDate = reader.GetDateTime(8);
                        user.Birthdate = reader.GetDateTime(9);
                        user.IsDeleted = reader.GetBoolean(10);
                    }
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public User LoginUser(string eposta, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Eposta=@eposta AND Password=@password AND IsDeleted=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                cmd.CommandText = "SELECT * FROM Users WHERE Eposta=@Eposta";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                con.Open();
                if (number > 0)
                {
                    User user = new User();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.SecondName = reader.GetString(2);
                        user.Surname = reader.GetString(3);
                        user.UserName = reader.GetString(4);
                        user.Eposta = reader.GetString(5);
                        user.Password = reader.GetString(6);
                        user.MobilePhone = reader.GetString(7);
                        user.MembershipDate = reader.GetDateTime(8);
                        user.Birthdate = reader.GetDateTime(9);
                        user.IsDeleted = reader.GetBoolean(10);
                    }
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion
        #region AddMethods
        public bool AddAdministrator(Administrator administrator)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Administrators(AuthorityID,Name,SecondName,Surname,UserName,Eposta,Password,MobilePhone,IsDeleted) VALUES (@AuthorityID,@Name,@SecondName,@Surname,@UserName,@Eposta,@Password,@MobilePhone,@IsDeleted) ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AuthorityID", administrator.AuthorityID);
                cmd.Parameters.AddWithValue("@Name", administrator.Name);
                cmd.Parameters.AddWithValue("@SecondName", administrator.SecondName);
                cmd.Parameters.AddWithValue("@Surname", administrator.Surname);
                cmd.Parameters.AddWithValue("@UserName", administrator.UserName);
                cmd.Parameters.AddWithValue("@Eposta", administrator.Eposta);
                cmd.Parameters.AddWithValue("@Password", administrator.Password);
                cmd.Parameters.AddWithValue("@MobilePhone", administrator.MobilePhone);
                cmd.Parameters.AddWithValue("@IsDeleted", administrator.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddUser(User user)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Users(Name,SecondName,Surname,UserName,Eposta,Password,MobilePhone,MembershipDate,Birthdate,IsDeleted) VALUES(@Name,@SecondName,@Surname,@UserName,@Eposta,@Password,@MobilePhone,@MembershipDate,@Birthdate,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@SecondName", user.SecondName);
                cmd.Parameters.AddWithValue("@Surname", user.Surname);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Eposta", user.Eposta);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@MobilePhone", user.MobilePhone);
                cmd.Parameters.AddWithValue("@MembershipDate", user.MembershipDate);
                cmd.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                cmd.Parameters.AddWithValue("@IsDeleted", user.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddTopic(Topic topic)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Topics(TopicName,IsDeleted) VALUES(@TopicName,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicName", topic.TopicName);
                cmd.Parameters.AddWithValue("@IsDeleted", topic.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddQuestionAdmin(Question question)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Questions(AdministratorID,TopicID,Summary,FullContent,ThumbnailName,FullPictureName,LoadingDate,Seen,IsDeleted) VALUES(@AdministratorID,@TopicID,@Summary,@FullContent,@ThumbnailName,@FullPictureName,@LoadingDate,@Seen,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AdministratorID", question.AdministratorID);
                cmd.Parameters.AddWithValue("@TopicID", question.TopicID);
                cmd.Parameters.AddWithValue("@Summary", question.Summary);
                cmd.Parameters.AddWithValue("@FullContent", question.FullContent);
                cmd.Parameters.AddWithValue("@ThumbnailName", question.ThumbnailName);
                cmd.Parameters.AddWithValue("@FullPictureName", question.FullPictureName);
                cmd.Parameters.AddWithValue("@LoadingDate", question.LoadingDate);
                cmd.Parameters.AddWithValue("@Seen", question.Seen);
                cmd.Parameters.AddWithValue("@IsDeleted", question.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddQuestionUser(Question question)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Questions(UserID,TopicID,Summary,FullContent,ThumbnailName,FullPictureName,LoadingDate,Seen,IsDeleted) VALUES(@UserID,@TopicID,@Summary,@FullContent,@ThumbnailName,@FullPictureName,@LoadingDate,@Seen,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", question.UserID);
                cmd.Parameters.AddWithValue("@TopicID", question.TopicID);
                cmd.Parameters.AddWithValue("@Summary", question.Summary);
                cmd.Parameters.AddWithValue("@FullContent", question.FullContent);
                cmd.Parameters.AddWithValue("@ThumbnailName", question.ThumbnailName);
                cmd.Parameters.AddWithValue("@FullPictureName", question.FullPictureName);
                cmd.Parameters.AddWithValue("@LoadingDate", question.LoadingDate);
                cmd.Parameters.AddWithValue("@Seen", question.Seen);
                cmd.Parameters.AddWithValue("@IsDeleted", question.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddAnswer(Answer answer)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Answers(QuestionID,AdministratorID,AnswerDate,AnswerContent,IsDeleted) VALUES(@QuestionID,@AdministratorID,@AnswerDate,@AnswerContent,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", answer.QuestionID);
                cmd.Parameters.AddWithValue("@AdministratorID", answer.AdministratorID);
                cmd.Parameters.AddWithValue("@AnswerDate", answer.AnswerDate);
                cmd.Parameters.AddWithValue("@AnswerContent", answer.AnswerContent);
                cmd.Parameters.AddWithValue("@IsDeleted", answer.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddComment(Comment comment)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Comments(AnswerID,AdministratorID,CommentContent,CommetDate,IsDeleted) VALUES(@AnswerID,@AdministratorID,@CommentContent,@CommetDate,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AnswerID", comment.AnswerID);
                cmd.Parameters.AddWithValue("@AdministratorID", comment.AdministratorID);
                cmd.Parameters.AddWithValue("@CommentContent", comment.CommentContent);
                cmd.Parameters.AddWithValue("@CommetDate", comment.CommentDate);
                cmd.Parameters.AddWithValue("@IsDeleted", comment.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AddCommentUser(Comment comment)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Comments(AnswerID,UserID,CommentContent,CommetDate,IsDeleted) VALUES(@AnswerID,@UserID,@CommentContent,@CommetDate,@IsDeleted)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AnswerID", comment.AnswerID);
                cmd.Parameters.AddWithValue("@UserID", comment.UserID);
                cmd.Parameters.AddWithValue("@CommentContent", comment.CommentContent);
                cmd.Parameters.AddWithValue("@CommetDate", comment.CommentDate);
                cmd.Parameters.AddWithValue("@IsDeleted", comment.IsDeleted);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region ListMethods
        public List<Topic> ListTopic(bool isDeleted)
        {
            try
            {
                List<Topic> topics = new List<Topic>();
                cmd.CommandText = "SELECT * FROM Topics WHERE IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isDeleted);
                con.Open();
                if (isDeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Topic topic = new Topic();
                        topic.TopicID = reader.GetInt32(0);
                        topic.TopicName = reader.GetString(1);
                        topic.IsDeleted = reader.GetBoolean(2);
                        topics.Add(topic);
                    }
                }
                return topics;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Administrator> ListAdmin(bool isDeleted)
        {
            try
            {
                List<Administrator> administrators = new List<Administrator>();
                cmd.CommandText = "SELECT AD.AdministratorID,AD.AuthorityID,AU.AuthorityName,AD.Name,AD.SecondName,AD.Surname,AD.UserName,AD.Eposta,AD.Password,AD.MobilePhone,AD.IsDeleted  FROM Administrators AS AD JOIN Authorities AS AU ON AD.AuthorityID = AU.AuthorityID WHERE AD.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isDeleted);
                con.Open();
                if (isDeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Administrator administrator = new Administrator();
                        administrator.AdministratorID = reader.GetInt32(0);
                        administrator.AuthorityID = reader.GetInt32(1);
                        administrator.AuthorityName = reader.GetString(2);
                        administrator.Name = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                        {
                            administrator.SecondName = reader.GetString(4);
                        }
                        else
                        {
                            administrator.SecondName = "-";
                        }
                        administrator.Surname = reader.GetString(5);
                        administrator.UserName = reader.GetString(6);
                        administrator.Eposta = reader.GetString(7);
                        administrator.Password = reader.GetString(8);
                        administrator.MobilePhone = reader.GetString(9);
                        administrator.IsDeleted = reader.GetBoolean(10);
                        administrators.Add(administrator);
                    }

                }
                return administrators;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Administrator> ListAdminReturnIt(bool isDeleted)
        {
            try
            {
                List<Administrator> administrators = new List<Administrator>();
                cmd.CommandText = "SELECT AD.AdministratorID,AD.AuthorityID,AU.AuthorityName,AD.Name,AD.SecondName,AD.Surname,AD.UserName,AD.Eposta,AD.Password,AD.MobilePhone,AD.IsDeleted  FROM Administrators AS AD JOIN Authorities AS AU ON AD.AuthorityID = AU.AuthorityID WHERE AD.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isDeleted);
                con.Open();
                if (isDeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Administrator administrator = new Administrator();
                        administrator.AdministratorID = reader.GetInt32(0);
                        administrator.AuthorityID = reader.GetInt32(1);
                        administrator.AuthorityName = reader.GetString(2);
                        administrator.Name = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                        {
                            administrator.SecondName = reader.GetString(4);
                        }
                        else
                        {
                            administrator.SecondName = "-";
                        }
                        administrator.Surname = reader.GetString(5);
                        administrator.UserName = reader.GetString(6);
                        administrator.Eposta = reader.GetString(7);
                        administrator.Password = reader.GetString(8);
                        administrator.MobilePhone = reader.GetString(9);
                        administrator.IsDeleted = reader.GetBoolean(10);
                        administrators.Add(administrator);
                    }

                }
                return administrators;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<User> ListUser(bool isdeleted)
        {
            try
            {
                List<User> users = new List<User>();
                cmd.CommandText = "SELECT * FROM Users WHERE IsDeleted=@IsDeleted ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                        {
                            user.SecondName = reader.GetString(2);
                        }
                        else
                        {
                            user.SecondName = "-";
                        }
                        user.Surname = reader.GetString(3);
                        user.UserName = reader.GetString(4);
                        user.Eposta = reader.GetString(5);
                        user.Password = reader.GetString(6);
                        user.MobilePhone = reader.GetString(7);
                        user.MembershipDate = reader.GetDateTime(8);
                        user.Birthdate = reader.GetDateTime(9);
                        user.IsDeleted = reader.GetBoolean(10);
                        user.Age = (int)DateTime.Now.Year - (int)user.Birthdate.Year;
                        users.Add(user);
                    }
                }
                con.Close();
                for (int i = 0; i < users.Count; i++)
                {
                    User user = new User();
                    users[i].QuestionNumber = FindNumberOfQuestion(users[i].UserID);
                    users[i].Commentnumber = FindNumberOfComments(users[i].UserID);
                }

                return users;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {

            }
        }
        public List<User> ListUserPasive(bool isdeleted)
        {
            try
            {
                List<User> users = new List<User>();
                cmd.CommandText = "SELECT * FROM Users WHERE IsDeleted=@IsDeleted ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                        {
                            user.SecondName = reader.GetString(2);
                        }
                        else
                        {
                            user.SecondName = "-";
                        }
                        user.Surname = reader.GetString(3);
                        user.UserName = reader.GetString(4);
                        user.Eposta = reader.GetString(5);
                        user.Password = reader.GetString(6);
                        user.MobilePhone = reader.GetString(7);
                        user.MembershipDate = reader.GetDateTime(8);
                        user.Birthdate = reader.GetDateTime(9);
                        user.IsDeleted = reader.GetBoolean(10);
                        user.Age = (int)DateTime.Now.Year - (int)user.Birthdate.Year;
                        user.QuestionNumber = 0;
                        user.Commentnumber = 0;
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Topic> ListTopicAktive(bool isdeleted)
        {
            try
            {
                List<Topic> topics = new List<Topic>();
                cmd.CommandText = "SELECT * FROM Topics WHERE IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Topic topic = new Topic();
                        topic.TopicID = reader.GetInt32(0);
                        topic.TopicName = reader.GetString(1);
                        topic.IsDeleted = reader.GetBoolean(2);
                        topics.Add(topic);
                    }
                }
                return topics;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Question> ListQuestionAktive(bool isdeleted)
        {
            try
            {
                List<Question> questions = new List<Question>();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.AdministratorID,AD.Name,AD.UserName,A.AuthorityName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Administrators AS AD ON Q.AdministratorID=AD.AdministratorID JOIN Authorities AS A ON A.AuthorityID=AD.AuthorityID WHERE Q.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isdeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.QuestionID = reader.GetInt32(0);
                        question.TopicID = reader.GetInt32(1);
                        question.TopicName = reader.GetString(2);
                        question.AdministratorID = reader.GetInt32(3);
                        question.Name = reader.GetString(4);
                        question.UserName = reader.GetString(5);
                        question.AuthorityName = reader.GetString(6);
                        question.Summary = reader.GetString(7);
                        question.FullContent = reader.GetString(8);
                        question.ThumbnailName = reader.GetString(9);
                        question.FullPictureName = reader.GetString(10);
                        question.LoadingDate = reader.GetDateTime(11);
                        if (!reader.IsDBNull(12))
                        {
                            question.Seen = reader.GetInt32(12);
                        }
                        else
                        {
                            question.Seen = 0;
                        }
                        question.IsDeleted = reader.GetBoolean(13);
                        questions.Add(question);
                    }
                }
                con.Close();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.UserID,U.Name,U.UserName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Users AS U ON Q.UserID=U.UserID WHERE Q.IsDeleted=@IsDeleted ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isdeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.QuestionID = reader.GetInt32(0);
                        question.TopicID = reader.GetInt32(1);
                        question.TopicName = reader.GetString(2);
                        question.UserID = reader.GetInt32(3);
                        question.Name = reader.GetString(4);
                        question.UserName = reader.GetString(5);
                        question.AuthorityName = "User";
                        question.Summary = reader.GetString(6);
                        question.FullContent = reader.GetString(7);
                        question.ThumbnailName = reader.GetString(8);
                        question.FullPictureName = reader.GetString(9);
                        question.LoadingDate = reader.GetDateTime(10);
                        if (!reader.IsDBNull(11))
                        {
                            question.Seen = reader.GetInt32(11);
                        }
                        else
                        {
                            question.Seen = 0;
                        }
                        question.IsDeleted = reader.GetBoolean(12);
                        questions.Add(question);
                    }
                }
                return questions;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Answer> ListAnswerAktive(bool isdeleted)
        {
            try
            {
                List<Answer> answers = new List<Answer>();
                cmd.CommandText = "SELECT An.AnswerID, An.QuestionID, An.AdministratorID,An.AnswerDate,An.AnswerContent,An.IsDeleted,Ad.Name, AuthorityName FROM Answers AS An JOIN Administrators As Ad ON An.AdministratorID=Ad.AdministratorID JOIN Authorities AS Au ON Ad.AuthorityID= Au.AuthorityID WHERE An.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.AnswerID = reader.GetInt32(0);
                        answer.QuestionID = reader.GetInt32(1);
                        answer.AdministratorID = reader.GetInt32(2);
                        answer.AnswerDate = reader.GetDateTime(3);
                        answer.AnswerContent = reader.GetString(4);
                        answer.IsDeleted = reader.GetBoolean(5);
                        answer.Name = reader.GetString(6);
                        answer.AuthorityName = reader.GetString(7);
                        answers.Add(answer);
                    }
                }
                return answers;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
        public List<Answer> ListAnswerAktive(bool isdeleted, int questionID)
        {
            try
            {
                List<Answer> answers = new List<Answer>();
                cmd.CommandText = "SELECT An.AnswerID, An.QuestionID, An.AdministratorID,An.AnswerDate,An.AnswerContent,An.IsDeleted,Ad.Name, AuthorityName FROM Answers AS An JOIN Administrators As Ad ON An.AdministratorID=Ad.AdministratorID JOIN Authorities AS Au ON Ad.AuthorityID= Au.AuthorityID WHERE An.IsDeleted=@IsDeleted AND AN.QuestionID=@QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.AnswerID = reader.GetInt32(0);
                        answer.QuestionID = reader.GetInt32(1);
                        answer.AdministratorID = reader.GetInt32(2);
                        answer.AnswerDate = reader.GetDateTime(3);
                        answer.AnswerContent = reader.GetString(4);
                        answer.IsDeleted = reader.GetBoolean(5);
                        answer.Name = reader.GetString(6);
                        answer.AuthorityName = reader.GetString(7);
                        answers.Add(answer);
                    }
                }
                return answers;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comment> ListCommentAktive(bool isdeleted)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,AD.AdministratorID,C.CommentContent,C.CommetDate,C.IsDeleted,AD.Name,A.AuthorityName FROM Comments AS C JOIN Administrators AS AD ON C.AdministratorID= AD.AdministratorID JOIN Authorities AS A ON AD.AuthorityID=A.AuthorityID WHERE C.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.AdministratorID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = reader.GetString(7);
                        comments.Add(comment);
                    }
                }
                con.Close();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,C.UserID,C.CommentContent,C.CommetDate,C.IsDeleted,U.Name FROM Comments AS C JOIN Users AS U ON C.UserID= U.UserID  WHERE C.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.UserID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = "User";
                        comments.Add(comment);
                    }
                }
                return comments;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comment> ListCommentAktive(bool isdeleted, int answerID)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,AD.AdministratorID,C.CommentContent,C.CommetDate,C.IsDeleted,AD.Name,A.AuthorityName FROM Comments AS C JOIN Administrators AS AD ON C.AdministratorID= AD.AdministratorID JOIN Authorities AS A ON AD.AuthorityID=A.AuthorityID WHERE C.IsDeleted=@IsDeleted AND C.AnswerID = @AnswerID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                cmd.Parameters.AddWithValue("@AnswerID", answerID);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.AdministratorID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = reader.GetString(7);
                        comments.Add(comment);
                    }
                }
                con.Close();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,C.UserID,C.CommentContent,C.CommetDate,C.IsDeleted,U.UserName FROM Comments AS C JOIN Users AS U ON C.UserID= U.UserID  WHERE C.IsDeleted=@IsDeleted AND C.AnswerID = @AnswerID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                cmd.Parameters.AddWithValue("@AnswerID", answerID);
                con.Open();
                if (isdeleted == false)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.UserID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = "User";
                        comments.Add(comment);
                    }
                }

                return comments;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comment> ListCommentPassive(bool isdeleted)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,AD.AdministratorID,C.CommentContent,C.CommetDate,C.IsDeleted,AD.Name,A.AuthorityName FROM Comments AS C JOIN Administrators AS AD ON C.AdministratorID= AD.AdministratorID JOIN Authorities AS A ON AD.AuthorityID=A.AuthorityID WHERE C.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.AdministratorID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = reader.GetString(7);
                        comments.Add(comment);
                    }
                }
                con.Close();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,C.UserID,C.CommentContent,C.CommetDate,C.IsDeleted,U.Name FROM Comments AS C JOIN Users AS U ON C.UserID= U.UserID  WHERE C.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.UserID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = "User";
                        comments.Add(comment);
                    }
                }
                return comments;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Answer> ListAnswerPassive(bool isdeleted)
        {
            try
            {
                List<Answer> answers = new List<Answer>();
                cmd.CommandText = "SELECT An.AnswerID, An.QuestionID, An.AdministratorID,An.AnswerDate,An.AnswerContent,An.IsDeleted,Ad.Name, AuthorityName FROM Answers AS An JOIN Administrators As Ad ON An.AdministratorID=Ad.AdministratorID JOIN Authorities AS Au ON Ad.AuthorityID= Au.AuthorityID WHERE An.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Answer answer = new Answer();
                        answer.AnswerID = reader.GetInt32(0);
                        answer.QuestionID = reader.GetInt32(1);
                        answer.AdministratorID = reader.GetInt32(2);
                        answer.AnswerDate = reader.GetDateTime(3);
                        answer.AnswerContent = reader.GetString(4);
                        answer.IsDeleted = reader.GetBoolean(5);
                        answer.Name = reader.GetString(6);
                        answer.AuthorityName = reader.GetString(7);
                        answers.Add(answer);
                    }
                }
                return answers;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Question> ListQuestionPassive(bool isdeleted)
        {
            try
            {
                List<Question> questions = new List<Question>();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.AdministratorID,AD.Name,AD.UserName,A.AuthorityName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Administrators AS AD ON Q.AdministratorID=AD.AdministratorID JOIN Authorities AS A ON A.AuthorityID=AD.AuthorityID WHERE Q.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isdeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.QuestionID = reader.GetInt32(0);
                        question.TopicID = reader.GetInt32(1);
                        question.TopicName = reader.GetString(2);
                        question.AdministratorID = reader.GetInt32(3);
                        question.Name = reader.GetString(4);
                        question.UserName = reader.GetString(5);
                        question.AuthorityName = reader.GetString(6);
                        question.Summary = reader.GetString(7);
                        question.FullContent = reader.GetString(8);
                        question.ThumbnailName = reader.GetString(9);
                        question.FullPictureName = reader.GetString(10);
                        question.LoadingDate = reader.GetDateTime(11);
                        if (!reader.IsDBNull(12))
                        {
                            question.Seen = reader.GetInt32(12);
                        }
                        else
                        {
                            question.Seen = 0;
                        }
                        question.IsDeleted = reader.GetBoolean(13);
                        questions.Add(question);
                    }
                }
                con.Close();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.UserID,U.Name,U.UserName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Users AS U ON Q.UserID=U.UserID WHERE Q.IsDeleted=@IsDeleted ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isdeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.QuestionID = reader.GetInt32(0);
                        question.TopicID = reader.GetInt32(1);
                        question.TopicName = reader.GetString(2);
                        question.UserID = reader.GetInt32(3);
                        question.Name = reader.GetString(4);
                        question.UserName = reader.GetString(5);
                        question.AuthorityName = "User";
                        question.Summary = reader.GetString(6);
                        question.FullContent = reader.GetString(7);
                        question.ThumbnailName = reader.GetString(8);
                        question.FullPictureName = reader.GetString(9);
                        question.LoadingDate = reader.GetDateTime(10);
                        if (!reader.IsDBNull(11))
                        {
                            question.Seen = reader.GetInt32(11);
                        }
                        else
                        {
                            question.Seen = 0;
                        }
                        question.IsDeleted = reader.GetBoolean(12);
                        questions.Add(question);
                    }
                }
                return questions;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Question> ListQuestionCheck(bool isDeleted)
        {
            try
            {
                List<Question> questions = new List<Question>();
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.UserID,U.Name,U.UserName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Users AS U ON Q.UserID=U.UserID WHERE Q.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isdeleted", isDeleted);
                con.Open();
                if (isDeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Question question = new Question();
                        question.QuestionID = reader.GetInt32(0);
                        question.TopicID = reader.GetInt32(1);
                        question.TopicName = reader.GetString(2);
                        question.UserID = reader.GetInt32(3);
                        question.Name = reader.GetString(4);
                        question.UserName = reader.GetString(5);
                        question.AuthorityName = "User";
                        question.Summary = reader.GetString(6);
                        question.FullContent = reader.GetString(7);
                        question.ThumbnailName = reader.GetString(8);
                        question.FullPictureName = reader.GetString(9);
                        question.LoadingDate = reader.GetDateTime(10);
                        if (!reader.IsDBNull(11))
                        {
                            question.Seen = reader.GetInt32(11);
                        }
                        else
                        {
                            question.Seen = 0;
                        }
                        question.IsDeleted = reader.GetBoolean(12);
                        questions.Add(question);
                    }
                }
                return questions;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Comment> ListCommentCheck(bool isdeleted)
        {
            try
            {
                List<Comment> comments = new List<Comment>();
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,C.UserID,C.CommentContent,C.CommetDate,C.IsDeleted,U.UserName FROM Comments AS C JOIN Users AS U ON C.UserID= U.UserID  WHERE C.IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.CommentID = reader.GetInt32(0);
                        comment.AnswerID = reader.GetInt32(1);
                        comment.UserID = reader.GetInt32(2);
                        comment.CommentContent = reader.GetString(3);
                        comment.CommentDate = reader.GetDateTime(4);
                        comment.IsDeleted = reader.GetBoolean(5);
                        comment.Name = reader.GetString(6);
                        comment.AuthorityName = "User";
                        comments.Add(comment);
                    }
                }
                return comments;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Topic> ListTopicPassive(bool isdeleted)
        {
            try
            {
                List<Topic> topics = new List<Topic>();
                cmd.CommandText = "SELECT * FROM Topics WHERE IsDeleted=@IsDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", isdeleted);
                con.Open();
                if (isdeleted == true)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Topic topic = new Topic();
                        topic.TopicID = reader.GetInt32(0);
                        topic.TopicName = reader.GetString(1);
                        topic.IsDeleted = reader.GetBoolean(2);
                        topics.Add(topic);
                    }
                }
                return topics;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region DeleteMethods
        public bool DeleteAdmin(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Administrators SET IsDeleted = 1 WHERE AdministratorID = @AdministratorID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AdministratorID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AKtiveTopic(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Topics SET IsDeleted = 1 WHERE TopicID = @TopicID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AktiveQuestion(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Questions SET IsDeleted = 1 WHERE QuestionID = @QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AktiveAnswer(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Answers SET IsDeleted = 1 WHERE AnswerID = @AnswerID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AnswerID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AktiveComment(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Comments SET IsDeleted = 1 WHERE CommentID = @CommentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CommentID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool PassiveComment(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Comments SET IsDeleted = 0 WHERE CommentID = @CommentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CommentID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool PassiveAnswer(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Answers SET IsDeleted = 0 WHERE AnswerID = @AnswerID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AnswerID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool PassiveQuestion(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Questions SET IsDeleted = 0 WHERE QuestionID = @QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool PassiveTopic(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Topics SET IsDeleted = 0 WHERE TopicID = @TopicID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool ReturnItAdmin(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Administrators SET IsDeleted = 0 WHERE AdministratorID = @AdministratorID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AdministratorID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool PasiveUser(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET IsDeleted = 1 WHERE UserID = @UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Questions SET IsDeleted=1 WHERE UserID=@UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.CommandText = " UPDATE Questions SET UserID = null WHERE UserID = @UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.CommandText = " UPDATE Comments SET IsDeleted = 1 WHERE UserID = @UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.CommandText = "UPDATE Comments SET UserID = null WHERE UserID = @UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.CommandText = "DELETE FROM  Users WHERE UserID = @UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool AktiveUser(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET IsDeleted = 0 WHERE UserID = @UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
        #region UpdateMethods
        public Administrator GetAdministrator(int adminID)
        {
            try
            {
                cmd.CommandText = "SELECT AD.AdministratorID,AD.AuthorityID,AU.AuthorityName,AD.Name,AD.SecondName,AD.Surname,AD.UserName,AD.Eposta,AD.Password,AD.MobilePhone,AD.IsDeleted FROM Administrators AS AD JOIN Authorities AS AU ON AD.AuthorityID = AU.AuthorityID WHERE AD.AdministratorID=@AdministratorID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AdministratorID", adminID);
                con.Open();
                Administrator administrator = new Administrator();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    administrator.AdministratorID = reader.GetInt32(0);
                    administrator.AuthorityID = reader.GetInt32(1);
                    administrator.AuthorityName = reader.GetString(2);
                    administrator.Name = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        administrator.SecondName = reader.GetString(4);
                    }
                    else
                    {
                        administrator.SecondName = "-";
                    }
                    administrator.Surname = reader.GetString(5);
                    administrator.UserName = reader.GetString(6);
                    administrator.Eposta = reader.GetString(7);
                    administrator.Password = reader.GetString(8);
                    administrator.MobilePhone = reader.GetString(9);
                    administrator.IsDeleted = reader.GetBoolean(10);
                }
                return administrator;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public User GetUser(int userId)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Users WHERE UserID=@UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();
                User user = new User();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.UserID = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.SecondName = reader.GetString(2);
                    user.Surname = reader.GetString(3);
                    user.UserName = reader.GetString(4);
                    user.Eposta = reader.GetString(5);
                    user.Password = reader.GetString(6);
                    user.MobilePhone = reader.GetString(7);
                    user.MembershipDate = reader.GetDateTime(8);
                    user.Birthdate = reader.GetDateTime(9);
                    user.IsDeleted = reader.GetBoolean(10);
                }
                return user;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Question GetQuestionAdmin(int questionID)
        {
            try
            {
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.AdministratorID,AD.Name,AD.UserName,A.AuthorityName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Administrators AS AD ON Q.AdministratorID=AD.AdministratorID JOIN Authorities AS A ON A.AuthorityID=AD.AuthorityID WHERE Q.QuestionID=@QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                Question question = new Question();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    question.QuestionID = reader.GetInt32(0);
                    question.TopicID = reader.GetInt32(1);
                    question.TopicName = reader.GetString(2);
                    question.AdministratorID = reader.GetInt32(3);
                    question.Name = reader.GetString(4);
                    question.UserName = reader.GetString(5);
                    question.AuthorityName = reader.GetString(6);
                    question.Summary = reader.GetString(7);
                    question.FullContent = reader.GetString(8);
                    question.ThumbnailName = reader.GetString(9);
                    question.FullPictureName = reader.GetString(10);
                    question.LoadingDate = reader.GetDateTime(11);
                    if (!reader.IsDBNull(12))
                    {
                        question.Seen = reader.GetInt32(12);
                    }
                    else
                    {
                        question.Seen = 0;
                    }
                    question.IsDeleted = reader.GetBoolean(13);
                }

                return question;


            }
            catch (Exception)
            {
                return null;

            }
            finally
            {
                con.Close();
            }

        }
        public Question GetQuestionUser(int questionID)
        {
            try
            {
                cmd.CommandText = "SELECT Q.QuestionID,Q.TopicID,T.TopicName,Q.UserID,U.Name,U.UserName,Q.Summary,Q.FullContent,Q.ThumbnailName,Q.FullPictureName,Q.LoadingDate,Q.Seen,Q.IsDeleted FROM Questions AS Q JOIN Topics AS T ON Q.TopicID=T.TopicID JOIN Users AS U ON Q.UserID=U.UserID WHERE Q.QuestionID=@QuestionID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                Question question = new Question();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    question.QuestionID = reader.GetInt32(0);
                    question.TopicID = reader.GetInt32(1);
                    question.TopicName = reader.GetString(2);
                    question.UserID = reader.GetInt32(3);
                    question.Name = reader.GetString(4);
                    question.UserName = reader.GetString(5);
                    question.AuthorityName = "User";
                    question.Summary = reader.GetString(6);
                    question.FullContent = reader.GetString(7);
                    question.ThumbnailName = reader.GetString(8);
                    question.FullPictureName = reader.GetString(9);
                    question.LoadingDate = reader.GetDateTime(10);
                    if (!reader.IsDBNull(11))
                    {
                        question.Seen = reader.GetInt32(11);
                    }
                    else
                    {
                        question.Seen = 0;
                    }
                    question.IsDeleted = reader.GetBoolean(12);
                }
                return question;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Comment GetCommentAdmin(int commentID)
        {
            try
            {
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,AD.AdministratorID,C.CommentContent,C.CommetDate,C.IsDeleted,AD.Name,A.AuthorityName FROM Comments AS C JOIN Administrators AS AD ON C.AdministratorID= AD.AdministratorID JOIN Authorities AS A ON AD.AuthorityID=A.AuthorityID WHERE C.CommentID=@CommentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CommentID", commentID);
                con.Open();
                Comment comment = new Comment();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comment.CommentID = reader.GetInt32(0);
                    comment.AnswerID = reader.GetInt32(1);
                    comment.AdministratorID = reader.GetInt32(2);
                    comment.CommentContent = reader.GetString(3);
                    comment.CommentDate = reader.GetDateTime(4);
                    comment.IsDeleted = reader.GetBoolean(5);
                    comment.Name = reader.GetString(6);
                    comment.AuthorityName = reader.GetString(7);
                }
                return comment;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Comment GetCommentUser(int commentID)
        {
            try
            {
                cmd.CommandText = "SELECT C.CommentID,C.AnswerID,C.UserID,C.CommentContent,C.CommetDate,C.IsDeleted,U.Name FROM Comments AS C JOIN Users AS U ON C.UserID= U.UserID  WHERE C.CommentID=@CommentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CommentID", commentID);
                con.Open();
                Comment comment = new Comment();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comment.CommentID = reader.GetInt32(0);
                    comment.AnswerID = reader.GetInt32(1);
                    comment.UserID = reader.GetInt32(2);
                    comment.CommentContent = reader.GetString(3);
                    comment.CommentDate = reader.GetDateTime(4);
                    comment.IsDeleted = reader.GetBoolean(5);
                    comment.Name = reader.GetString(6);
                    comment.AuthorityName = "User";
                }
                return comment;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Topic GetTopic(int topicID)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Topics WHERE TopicID = @TopicID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicID", topicID);
                con.Open();
                Topic topic = new Topic();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    topic.TopicID = reader.GetInt32(0);
                    topic.TopicName = reader.GetString(1);
                    topic.IsDeleted = reader.GetBoolean(2);
                }
                return topic;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Answer GetAnswer(int answerID)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Answers WHERE AnswerID=@AnswerID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AnswerID", answerID);
                con.Open();
                Answer answer = new Answer();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    answer.AnswerID = reader.GetInt32(0);
                    answer.QuestionID = reader.GetInt32(1);
                    answer.AdministratorID = reader.GetInt32(2);
                    answer.AnswerDate = reader.GetDateTime(3);
                    answer.AnswerContent = reader.GetString(4);
                    answer.IsDeleted = reader.GetBoolean(5);
                }
                return answer;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<int> GetAnswerQuestionID(int QuestionID)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Answers WHERE QuestionID=@QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
                con.Open();
                List<int> answerId = new List<int>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Answer answer = new Answer();
                    answer.AnswerID = reader.GetInt32(0);
                    answer.QuestionID = reader.GetInt32(1);
                    answer.AdministratorID = reader.GetInt32(2);
                    answer.AnswerDate = reader.GetDateTime(3);
                    answer.AnswerContent = reader.GetString(4);
                    answer.IsDeleted = reader.GetBoolean(5);
                    answerId.Add(answer.AnswerID);
                }
                return answerId;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateAdmin(Administrator administrator)
        {
            try
            {
                cmd.CommandText = "UPDATE Administrators SET AuthorityID=@AuthorityID,Name=@Name,SecondName=@SecondName,Surname=@Surname,UserName=@UserName,Eposta=@Eposta,Password=@Password,MobilePhone=@MobilePhone,IsDeleted=@IsDeleted WHERE AdministratorID=@AdministratorID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AuthorityID", administrator.AuthorityID);
                cmd.Parameters.AddWithValue("@Name", administrator.Name);
                cmd.Parameters.AddWithValue("@SecondName", administrator.SecondName);
                cmd.Parameters.AddWithValue("@Surname", administrator.Surname);
                cmd.Parameters.AddWithValue("@UserName", administrator.UserName);
                cmd.Parameters.AddWithValue("@Eposta", administrator.Eposta);
                cmd.Parameters.AddWithValue("@Password", administrator.Password);
                cmd.Parameters.AddWithValue("@MobilePhone", administrator.MobilePhone);
                cmd.Parameters.AddWithValue("@IsDeleted", administrator.IsDeleted);
                cmd.Parameters.AddWithValue("@AdministratorID", administrator.AdministratorID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdatePasswordAdmin(string otp,int adminID)
        {
            try
            {
                cmd.CommandText = "UPDATE Administrators SET Password=@Password WHERE AdministratorID=@AdministratorID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Password", otp);
                cmd.Parameters.AddWithValue("@AdministratorID", adminID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdatePasswordUser(string otp, int userID)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET Password=@Password WHERE UserID=@UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Password", otp);
                cmd.Parameters.AddWithValue("@UserID", userID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateQuestion(Question question)
        {
            try
            {
                cmd.CommandText = "UPDATE Questions SET  TopicID=@TopicID, Summary=@Summary, FullContent=@FullContent, ThumbnailName = @ThumbnailName, FullPictureName=@FullPictureName, LoadingDate=@LoadingDate, Seen=@Seen, IsDeleted=@IsDeleted WHERE QuestionID=@QuestionID  ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicID", question.TopicID);
                cmd.Parameters.AddWithValue("@Summary", question.Summary);
                cmd.Parameters.AddWithValue("@FullContent", question.FullContent);
                cmd.Parameters.AddWithValue("@ThumbnailName", question.ThumbnailName);
                cmd.Parameters.AddWithValue("@FullPictureName", question.FullPictureName);
                cmd.Parameters.AddWithValue("@LoadingDate", question.LoadingDate);
                cmd.Parameters.AddWithValue("@Seen", question.Seen);
                cmd.Parameters.AddWithValue("@IsDeleted", question.IsDeleted);
                cmd.Parameters.AddWithValue("@QuestionID", question.QuestionID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpddateComment(Comment comment)
        {
            try
            {
                cmd.CommandText = "UPDATE Comments SET IsDeleted=@IsDeleted,CommentContent=@CommentContent WHERE CommentID=@CommentID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", comment.IsDeleted);
                cmd.Parameters.AddWithValue("@CommentContent", comment.CommentContent);
                cmd.Parameters.AddWithValue("@CommentID", comment.CommentID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateAnswer(Answer answer)
        {
            try
            {
                cmd.CommandText = "UPDATE Answers SET IsDeleted =@IsDeleted, AnswerContent=@AnswerContent WHERE  AnswerID=@AnswerID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@IsDeleted", answer.IsDeleted);
                cmd.Parameters.AddWithValue("@AnswerContent", answer.AnswerContent);
                cmd.Parameters.AddWithValue("@AnswerID", answer.AnswerID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateTopic(Topic topic)
        {
            try
            {
                cmd.CommandText = " UPDATE Topics SET TopicName=@TopicName WHERE TopicID=@TopicID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TopicName", topic.TopicName);
                cmd.Parameters.AddWithValue("@TopicID", topic.TopicID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteQuestion(int questionID)
        {
            try
            {
                cmd.CommandText = "Update Questions SET TopicID=null,UserID=null WHERE QuestionID=@QuestionID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.CommandText = "DELETE FROM  Questions WHERE QuestionID = @QuestionID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteComment(int commentID)
        {
            try
            {
                cmd.CommandText = "Update Comments SET AnswerID=null,UserID=null WHERE CommentID=@CommentID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CommentID", commentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.CommandText = "DELETE FROM Commnets WHERE CommentID=@CommentID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CommentID", commentID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET Name=@Name,SecondName=@SecondName,Surname=@Surname,UserName=@UserName,Eposta=@Eposta,Password=@Password,MobilePhone=@MobilePhone,Birthdate=@Birthdate,IsDeleted=@IsDeleted WHERE UserID=@UserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@SecondName", user.SecondName);
                cmd.Parameters.AddWithValue("@Surname", user.Surname);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Eposta", user.Eposta);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@MobilePhone", user.MobilePhone);
                cmd.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                cmd.Parameters.AddWithValue("@IsDeleted", user.IsDeleted);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
