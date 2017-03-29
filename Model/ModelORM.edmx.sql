
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2017 22:29:55
-- Generated from EDMX file: D:\Source\KonsorcjumLekarzy\Model\ModelORM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KonsorcjumLekarzy];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DoctorDoctorType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoctorSet] DROP CONSTRAINT [FK_DoctorDoctorType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DoctorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoctorSet];
GO
IF OBJECT_ID(N'[dbo].[DoctorTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoctorTypeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DoctorSet'
CREATE TABLE [dbo].[DoctorSet] (
    [DoctorID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PhoneNumber] decimal(18,0)  NOT NULL,
    [DoctorType_DoctorTypeID] int  NOT NULL
);
GO

-- Creating table 'DoctorTypeSet'
CREATE TABLE [dbo].[DoctorTypeSet] (
    [DoctorTypeID] int IDENTITY(1,1) NOT NULL,
    [DoctorTypeName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DoctorID] in table 'DoctorSet'
ALTER TABLE [dbo].[DoctorSet]
ADD CONSTRAINT [PK_DoctorSet]
    PRIMARY KEY CLUSTERED ([DoctorID] ASC);
GO

-- Creating primary key on [DoctorTypeID] in table 'DoctorTypeSet'
ALTER TABLE [dbo].[DoctorTypeSet]
ADD CONSTRAINT [PK_DoctorTypeSet]
    PRIMARY KEY CLUSTERED ([DoctorTypeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DoctorType_DoctorTypeID] in table 'DoctorSet'
ALTER TABLE [dbo].[DoctorSet]
ADD CONSTRAINT [FK_DoctorDoctorType]
    FOREIGN KEY ([DoctorType_DoctorTypeID])
    REFERENCES [dbo].[DoctorTypeSet]
        ([DoctorTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorDoctorType'
CREATE INDEX [IX_FK_DoctorDoctorType]
ON [dbo].[DoctorSet]
    ([DoctorType_DoctorTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------