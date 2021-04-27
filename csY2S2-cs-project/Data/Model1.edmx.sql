
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/26/2021 16:14:44
-- Generated from EDMX file: C:\Users\s00190262\Desktop\csY2S2-cs-project\csY2S2-cs-project\Data\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [userAndRoles];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_usersrole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[users] DROP CONSTRAINT [FK_usersrole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO
IF OBJECT_ID(N'[dbo].[roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[roles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [image] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [userName] nvarchar(max)  NOT NULL,
    [roleId] int  NOT NULL
);
GO

-- Creating table 'roles'
CREATE TABLE [dbo].[roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [roleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'orders'
CREATE TABLE [dbo].[orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [productName] nvarchar(max)  NOT NULL,
    [ProductId] nvarchar(max)  NOT NULL,
    [totalPrice] nvarchar(max)  NOT NULL,
    [customersId] int  NOT NULL
);
GO

-- Creating table 'customers'
CREATE TABLE [dbo].[customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'roles'
ALTER TABLE [dbo].[roles]
ADD CONSTRAINT [PK_roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [PK_orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'customers'
ALTER TABLE [dbo].[customers]
ADD CONSTRAINT [PK_customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [roleId] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [FK_usersrole]
    FOREIGN KEY ([roleId])
    REFERENCES [dbo].[roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_usersrole'
CREATE INDEX [IX_FK_usersrole]
ON [dbo].[users]
    ([roleId]);
GO

-- Creating foreign key on [customersId] in table 'orders'
ALTER TABLE [dbo].[orders]
ADD CONSTRAINT [FK_customersorders]
    FOREIGN KEY ([customersId])
    REFERENCES [dbo].[customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_customersorders'
CREATE INDEX [IX_FK_customersorders]
ON [dbo].[orders]
    ([customersId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------