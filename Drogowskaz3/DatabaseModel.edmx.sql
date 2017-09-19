
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2017 18:44:02
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
IF OBJECT_ID(N'[dbo].[FK_MassChurch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Masses] DROP CONSTRAINT [FK_MassChurch];
GO
IF OBJECT_ID(N'[dbo].[FK_HolidayRule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rules] DROP CONSTRAINT [FK_HolidayRule];
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
IF OBJECT_ID(N'[dbo].[Holidays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Holidays];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Churches'
CREATE TABLE [dbo].[Churches] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Decanate] nvarchar(max)  NULL,
    [Diocese] nvarchar(max)  NULL
);
GO

-- Creating table 'Rules'
CREATE TABLE [dbo].[Rules] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MassType] nvarchar(max)  NULL,
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
    [Week3] bit  NOT NULL,
    [Week4] bit  NOT NULL,
    [Week5] bit  NOT NULL,
    [WeekLast] bit  NOT NULL,
    [CycleType] nvarchar(max)  NULL,
    [DateBegin] datetime  NULL,
    [DateEnd] datetime  NULL,
    [Hour] time  NOT NULL,
    [DateShift] int  NULL,
    [RepeatDateFirst] datetime  NULL,
    [RepeatEveryDays] int  NULL,
    [RepeatEveryDayInMonth] int  NULL,
    [RepeatType] nvarchar(max)  NULL,
    [ChurchId] bigint  NOT NULL,
    [CycleId] bigint  NOT NULL,
    [HolidayId] bigint  NOT NULL,
    [Comment] nvarchar(max)  NULL
);
GO

-- Creating table 'Masses'
CREATE TABLE [dbo].[Masses] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DateAndTime] datetime  NOT NULL,
    [RuleId] bigint  NOT NULL,
    [MassType] nvarchar(max)  NULL,
    [ChurchId] bigint  NOT NULL
);
GO

-- Creating table 'Cycles'
CREATE TABLE [dbo].[Cycles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [DateStart] datetime  NULL,
    [DateEnd] datetime  NULL,
    [Year] int  NOT NULL
);
GO

-- Creating table 'ExceptionsRules'
CREATE TABLE [dbo].[ExceptionsRules] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [RuleId] bigint  NOT NULL
);
GO

-- Creating table 'Holidays'
CREATE TABLE [dbo].[Holidays] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Date] datetime  NULL,
    [Year] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Holidays'
ALTER TABLE [dbo].[Holidays]
ADD CONSTRAINT [PK_Holidays]
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

-- Creating foreign key on [ChurchId] in table 'Masses'
ALTER TABLE [dbo].[Masses]
ADD CONSTRAINT [FK_MassChurch]
    FOREIGN KEY ([ChurchId])
    REFERENCES [dbo].[Churches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MassChurch'
CREATE INDEX [IX_FK_MassChurch]
ON [dbo].[Masses]
    ([ChurchId]);
GO

-- Creating foreign key on [HolidayId] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [FK_HolidayRule]
    FOREIGN KEY ([HolidayId])
    REFERENCES [dbo].[Holidays]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HolidayRule'
CREATE INDEX [IX_FK_HolidayRule]
ON [dbo].[Rules]
    ([HolidayId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------