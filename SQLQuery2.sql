SELECT P.uniqueName, 
W.id, W.platformId, W.uniqueName, W.latitude, W.longitude,W.createdAt, W.updatedAt
FROM dbo.platforms AS P 
JOIN wells AS W 
ON W.platformId = P.platformId
ORDER BY W.updatedAt DESC