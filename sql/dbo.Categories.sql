USE [CategoriesApp]
GO

/****** Object: Table [dbo].[Categories] Script Date: 15/11/2015 3:01:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Categories];


GO
CREATE TABLE [dbo].[Categories] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [ParentId] INT            NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (1, N'Category1', NULL)
INSERT INTO [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (2, N'Category2', 1)
INSERT INTO [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (3, N'Category3', NULL)
INSERT INTO [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (4, N'Category4', 2)
SET IDENTITY_INSERT [dbo].[Categories] OFF


