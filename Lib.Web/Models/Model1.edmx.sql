
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2016 13:59:37
-- Generated from EDMX file: D:\Self Education\Projects\MyProjects\Lib\Lib.Web\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [lib];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Books__CoutryId__1FCDBCEB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK__Books__CoutryId__1FCDBCEB];
GO
IF OBJECT_ID(N'[dbo].[FK__Books__LanguageI__1ED998B2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK__Books__LanguageI__1ED998B2];
GO
IF OBJECT_ID(N'[dbo].[FK__Books__SeriesId__1DE57479]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK__Books__SeriesId__1DE57479];
GO
IF OBJECT_ID(N'[dbo].[FK_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksAuthors] DROP CONSTRAINT [FK_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorGenre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorsGenres] DROP CONSTRAINT [FK_AuthorGenre];
GO
IF OBJECT_ID(N'[dbo].[FK_Book]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksAuthors] DROP CONSTRAINT [FK_Book];
GO
IF OBJECT_ID(N'[dbo].[FK_BookGenre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksGenres] DROP CONSTRAINT [FK_BookGenre];
GO
IF OBJECT_ID(N'[dbo].[FK_BookInterpreter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksInterpreters] DROP CONSTRAINT [FK_BookInterpreter];
GO
IF OBJECT_ID(N'[dbo].[FK_BookPublisher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksPublishers] DROP CONSTRAINT [FK_BookPublisher];
GO
IF OBJECT_ID(N'[dbo].[FK_BookTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksTags] DROP CONSTRAINT [FK_BookTag];
GO
IF OBJECT_ID(N'[dbo].[FK_GenreAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorsGenres] DROP CONSTRAINT [FK_GenreAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_GenreBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksGenres] DROP CONSTRAINT [FK_GenreBook];
GO
IF OBJECT_ID(N'[dbo].[FK_InterpreterBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksInterpreters] DROP CONSTRAINT [FK_InterpreterBook];
GO
IF OBJECT_ID(N'[dbo].[FK_PublisherBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksPublishers] DROP CONSTRAINT [FK_PublisherBook];
GO
IF OBJECT_ID(N'[dbo].[FK_TagBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BooksTags] DROP CONSTRAINT [FK_TagBook];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO
IF OBJECT_ID(N'[dbo].[AuthorsGenres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorsGenres];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[BooksAuthors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BooksAuthors];
GO
IF OBJECT_ID(N'[dbo].[BooksGenres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BooksGenres];
GO
IF OBJECT_ID(N'[dbo].[BooksInterpreters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BooksInterpreters];
GO
IF OBJECT_ID(N'[dbo].[BooksPublishers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BooksPublishers];
GO
IF OBJECT_ID(N'[dbo].[BooksTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BooksTags];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO
IF OBJECT_ID(N'[dbo].[Interpreters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interpreters];
GO
IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[Publishers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publishers];
GO
IF OBJECT_ID(N'[dbo].[Series]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Series];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] varchar(255)  NOT NULL,
    [MiddleName] varchar(255)  NULL,
    [LastName] varchar(255)  NOT NULL,
    [DateOfBirth] datetime  NULL,
    [Biography] varchar(max)  NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [ISBN] varchar(255)  NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Annotation] varchar(max)  NULL,
    [Rating] smallint  NULL,
    [SeriesId] uniqueidentifier  NULL,
    [PagesNumber] smallint  NULL,
    [PublishedOn] datetime  NULL,
    [TranslatedOn] datetime  NULL,
    [ReleasedOn] datetime  NULL,
    [LanguageId] uniqueidentifier  NULL,
    [CoutryId] uniqueidentifier  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Interpreters'
CREATE TABLE [dbo].[Interpreters] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] varchar(255)  NOT NULL,
    [MiddleName] varchar(255)  NULL,
    [LastName] varchar(255)  NOT NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Series'
CREATE TABLE [dbo].[Series] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'AuthorsGenres'
CREATE TABLE [dbo].[AuthorsGenres] (
    [Authors_Id] uniqueidentifier  NOT NULL,
    [Genres_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BooksAuthors'
CREATE TABLE [dbo].[BooksAuthors] (
    [Authors_Id] uniqueidentifier  NOT NULL,
    [Books_ISBN] varchar(255)  NOT NULL
);
GO

-- Creating table 'BooksGenres'
CREATE TABLE [dbo].[BooksGenres] (
    [Books_ISBN] varchar(255)  NOT NULL,
    [Genres_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BooksInterpreters'
CREATE TABLE [dbo].[BooksInterpreters] (
    [Books_ISBN] varchar(255)  NOT NULL,
    [Interpreters_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BooksPublishers'
CREATE TABLE [dbo].[BooksPublishers] (
    [Books_ISBN] varchar(255)  NOT NULL,
    [Publishers_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BooksTags'
CREATE TABLE [dbo].[BooksTags] (
    [Books_ISBN] varchar(255)  NOT NULL,
    [Tags_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ISBN] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([ISBN] ASC);
GO

-- Creating primary key on [Id] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Interpreters'
ALTER TABLE [dbo].[Interpreters]
ADD CONSTRAINT [PK_Interpreters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publishers'
ALTER TABLE [dbo].[Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Series'
ALTER TABLE [dbo].[Series]
ADD CONSTRAINT [PK_Series]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Authors_Id], [Genres_Id] in table 'AuthorsGenres'
ALTER TABLE [dbo].[AuthorsGenres]
ADD CONSTRAINT [PK_AuthorsGenres]
    PRIMARY KEY CLUSTERED ([Authors_Id], [Genres_Id] ASC);
GO

-- Creating primary key on [Authors_Id], [Books_ISBN] in table 'BooksAuthors'
ALTER TABLE [dbo].[BooksAuthors]
ADD CONSTRAINT [PK_BooksAuthors]
    PRIMARY KEY CLUSTERED ([Authors_Id], [Books_ISBN] ASC);
GO

-- Creating primary key on [Books_ISBN], [Genres_Id] in table 'BooksGenres'
ALTER TABLE [dbo].[BooksGenres]
ADD CONSTRAINT [PK_BooksGenres]
    PRIMARY KEY CLUSTERED ([Books_ISBN], [Genres_Id] ASC);
GO

-- Creating primary key on [Books_ISBN], [Interpreters_Id] in table 'BooksInterpreters'
ALTER TABLE [dbo].[BooksInterpreters]
ADD CONSTRAINT [PK_BooksInterpreters]
    PRIMARY KEY CLUSTERED ([Books_ISBN], [Interpreters_Id] ASC);
GO

-- Creating primary key on [Books_ISBN], [Publishers_Id] in table 'BooksPublishers'
ALTER TABLE [dbo].[BooksPublishers]
ADD CONSTRAINT [PK_BooksPublishers]
    PRIMARY KEY CLUSTERED ([Books_ISBN], [Publishers_Id] ASC);
GO

-- Creating primary key on [Books_ISBN], [Tags_Id] in table 'BooksTags'
ALTER TABLE [dbo].[BooksTags]
ADD CONSTRAINT [PK_BooksTags]
    PRIMARY KEY CLUSTERED ([Books_ISBN], [Tags_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CoutryId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Books__CoutryId__1FCDBCEB]
    FOREIGN KEY ([CoutryId])
    REFERENCES [dbo].[Countries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Books__CoutryId__1FCDBCEB'
CREATE INDEX [IX_FK__Books__CoutryId__1FCDBCEB]
ON [dbo].[Books]
    ([CoutryId]);
GO

-- Creating foreign key on [LanguageId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Books__LanguageI__1ED998B2]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Books__LanguageI__1ED998B2'
CREATE INDEX [IX_FK__Books__LanguageI__1ED998B2]
ON [dbo].[Books]
    ([LanguageId]);
GO

-- Creating foreign key on [SeriesId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK__Books__SeriesId__1DE57479]
    FOREIGN KEY ([SeriesId])
    REFERENCES [dbo].[Series]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Books__SeriesId__1DE57479'
CREATE INDEX [IX_FK__Books__SeriesId__1DE57479]
ON [dbo].[Books]
    ([SeriesId]);
GO

-- Creating foreign key on [Authors_Id] in table 'AuthorsGenres'
ALTER TABLE [dbo].[AuthorsGenres]
ADD CONSTRAINT [FK_AuthorsGenres_Authors]
    FOREIGN KEY ([Authors_Id])
    REFERENCES [dbo].[Authors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Genres_Id] in table 'AuthorsGenres'
ALTER TABLE [dbo].[AuthorsGenres]
ADD CONSTRAINT [FK_AuthorsGenres_Genres]
    FOREIGN KEY ([Genres_Id])
    REFERENCES [dbo].[Genres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorsGenres_Genres'
CREATE INDEX [IX_FK_AuthorsGenres_Genres]
ON [dbo].[AuthorsGenres]
    ([Genres_Id]);
GO

-- Creating foreign key on [Authors_Id] in table 'BooksAuthors'
ALTER TABLE [dbo].[BooksAuthors]
ADD CONSTRAINT [FK_BooksAuthors_Authors]
    FOREIGN KEY ([Authors_Id])
    REFERENCES [dbo].[Authors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Books_ISBN] in table 'BooksAuthors'
ALTER TABLE [dbo].[BooksAuthors]
ADD CONSTRAINT [FK_BooksAuthors_Books]
    FOREIGN KEY ([Books_ISBN])
    REFERENCES [dbo].[Books]
        ([ISBN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BooksAuthors_Books'
CREATE INDEX [IX_FK_BooksAuthors_Books]
ON [dbo].[BooksAuthors]
    ([Books_ISBN]);
GO

-- Creating foreign key on [Books_ISBN] in table 'BooksGenres'
ALTER TABLE [dbo].[BooksGenres]
ADD CONSTRAINT [FK_BooksGenres_Books]
    FOREIGN KEY ([Books_ISBN])
    REFERENCES [dbo].[Books]
        ([ISBN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Genres_Id] in table 'BooksGenres'
ALTER TABLE [dbo].[BooksGenres]
ADD CONSTRAINT [FK_BooksGenres_Genres]
    FOREIGN KEY ([Genres_Id])
    REFERENCES [dbo].[Genres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BooksGenres_Genres'
CREATE INDEX [IX_FK_BooksGenres_Genres]
ON [dbo].[BooksGenres]
    ([Genres_Id]);
GO

-- Creating foreign key on [Books_ISBN] in table 'BooksInterpreters'
ALTER TABLE [dbo].[BooksInterpreters]
ADD CONSTRAINT [FK_BooksInterpreters_Books]
    FOREIGN KEY ([Books_ISBN])
    REFERENCES [dbo].[Books]
        ([ISBN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Interpreters_Id] in table 'BooksInterpreters'
ALTER TABLE [dbo].[BooksInterpreters]
ADD CONSTRAINT [FK_BooksInterpreters_Interpreters]
    FOREIGN KEY ([Interpreters_Id])
    REFERENCES [dbo].[Interpreters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BooksInterpreters_Interpreters'
CREATE INDEX [IX_FK_BooksInterpreters_Interpreters]
ON [dbo].[BooksInterpreters]
    ([Interpreters_Id]);
GO

-- Creating foreign key on [Books_ISBN] in table 'BooksPublishers'
ALTER TABLE [dbo].[BooksPublishers]
ADD CONSTRAINT [FK_BooksPublishers_Books]
    FOREIGN KEY ([Books_ISBN])
    REFERENCES [dbo].[Books]
        ([ISBN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Publishers_Id] in table 'BooksPublishers'
ALTER TABLE [dbo].[BooksPublishers]
ADD CONSTRAINT [FK_BooksPublishers_Publishers]
    FOREIGN KEY ([Publishers_Id])
    REFERENCES [dbo].[Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BooksPublishers_Publishers'
CREATE INDEX [IX_FK_BooksPublishers_Publishers]
ON [dbo].[BooksPublishers]
    ([Publishers_Id]);
GO

-- Creating foreign key on [Books_ISBN] in table 'BooksTags'
ALTER TABLE [dbo].[BooksTags]
ADD CONSTRAINT [FK_BooksTags_Books]
    FOREIGN KEY ([Books_ISBN])
    REFERENCES [dbo].[Books]
        ([ISBN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tags_Id] in table 'BooksTags'
ALTER TABLE [dbo].[BooksTags]
ADD CONSTRAINT [FK_BooksTags_Tags]
    FOREIGN KEY ([Tags_Id])
    REFERENCES [dbo].[Tags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BooksTags_Tags'
CREATE INDEX [IX_FK_BooksTags_Tags]
ON [dbo].[BooksTags]
    ([Tags_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------