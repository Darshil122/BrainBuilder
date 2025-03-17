CREATE TABLE [dbo].[Users] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [FullName]  NVARCHAR (100) NOT NULL,
    [Email]     NVARCHAR (100) NOT NULL,
    [Password]  NVARCHAR (255) NOT NULL,
    [CreatedAt] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[Courses] (
    [CourseID]   INT           IDENTITY (1, 1) NOT NULL,
    [CourseName] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([CourseID] ASC)
);

CREATE TABLE [dbo].[Questions] (
    [QuestionID]    INT            IDENTITY (1, 1) NOT NULL,
    [QuestionText]  NVARCHAR (MAX) NOT NULL,
    [Option1]       NVARCHAR (255) NOT NULL,
    [Option2]       NVARCHAR (255) NOT NULL,
    [Option3]       NVARCHAR (255) NOT NULL,
    [Option4]       NVARCHAR (255) NOT NULL,
    [CorrectOption] NVARCHAR (10)  NOT NULL,
    [CreatedAt]     DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([QuestionID] ASC)
);

CREATE TABLE [dbo].[UserSubmissions] (
    [SubmissionID]   INT           IDENTITY (1, 1) NOT NULL,
    [UserID]         INT           NOT NULL,
    [CourseID]       INT           NOT NULL,
    [QuestionID]     INT           NOT NULL,
    [SelectedOption] NVARCHAR (10) NOT NULL,
    [SubmissionTime] DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([SubmissionID] ASC),
    CONSTRAINT [FK_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Course] FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Courses] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Question] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([QuestionID]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Certificates] (
    [CertificateId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserId]          INT            NOT NULL,
    [CourseName]      NVARCHAR (255) NOT NULL,
    [Score]           DECIMAL (5, 2) NOT NULL,
    [CertificatePath] NVARCHAR (500) NOT NULL,
    [IssueDate]       DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([CertificateId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);