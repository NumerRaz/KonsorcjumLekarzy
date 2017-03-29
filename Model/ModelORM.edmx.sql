
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2017 21:20:54
-- Generated from EDMX file: D:\Source\KonsorcjumLekarzy\Model\ModelORM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [DoctorTypeID] int  NOT NULL
);
GO

-- Creating table 'DoctorTypeSet'
CREATE TABLE [dbo].[DoctorTypeSet] (
    [DoctorTypeID] int IDENTITY(1,1) NOT NULL,
    [DoctorTypeName] nvarchar(max)  NOT NULL,
    [Doctor_DoctorID] int  NOT NULL
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

-- Creating foreign key on [Doctor_DoctorID] in table 'DoctorTypeSet'
ALTER TABLE [dbo].[DoctorTypeSet]
ADD CONSTRAINT [FK_DoctorTypeDoctor]
    FOREIGN KEY ([Doctor_DoctorID])
    REFERENCES [dbo].[DoctorSet]
        ([DoctorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorTypeDoctor'
CREATE INDEX [IX_FK_DoctorTypeDoctor]
ON [dbo].[DoctorTypeSet]
    ([Doctor_DoctorID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------