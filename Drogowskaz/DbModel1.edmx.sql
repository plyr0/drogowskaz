
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/07/2017 09:31:06
-- Generated from EDMX file: C:\Users\s384064\Source\Repos\drogowskaz\Drogowskaz\DbModel1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [drogowskaz];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MassRuleMass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masses] DROP CONSTRAINT [FK_MassRuleMass];
GO
IF OBJECT_ID(N'[dbo].[FK_ChurchMassRule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MassRules] DROP CONSTRAINT [FK_ChurchMassRule];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Churches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Churches];
GO
IF OBJECT_ID(N'[dbo].[MassRules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MassRules];
GO
IF OBJECT_ID(N'[dbo].[Masses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Masses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Churches'
CREATE TABLE [dbo].[Churches] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Diocese] nvarchar(max)  NOT NULL,
    [Deanery] nvarchar(max)  NOT NULL,
    [Parish] nvarchar(max)  NOT NULL,
    [Location] geography  NOT NULL
);
GO

-- Creating table 'MassRules'
CREATE TABLE [dbo].[MassRules] (
    [Id] uniqueidentifier  NOT NULL,
    [Church_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Masses'
CREATE TABLE [dbo].[Masses] (
    [Id] uniqueidentifier  NOT NULL,
    [MassRule_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Churches'
ALTER TABLE [dbo].[Churches]
ADD CONSTRAINT [PK_Churches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MassRules'
ALTER TABLE [dbo].[MassRules]
ADD CONSTRAINT [PK_MassRules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Masses'
ALTER TABLE [dbo].[Masses]
ADD CONSTRAINT [PK_Masses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MassRule_Id] in table 'Masses'
ALTER TABLE [dbo].[Masses]
ADD CONSTRAINT [FK_MassRuleMass]
    FOREIGN KEY ([MassRule_Id])
    REFERENCES [dbo].[MassRules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MassRuleMass'
CREATE INDEX [IX_FK_MassRuleMass]
ON [dbo].[Masses]
    ([MassRule_Id]);
GO

-- Creating foreign key on [Church_Id] in table 'MassRules'
ALTER TABLE [dbo].[MassRules]
ADD CONSTRAINT [FK_ChurchMassRule]
    FOREIGN KEY ([Church_Id])
    REFERENCES [dbo].[Churches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChurchMassRule'
CREATE INDEX [IX_FK_ChurchMassRule]
ON [dbo].[MassRules]
    ([Church_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------