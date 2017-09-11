
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/11/2017 10:49:27
-- Generated from EDMX file: C:\Users\s384064\Source\Repos\drogowskaz\Drogowskaz3\DatabaseModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_RuleMass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masses] DROP CONSTRAINT [FK_RuleMass];
GO
IF OBJECT_ID(N'[dbo].[FK_ChurchRule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rules] DROP CONSTRAINT [FK_ChurchRule];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Churches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Churches];
GO
IF OBJECT_ID(N'[dbo].[Rules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rules];
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
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rules'
CREATE TABLE [dbo].[Rules] (
    [Id] uniqueidentifier  NOT NULL,
    [MassType] nvarchar(max)  NOT NULL,
    [Monday] bit  NOT NULL,
    [Tuesday] bit  NOT NULL,
    [Wednesday] bit  NOT NULL,
    [Thursday] bit  NOT NULL,
    [Friday] bit  NOT NULL,
    [Saturday] bit  NOT NULL,
    [Sunday] bit  NOT NULL,
    [I] bit  NOT NULL,
    [II] bit  NOT NULL,
    [III] bit  NOT NULL,
    [IV] bit  NOT NULL,
    [V] bit  NOT NULL,
    [VI] bit  NOT NULL,
    [VII] bit  NOT NULL,
    [VIII] bit  NOT NULL,
    [IX] bit  NOT NULL,
    [X] bit  NOT NULL,
    [XI] bit  NOT NULL,
    [XII] bit  NOT NULL,
    [Week1] bit  NOT NULL,
    [Week2] bit  NOT NULL,
    [Week3] nvarchar(max)  NOT NULL,
    [Week4] bit  NOT NULL,
    [Week5] bit  NOT NULL,
    [WeekLast] nvarchar(max)  NOT NULL,
    [CycleType] nvarchar(max)  NOT NULL,
    [ChurchId] uniqueidentifier  NOT NULL,
    [CycleId] uniqueidentifier  NOT NULL,
    [SingularMass] nvarchar(max)  NOT NULL,
    [DateBegin] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Hour] datetime  NOT NULL,
    [CyclicalWeekday] nvarchar(max)  NOT NULL,
    [CyclicalMonthday] nvarchar(max)  NOT NULL,
    [DateShift] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Masses'
CREATE TABLE [dbo].[Masses] (
    [Id] uniqueidentifier  NOT NULL,
    [RuleId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Cycles'
CREATE TABLE [dbo].[Cycles] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ExceptionsRules'
CREATE TABLE [dbo].[ExceptionsRules] (
    [Id] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL,
    [Rule_Id] uniqueidentifier  NOT NULL
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

-- Creating primary key on [Id] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [PK_Rules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Masses'
ALTER TABLE [dbo].[Masses]
ADD CONSTRAINT [PK_Masses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cycles'
ALTER TABLE [dbo].[Cycles]
ADD CONSTRAINT [PK_Cycles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExceptionsRules'
ALTER TABLE [dbo].[ExceptionsRules]
ADD CONSTRAINT [PK_ExceptionsRules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RuleId] in table 'Masses'
ALTER TABLE [dbo].[Masses]
ADD CONSTRAINT [FK_RuleMass]
    FOREIGN KEY ([RuleId])
    REFERENCES [dbo].[Rules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RuleMass'
CREATE INDEX [IX_FK_RuleMass]
ON [dbo].[Masses]
    ([RuleId]);
GO

-- Creating foreign key on [ChurchId] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [FK_ChurchRule]
    FOREIGN KEY ([ChurchId])
    REFERENCES [dbo].[Churches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChurchRule'
CREATE INDEX [IX_FK_ChurchRule]
ON [dbo].[Rules]
    ([ChurchId]);
GO

-- Creating foreign key on [CycleId] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [FK_LiturgicalCycleRule]
    FOREIGN KEY ([CycleId])
    REFERENCES [dbo].[Cycles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LiturgicalCycleRule'
CREATE INDEX [IX_FK_LiturgicalCycleRule]
ON [dbo].[Rules]
    ([CycleId]);
GO

-- Creating foreign key on [Rule_Id] in table 'ExceptionsRules'
ALTER TABLE [dbo].[ExceptionsRules]
ADD CONSTRAINT [FK_ExceptionsRulesRule]
    FOREIGN KEY ([Rule_Id])
    REFERENCES [dbo].[Rules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExceptionsRulesRule'
CREATE INDEX [IX_FK_ExceptionsRulesRule]
ON [dbo].[ExceptionsRules]
    ([Rule_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------