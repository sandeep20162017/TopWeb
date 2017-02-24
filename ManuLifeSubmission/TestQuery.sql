SELECT TOP 5 [WebID]
      ,[VisitDate]
      ,[WebName]
      ,[Visits]
  FROM [WebSitesDB].[dbo].[WebSiteMasters] where VisitDate='2016-01-06' order by Visits desc