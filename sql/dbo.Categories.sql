USE [CategoriesApp]
GO

/****** Object: Table [dbo].[Categories] Script Date: 10/11/2015 8:39:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Categories];


GO
CREATE TABLE [dbo].[Categories] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [ParentId] INT            NULL
);


