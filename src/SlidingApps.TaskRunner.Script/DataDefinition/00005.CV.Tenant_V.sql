
CREATE VIEW `Tenant_V` as
SELECT hub.ID, hub.Code, sat.Name, sat.Description, sat.ValidFrom, sat.ValidUntil
FROM Tenant_H hub
JOIN Tenant_S sat ON sat.TenantID = hub.ID;
