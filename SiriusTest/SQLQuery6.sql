SELECT 
[dbo].[persons].id,
[dbo].[persons].first_name,
[dbo].[persons].second_name,
[dbo].[persons].last_name,
[dbo].[persons].date_employ,
[dbo].[persons].date_uneploy,
[dbo].[status].[name] as statusName,
[dbo].[posts].[name] as postName,
[dbo].[deps].[name] as depsName
INTO personInfo
FROM [dbo].[persons]
JOIN  [dbo].[status]
ON [dbo].[persons].[status] = [dbo].[status].id 
JOIN [dbo].[posts]
ON [dbo].[persons].id_post = [dbo].[posts].id
JOIN [dbo].[deps]
ON [dbo].[persons].id_dep = [dbo].[deps].id