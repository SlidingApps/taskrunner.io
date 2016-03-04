CREATE VIEW `Organization_Summary_V` AS
SELECT org_hub.ID, org_hub.Code, org_sat.Name, org_sat.Description, org_sat.ValidFrom, org_sat.ValidUntil, COUNT(pers_hub.ID) AS NumberOfPersons
FROM Organization_H org_hub
JOIN Organization_S org_sat ON org_sat.OrganizationID = org_hub.ID
JOIN Person_H pers_hub ON pers_hub.OrganizationID = org_hub.ID
GROUP BY org_hub.ID;