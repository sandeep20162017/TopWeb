USE MASTER 
GO 
 
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB 
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'WebSitesDB' ) 
DROP DATABASE WebSitesDB 
GO 
 
CREATE DATABASE WebSitesDB 
GO 
 
USE WebSitesDB 
GO 
 
 
-- 1) //////////// WebSiteMasters 
 
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'WebSiteMasters' ) 
DROP TABLE WebSiteMasters 
GO 
 
CREATE TABLE [dbo].[WebSiteMasters]( 
        [WebID] INT IDENTITY PRIMARY KEY, 
		[VisitDate] datetime NOT NULL,
        [WebName] [varchar](100) NOT NULL,    
        [Visits]  int NOT NULL,    
        
) 
 