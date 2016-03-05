
CREATE VIEW `Tenant_Summary_V` AS
SELECT org_hub.ID, org_hub.Code, org_sat.Name, org_sat.Description, org_sat.ValidFrom, org_sat.ValidUntil, COUNT(pers_hub.ID) AS NumberOfPersons
FROM Tenant_H org_hub
JOIN Tenant_S org_sat ON org_sat.TenantID = org_hub.ID
JOIN Person_H pers_hub ON pers_hub.TenantID = org_hub.ID
GROUP BY org_hub.ID;