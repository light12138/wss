USE test

SELECT * FROM dbo.Student

USE [test]
GO

/****** Object:  Table [dbo].[Grades]    Script Date: 2017/7/18 18:05:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Grades](
	[Id] [INT] IDENTITY(1,1001) NOT NULL,
	[Name] [NVARCHAR](100) NOT NULL,
 CONSTRAINT [PK__Grades__3214EC07125BF668] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [test]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 2017/7/18 18:05:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[Id] [INT] NOT NULL,
	[Name] [NVARCHAR](100) NOT NULL,
	[Age] [INT] NOT NULL,
	[GradeId] [INT] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


