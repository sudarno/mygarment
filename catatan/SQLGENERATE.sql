SELECT CASE  
WHEN isnull(SUBSTR(CONCAT(GRNNO,'MRN.',DATE_FORMAT(NOW(), '%Y'),'.',RIGHT(CONCAT('000000000',RIGHT(IFNULL(MAX(GRNNO),0),5)+ 1),5)),LENGTH(GRNNO)+1))  THEN 'MRN.2014.00001'
ELSE
SUBSTR(CONCAT(GRNNO,'MRN.',DATE_FORMAT(NOW(), '%Y'),'.',RIGHT(CONCAT('000000000',RIGHT(IFNULL(MAX(GRNNO),0),5)+ 1),5)),LENGTH(GRNNO)+1)
END
FROM tblgrn