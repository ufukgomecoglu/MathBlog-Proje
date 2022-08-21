CREATE DATABASE MathBlog
GO
USE MathBlog
GO
CREATE TABLE Authorities
(
	AuthorityID INT IDENTITY(1,1),
	AuthorityName NVARCHAR(20) NOT NULL,
	CONSTRAINT pk_authority PRIMARY KEY (AuthorityID)
)
GO
INSERT INTO Authorities(AuthorityName) VALUES('Admin') 
INSERT INTO Authorities(AuthorityName) VALUES('Math Teacher') 
INSERT INTO Authorities(AuthorityName) VALUES('Math Academician') 

GO
CREATE TABLE Administrators
(
	AdministratorID INT IDENTITY(1,1),
	AuthorityID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	SecondName NVARCHAR(50) ,
	Surname NVARCHAR(50) NOT NULL,
	UserName NVARCHAR(50) NOT NULL,
	Eposta NVARCHAR(50) NOT NULL,
	Password NVARCHAR(64) NOT NULL,
	MobilePhone NVARCHAR (20) NOT NULL,
	IsDeleted BIT NOT NULL,
	CONSTRAINT pk_administrator PRIMARY KEY (AdministratorID),
	CONSTRAINT fk_administratorAuthority FOREIGN KEY(AuthorityID) REFERENCES Authorities(AuthorityID),
)
GO
INSERT INTO Administrators(AuthorityID,Name,SecondName,Surname,UserName,Eposta,Password,MobilePhone,IsDeleted) VALUES (1,'Ufuk','','Gömeçoðlu','Ufuk','Deneme@deneme.com.tr','deneme','05396923901',0)
GO
CREATE TABLE Users
(
	UserID INT IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	SecondName NVARCHAR(50) ,
	Surname NVARCHAR(50) NOT NULL,
	UserName NVARCHAR(50) NOT NULL,
	Eposta NVARCHAR(50) NOT NULL,
	Password NVARCHAR(64) NOT NULL,
	MobilePhone NVARCHAR (20) NOT NULL,
	MembershipDate DATETIME NOT NULL,
	Birthdate DATETIME NOT NULL,
	IsDeleted BIT NOT NULL,
	CONSTRAINT pk_user PRIMARY KEY (UserID),
)
GO
CREATE TABLE Topics
(
	TopicID INT IDENTITY (1,1),
	TopicName NVARCHAR(50) NOT NULL,
	IsDeleted BIT NOT NULL,
	CONSTRAINT pk_topic PRIMARY KEY (TopicID)
)
GO
CREATE TABLE Questions
(
	QuestionID INT IDENTITY(1,1),
	AdministratorID INT ,
	UserID INT,
	TopicID INT ,
	Summary NVARCHAR(256) NOT NULL,
	FullContent NVARCHAR(MAX) NOT NULL,
	ThumbnailName NVARCHAR(50),
	FullPictureName NVARCHAR(50),
	LoadingDate DATETIME NOT NULL,
	Seen INT ,
	IsDeleted BIT NOT NULL,
	CONSTRAINT pk_question PRIMARY KEY (QuestionID),
	CONSTRAINT fk_questionAdministrator FOREIGN KEY(AdministratorID) REFERENCES Administrators(AdministratorID),
	CONSTRAINT fk_questionUser FOREIGN KEY(UserID) REFERENCES Users(UserID),
	CONSTRAINT fk_questionTopic FOREIGN KEY(TopicID) REFERENCES Topics(TopicID),
)
GO
CREATE TABLE Answers
(
	AnswerID INT IDENTITY(1,1),
	QuestionID INT NOT NULL,
	AdministratorID INT NOT NULL,
	AnswerDate DATETIME NOT NULL,
	AnswerContent NVARCHAR(MAX) NOT NULL,
	IsDeleted BIT NOT NULL,
	CONSTRAINT pk_answer PRIMARY KEY (AnswerID),
	CONSTRAINT fk_answerQuestion FOREIGN KEY(QuestionID) REFERENCES Questions(QuestionID),
	CONSTRAINT fk_answerAdministrator FOREIGN KEY(AdministratorID) REFERENCES Administrators(AdministratorID),
)
GO
CREATE TABLE Comments
(
	CommentID INT IDENTITY(1,1),
	AnswerID INT ,
	UserID INT,
	AdministratorID INT,
	CommentContent NVARCHAR(300) NOT NULL,
	CommetDate DATETIME NOT NULL,
	IsDeleted BIT NOT NULL,
	CONSTRAINT pk_Comment PRIMARY KEY (CommentID),
	CONSTRAINT fk_commentAnswer FOREIGN KEY (AnswerID) REFERENCES Answers(AnswerID),
	CONSTRAINT fk_commentAdministrator FOREIGN KEY (AdministratorID) REFERENCES Administrators(AdministratorID),
	CONSTRAINT fk_commentUser FOREIGN KEY (UserID) REFERENCES Users(UserID),
)
