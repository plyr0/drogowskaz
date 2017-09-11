
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/11/2017 18:59:05
-- Generated from EDMX file: C:\Users\plyr0\git\drogowskaz\Drogowskaz3\DatabaseModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_RuleChurch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rules] DROP CONSTRAINT [FK_RuleChurch];
GO
IF OBJECT_ID(N'[dbo].[FK_MassRule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masses] DROP CONSTRAINT [FK_MassRule];
GO
IF OBJECT_ID(N'[dbo].[FK_RuleCycle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rules] DROP CONSTRAINT [FK_RuleCycle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExceptionsRulesRule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExceptionsRules] DROP CONSTRAINT [FK_ExceptionsRulesRule];
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
IF OBJECT_ID(N'[dbo].[Cycles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cycles];
GO
IF OBJECT_ID(N'[dbo].[ExceptionsRules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExceptionsRules];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Churches'
CREATE TABLE [dbo].[Churches] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL
);
GO

-- Creating table 'Rules'
CREATE TABLE [dbo].[Rules] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MassType] nvarchar(max)  NULL,
    [Monday] bit  NULL,
    [Tuesday] bit  NULL,
    [Wednesday] bit  NULL,
    [Thursday] bit  NULL,
    [Friday] bit  NULL,
    [Saturday] bit  NULL,
    [Sunday] bit  NULL,
    [I] bit  NULL,
    [II] bit  NULL,
    [III] bit  NULL,
    [IV] bit  NULL,
    [V] bit  NULL,
    [VI] bit  NULL,
    [VII] bit  NULL,
    [VIII] bit  NULL,
    [IX] bit  NULL,
    [X] bit  NULL,
    [XI] bit  NULL,
    [XII] bit  NULL,
    [Week1] bit  NULL,
    [Week2] bit  NULL,
    [Week3] bit  NULL,
    [Week4] bit  NULL,
    [Week5] bit  NULL,
    [WeekLast] bit  NULL,
    [CycleType] nvarchar(max)  NULL,
    [SingularMass] datetime  NULL,
    [DateBegin] datetime  NULL,
    [DateEnd] datetime  NULL,
    [Hour] time  NULL,
    [DateShift] int  NULL,
    [RepeatDateFirst] datetime  NULL,
    [RepeatEveryDays] int  NULL,
    [RepeatEveryDayInMonth] int  NULL,
    [RepeatType] nvarchar(max)  NULL,
    [ChurchId] bigint  NOT NULL,
    [CycleId] bigint  NOT NULL
);
GO

-- Creating table 'Masses'
CREATE TABLE [dbo].[Masses] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DateAndTime] nvarchar(max)  NOT NULL,
    [RuleId] bigint  NOT NULL
);
GO

-- Creating table 'Cycles'
CREATE TABLE [dbo].[Cycles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] nvarchar(max)  NULL,
    [EndDate] nvarchar(max)  NULL
);
GO

-- Creating table 'ExceptionsRules'
CREATE TABLE [dbo].[ExceptionsRules] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [RuleId] bigint  NOT NULL
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

-- Creating foreign key on [ChurchId] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [FK_RuleChurch]
    FOREIGN KEY ([ChurchId])
    REFERENCES [dbo].[Churches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RuleChurch'
CREATE INDEX [IX_FK_RuleChurch]
ON [dbo].[Rules]
    ([ChurchId]);
GO

-- Creating foreign key on [RuleId] in table 'Masses'
ALTER TABLE [dbo].[Masses]
ADD CONSTRAINT [FK_MassRule]
    FOREIGN KEY ([RuleId])
    REFERENCES [dbo].[Rules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MassRule'
CREATE INDEX [IX_FK_MassRule]
ON [dbo].[Masses]
    ([RuleId]);
GO

-- Creating foreign key on [CycleId] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [FK_RuleCycle]
    FOREIGN KEY ([CycleId])
    REFERENCES [dbo].[Cycles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RuleCycle'
CREATE INDEX [IX_FK_RuleCycle]
ON [dbo].[Rules]
    ([CycleId]);
GO

-- Creating foreign key on [RuleId] in table 'ExceptionsRules'
ALTER TABLE [dbo].[ExceptionsRules]
ADD CONSTRAINT [FK_ExceptionsRulesRule]
    FOREIGN KEY ([RuleId])
    REFERENCES [dbo].[Rules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExceptionsRulesRule'
CREATE INDEX [IX_FK_ExceptionsRulesRule]
ON [dbo].[ExceptionsRules]
    ([RuleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------