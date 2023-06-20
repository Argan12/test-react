use test_react;

GO

CREATE PROCEDURE [dbo].[GetAllArticles]
AS
BEGIN
    SET NOCOUNT ON;
	SET FMTONLY OFF;

	SELECT 
		a.[id] AS article_id, 
		a.[title], 
		a.[content], 
		a.[date],
		u.[id] AS user_id,
		u.[pseudo]
	FROM [test_react].[dbo].[article] a
	INNER JOIN [test_react].[dbo].[user] u
	ON u.[id] = a.[author]
	ORDER BY a.[date] DESC
END;