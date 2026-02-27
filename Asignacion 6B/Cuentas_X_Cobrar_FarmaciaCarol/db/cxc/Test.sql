USE CxC;
GO
SELECT name, type_desc
FROM sys.objects
WHERE name LIKE 'CxC_%' OR name LIKE 'sp_CxC_%'
ORDER BY type_desc, name;