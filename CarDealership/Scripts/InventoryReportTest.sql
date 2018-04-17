SELECT l.ModelYear, ma.MakeName, ModelName, COUNT(*) as [Count], SUM(l.SalePrice) AS 'StockValue'
FROM Listings l 
INNER JOIN Models mo on mo.ModelId = l.ModelId
INNER JOIN Makes ma on ma.MakeId = mo.MakeId

WHERE l.Condition = 2

GROUP BY l.ModelYear, mo.ModelName, ma.MakeName, l.SalePrice

