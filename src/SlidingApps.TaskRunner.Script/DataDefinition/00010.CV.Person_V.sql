﻿CREATE VIEW `Person_V` AS
SELECT pers_hub.ID, org_hub.ID AS OrganizationID, org_hub.Code AS OrganizationCode, pers_hub.StartDate, pers_hub.EndDate, persid_sat.Name, persid_sat.Firstname, persid_sat.DisplayName, persid_sat.Info
FROM Person_H pers_hub
JOIN Person_Identity_S persid_sat ON persid_sat.PersonID = pers_hub.ID
JOIN Organization_H org_hub ON org_hub.ID = pers_hub.OrganizationID;